using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaleBotWin.Model;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using Ext = BaleBotWin.Model.Ext;

namespace BaleBotWin
{
    public partial class MainForm : Form
    {
        private WebSocket socketConnection;
        private Peer LastUser;
        public const string BaseApiUrl = "wss://api.bale.ai/v1/bots/";

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtToken.Text))
            {
                MessageBox.Show("توکن را وارد کرده از پدر بات ها دریافت کنید");
                return;
            }

            if (socketConnection != null && socketConnection.IsAlive)
            {
                socketConnection.Close(CloseStatusCode.Normal, "User Command");
                btnConnect.Text = "Connect";
            }
            else
            {
                if (socketConnection == null)
                {
                    socketConnection = new WebSocket(BaseApiUrl + txtToken.Text);
                    socketConnection.Log.Level = LogLevel.Debug;
                    socketConnection.Log.Output = (logInfo, data) =>
                    {
                        logData.Text += string.Format("{0}\t{1}\r\n{2}\r\n", logInfo.Level, logInfo.Date, logInfo.Message);
                        logData.SelectionStart = logData.TextLength;
                        logData.ScrollToCaret();
                    };
                    socketConnection.OnOpen += SocketConnection_OnOpen;
                    socketConnection.OnError += SocketConnection_OnError;
                    socketConnection.OnClose += SocketConnection_OnClose;
                    socketConnection.OnMessage += SocketConnection_OnMessage;
                }

                try
                {
                    socketConnection.Connect();
                    btnConnect.Text = "Disconnect!";
                    socketConnection.Log.Info("----- All Message Will Save -----");
                    socketConnection.Log.Info("DIR:" + AppDomain.CurrentDomain.BaseDirectory + "MsgLog.txt");
                    MessageBox.Show("Bot Running....");
                }
                catch (Exception ex)
                {
                    logData.Text += string.Format("{0}\t{1}\r\n{2}\r\n", "Error", DateTime.Now, ex.Message);
                    logData.SelectionStart = logData.TextLength;
                    logData.ScrollToCaret();
                }
            }
        }

        void WriteLog(string msg)
        {
            var f = AppDomain.CurrentDomain.BaseDirectory + "MsgLog.txt";
            File.AppendAllText(f, string.Format("{0}\r\n{1}\r\n---------------------\r\n", DateTime.Now, msg));
        }

        private void SocketConnection_OnMessage(object sender, MessageEventArgs e)
        {
            var ws = (WebSocket)sender;
            if (e.IsText)
            {
                ws.Log.Info("Text Message");
                WriteLog(e.Data);

                JObject baleObject = JObject.Parse(e.Data);
                var mainType = baleObject["$type"].Value<string>();
                var subType = "NO-BODY";
                var date = "NO-DATE";

                //detect body type
                if (baleObject["body"] != null && baleObject["body"]["$type"] != null)
                {
                    subType = baleObject["body"]["$type"].Value<string>();
                }

                //detect date main code
                if (baleObject["body"] != null && baleObject["body"]["date"] != null)
                {
                    date = baleObject["body"]["date"].Value<string>();
                }

                //detect date main code
                if (baleObject["body"] != null && baleObject["body"]["startDate"] != null)
                {
                    date = baleObject["body"]["startDate"].Value<string>();
                }

                //detect peer شناسایی کاربر
                if (baleObject["body"] != null && baleObject["body"]["peer"] != null)
                {
                    LastUser = new Peer()
                    {
                        accessHash = baleObject["body"]["peer"]["accessHash"].Value<string>(),
                        id = baleObject["body"]["peer"]["id"].Value<string>(),
                        type = baleObject["body"]["peer"]["$type"].Value<string>()
                    };

                    WriteLog("LastUserId:\t" + LastUser.id);
                }

                txtRec.Text += mainType + "\t" + subType + "\t" + date + "\r\n";

                //این یک پیام است
                if (mainType == "FatSeqUpdate" && subType == "Message")
                {
                    //این پیام متنی است
                    if (baleObject["body"]["message"]["$type"].Value<string>() == "Text")
                    {
                        var message = baleObject["body"]["message"]["text"].Value<string>();
                        txtRec.Text += message + "\r\n";
                    }
                    else
                    {
                        //این پیام حاوی فایل یا سند یا عکس است
                        var msgType = baleObject["body"]["message"]["$type"].Value<string>();
                        var mimeType = baleObject["body"]["message"]["mimeType"].Value<string>();
                        txtRec.Text += msgType + "\t" + mimeType + "\r\n";
                    }
                }

                if (mainType == "Response")
                {
                    if (baleObject["body"]["url"] != null)
                    {
                        //دریافت پاسخ برای آپلود فایل و ارسال فایل
                        var id = baleObject["id"].Value<long>();
                        var uploadUrl = baleObject["body"]["url"].Value<string>();

                        long fileSize;
                        string fileName;
                        string photoSize;

                        if (SendMessageTools.UploadFile(id, uploadUrl, socketConnection, out fileName, out fileSize, out photoSize))
                        {
                            //send Info
                            var fileId = baleObject["body"]["fileId"].Value<string>();
                            var hash = baleObject["body"]["userId"].Value<long>();

                            string msg;

                            //تشخیص ارسال عکس
                            if (string.IsNullOrEmpty(photoSize))
                            {
                                msg = SendMessageTools.GetDocumentMessage(new SendDocument()
                                {
                                    Type = "Document",
                                    AccessHash = hash,
                                    Algorithm = "algorithm",
                                    CheckSum = "checkSum",
                                    Caption = new Caption() { Text = txtPayam.Text, Type = "Text" },
                                    Ext = null,
                                    FileId = fileId,
                                    FileSize = fileSize,
                                    FileStorageVersion = 1,
                                    MimeType = "application/document",
                                    Name = fileName,
                                    Thumb = null
                                }, LastUser);
                            }
                            else
                            {
                                var sizeData = photoSize.Split('x').Select(c => Convert.ToInt32(c)).ToArray();
                                msg = SendMessageTools.GetPhotoMessage(new SendPhoto()
                                {
                                    Type = "Document",
                                    AccessHash = hash,
                                    Algorithm = "algorithm",
                                    CheckSum = "checkSum",
                                    Caption = new Caption() { Text = txtPayam.Text, Type = "Text" },
                                    FileId = fileId,
                                    FileSize = fileSize,
                                    FileStorageVersion = 1,
                                    Name = fileName,
                                    MimeType = "image/jpeg",
                                    Ext = new Ext() { Type = "Photo", Width = sizeData[0], Height = sizeData[1] },
                                    Thumb = new Thumb() { ThumbThumb = "None", Width = sizeData[0], Height = sizeData[1] }
                                }, LastUser);
                            }

                            socketConnection.Send(msg);
                            SendMessageTools.DeleteCacheUpload(id);
                        }
                    }
                }

                txtRec.SelectionStart = txtRec.TextLength;
                txtRec.ScrollToCaret();
            }
            else
            {
                ws.Log.Info("Binary Message");
                WriteLog(Convert.ToBase64String(e.RawData));
            }
        }

        private void SocketConnection_OnClose(object sender, CloseEventArgs e)
        {
            logData.Text += string.Format("{0}\t{1}\r\n{2}", "Close", DateTime.Now,
                "Connection closed:  " + e.Reason + "\t" + e.Code);
            logData.SelectionStart = logData.TextLength;
            logData.ScrollToCaret();

            btnConnect.Text = "Connect";
        }

        private void SocketConnection_OnError(object sender, ErrorEventArgs e)
        {
            var ws = (WebSocket)sender;
            ws.Log.Error(e.Message);
        }

        private void SocketConnection_OnOpen(object sender, EventArgs e)
        {
            var ws = (WebSocket)sender;
            ws.Log.Info("Connection now open");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socketConnection != null && socketConnection.IsAlive)
            {
                socketConnection.Close(CloseStatusCode.Normal, "User Command");
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (socketConnection == null || !socketConnection.IsAlive)
            {
                MessageBox.Show("ارتباط با سرور بله قطع است");
                return;
            }

            if (LastUser == null)
            {
                MessageBox.Show("کاربری یافت نشد. ابتدا یک پیام به بات ارسال کنید");
                return;
            }

            socketConnection.Send(SendMessageTools.GetTextMessage(txtPayam.Text, LastUser));
        }

        private void btnSendDoc_Click(object sender, EventArgs e)
        {
            if (socketConnection == null || !socketConnection.IsAlive)
            {
                MessageBox.Show("ارتباط با سرور بله قطع است");
                return;
            }

            if (LastUser == null)
            {
                MessageBox.Show("کاربری یافت نشد. ابتدا یک پیام به بات ارسال کنید");
                return;
            }

            if (selectUploadFile.ShowDialog() != DialogResult.OK)
                return;

            var filePath = selectUploadFile.FileName;
            var msg = SendMessageTools.UploadRequest(new FileInfo(filePath), false);
            socketConnection.Send(msg);
            socketConnection.Log.Info("Upload Requested");
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (socketConnection == null || !socketConnection.IsAlive)
            {
                MessageBox.Show("ارتباط با سرور بله قطع است");
                return;
            }

            if (LastUser == null)
            {
                MessageBox.Show("کاربری یافت نشد. ابتدا یک پیام به بات ارسال کنید");
                return;
            }

            if (selectPhoto.ShowDialog() != DialogResult.OK)
                return;

            var filePath = selectPhoto.FileName;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("فایل به درستی انتخاب نشده است");
                return;
            }

            var msg = SendMessageTools.UploadRequest(new FileInfo(filePath), true);
            socketConnection.Send(msg);
            socketConnection.Log.Info("Upload Requested");
        }
    }
}
