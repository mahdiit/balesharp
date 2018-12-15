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

        private SendPhoto LastPhoto;

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

        private static bool isFirstMessage = true;

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

                        if (isFirstMessage)
                        {
                            isFirstMessage = false;
                            var welcomeSticker = SendMessageTools.GetStickerMessage(new SendSticker()
                            {
                                Type = "Sticker",
                                FastPreview = null,
                                Image256 = new Model.Image()
                                {
                                    FileLocation = new FileLocation()
                                    {
                                        FileStorageVersion = 1,
                                        AccessHash = "549755813890",
                                        FileId = "7415072606480367873"
                                    },
                                    Height = 256,
                                    Width = 256,
                                    FileSize = 4924
                                },
                                Image512 = new Model.Image()
                                {
                                    FileLocation = new FileLocation()
                                    {
                                        FileStorageVersion = 1,
                                        AccessHash = "549755813890",
                                        FileId = "-8656471477048966910"
                                    },
                                    Height = 512,
                                    Width = 512,
                                    FileSize = 11356
                                },
                                StickerCollectionId = 265723345,
                                StickerCollectionAccessHash = "-8925386374726878396",
                                StickerId = 1345218
                            }, LastUser);


                            //var welcomeSticker = SendMessageTools.GetStickerMessage(new SendSticker()
                            //{
                            //    Type = "Sticker",
                            //    FastPreview = null,
                            //    Image256 = new Model.Image()
                            //    {
                            //        FileLocation = new FileLocation()
                            //        {
                            //            FileStorageVersion = 1,
                            //            AccessHash = "1884281475",
                            //            FileId = "5894772107577788931"
                            //        },
                            //        Height = 256,
                            //        Width = 256,
                            //        FileSize = 4924
                            //    },
                            //    Image512 = new Model.Image()
                            //    {
                            //        FileLocation = new FileLocation()
                            //        {
                            //            FileStorageVersion = 1,
                            //            AccessHash = "1884281475",
                            //            FileId = "5894772107577788931"
                            //        },
                            //        Height = 512,
                            //        Width = 512,
                            //        FileSize = 11356
                            //    },
                            //    StickerCollectionId = 265723345,
                            //    StickerCollectionAccessHash = "-8925386374726878396",
                            //    StickerId = 1345218
                            //}, LastUser);

                            socketConnection.Send(welcomeSticker);
                        }
                    }
                    else
                    {
                        var msgType = baleObject["body"]["message"]["$type"].Value<string>();
                        if (msgType == "TemplateMessageResponse")
                        {
                            //این دستور از یک دکمه اومده
                            var textMessage = baleObject["body"]["message"]["textMessage"].Value<string>();
                            txtRec.Text += msgType + "\tBTN:" + textMessage + "\r\n";
                        }
                        else if (baleObject["body"]["message"]["mimeType"] != null)
                        {
                            //این پیام حاوی فایل یا سند یا عکس است
                            var mimeType = baleObject["body"]["message"]["mimeType"].Value<string>();
                            txtRec.Text += msgType + "\t" + mimeType + "\r\n";
                        }
                        else
                            txtRec.Text += msgType;
                    }
                }

                if (mainType == "Response")
                {
                    if (baleObject["body"]["url"] != null)
                    {
                        //دریافت پاسخ برای آپلود فایل و ارسال فایل
                        var id = baleObject["id"].Value<long>();
                        var receivedUrl = baleObject["body"]["url"].Value<string>();

                        if (SendMessageTools.IsDownloadPending(id))
                        {
                            var fileName = SendMessageTools.GetDownloadFilename(id);
                            var dlUrl = receivedUrl + "?filename=" + fileName;
                            socketConnection.Log.Info("Download File");
                            socketConnection.Log.Info(dlUrl);
                            SendMessageTools.DownloadFile(dlUrl, socketConnection, fileName);
                            SendMessageTools.DeleteDownload(id);
                        }
                        else if (SendMessageTools.IsUploadPending(id))
                        {
                            FileCache.FileInfoModel fileInfoModel;
                            if (SendMessageTools.UploadFile(id, receivedUrl, socketConnection, out fileInfoModel))
                            {
                                //send Info
                                var fileId = baleObject["body"]["fileId"].Value<string>();
                                var hash = baleObject["body"]["userId"].Value<long>();

                                string msg = null;

                                //تشخیص ارسال عکس
                                if (fileInfoModel.UploadType == UploadTypeEnum.Document)
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
                                        FileSize = fileInfoModel.Size,
                                        FileStorageVersion = 1,
                                        MimeType = "application/document",
                                        Name = fileInfoModel.Name,
                                        Thumb = null
                                    }, LastUser);
                                }
                                else if (fileInfoModel.UploadType == UploadTypeEnum.Photo)
                                {
                                    LastPhoto = new SendPhoto()
                                    {
                                        Type = "Document",
                                        AccessHash = hash,
                                        Algorithm = "algorithm",
                                        CheckSum = "checkSum",
                                        Caption = new Caption() { Text = txtPayam.Text, Type = "Text" },
                                        FileId = fileId,
                                        FileSize = fileInfoModel.Size,
                                        FileStorageVersion = 1,
                                        Name = fileInfoModel.Name,
                                        MimeType = "image/jpeg",
                                        Ext = new Ext()
                                        {
                                            Type = "Photo",
                                            Width = fileInfoModel.Width,
                                            Height = fileInfoModel.Height
                                        },
                                        Thumb = new Thumb()
                                        {
                                            ThumbThumb = "None",
                                            Width = fileInfoModel.Width,
                                            Height = fileInfoModel.Height
                                        }
                                    };
                                    msg = SendMessageTools.GetPhotoMessage(LastPhoto, LastUser);
                                }
                                else if (fileInfoModel.UploadType == UploadTypeEnum.Voice)
                                {
                                    msg = SendMessageTools.GetSendVoice(new SendVoice()
                                    {
                                        Type = "Document",
                                        AccessHash = hash,
                                        Algorithm = "algorithm",
                                        CheckSum = "checkSum",
                                        Caption = new Caption() { Text = txtPayam.Text, Type = "Text" },
                                        FileId = fileId,
                                        FileSize = fileInfoModel.Size,
                                        FileStorageVersion = 1,
                                        Name = fileInfoModel.Name,
                                        MimeType = "audio/mp3",
                                        Ext = new Ext()
                                        {
                                            Type = "Voice",
                                            Duration = (int)(Convert.ToDouble(fileInfoModel.Duration) * 1000)
                                        }
                                    }, LastUser);
                                }

                                if (msg != null)
                                    socketConnection.Send(msg);

                                SendMessageTools.DeleteCacheUpload(id);
                            }
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

            if (MessageBox.Show("Save Last Log?", "Save Log Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LastLogData-" +
                    DateTime.Now.ToString("yyMMdd-HHmmss") + ".txt", logData.Text);
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
            var msg = SendMessageTools.UploadRequest(new FileInfo(filePath), UploadTypeEnum.Document);
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
            var msg = SendMessageTools.UploadRequest(new FileInfo(filePath), UploadTypeEnum.Photo);
            socketConnection.Send(msg);
            socketConnection.Log.Info("Upload Requested");
        }

        private void btnTemplate_Click(object sender, EventArgs e)
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

            var msg = SendMessageTools.GetTemplateMessage(new SendTemplate()
            {
                Type = "TemplateMessage",
                GeneralMessage = new GeneralMessage() { Type = "Text", Text = txtPayam.Text },
                TemplateMessageId = 0,
                BtnList = new List<BtnList>()
                {
                    new BtnList()
                    {
                        Text = "A1",
                        Value = "A-1",
                        Action = 0
                    },
                    new BtnList()
                    {
                        Text = "A2",
                        Value = "A-2",
                        Action = 1
                    }
                }
            }, LastUser);

            socketConnection.Send(msg);
        }

        private void btnMoney_Click(object sender, EventArgs e)
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

            if (LastPhoto == null)
            {
                MessageBox.Show("ابتدا باید یک عکس بفرستین فکر کردی همین جوریه!!!\r\nشوخی کردم تو راهنمای ارسال عکس برای پول اجباریه");
                MessageBox.Show("منم نمی دونم چرا ولی باید اول عکس بفرستی");
                return;
            }

            var msg = SendMessageTools.GetMoneyMessage(new SendMeMoney()
            {
                Type = "PurchaseMessage",
                AccountNumber = "6362144502059848",
                Amount = 50000,
                RegexAmount = "[]",
                MoneyRequestType = new MoneyRequestType() { Type = "MoneyRequestNormal" },
                Msg = LastPhoto
            }, LastUser);

            socketConnection.Send(msg);
        }

        private void btnVoice_Click(object sender, EventArgs e)
        {
            var mediaInfoExe = AppDomain.CurrentDomain.BaseDirectory + "BinTools\\MediaInfoMeta\\MediaInfo.exe";
            if (!File.Exists(mediaInfoExe))
            {
                MessageBox.Show("فایل MediaInfo.exe یافت نشد از سایت دانلود و در پوشه \r\nBinTools\\MediaInfoMeta\r\nقرار دهید\r\nhttps://mediaarea.net/en/MediaInfo/Download/Windows");
                return;
            }


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

            if (openOggAudio.ShowDialog() != DialogResult.OK)
                return;

            var filePath = openOggAudio.FileName;
            var msg = SendMessageTools.UploadRequest(new FileInfo(filePath), UploadTypeEnum.Voice);
            socketConnection.Send(msg);
            socketConnection.Log.Info("Upload Requested");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var dl = new DlFile(socketConnection);
            dl.ShowDialog();
        }
    }
}
