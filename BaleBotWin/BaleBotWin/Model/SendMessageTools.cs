using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Force.Crc32;
using Newtonsoft.Json;
using WebSocketSharp;

namespace BaleBotWin.Model
{
    public class SendMessageTools
    {
        public static string GetTextMessage(string message, Peer peer)
        {
            var obj = new SendMessage<Message>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<Message>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = new Message() { type = "Text", text = message },
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// محاسبه چک سام
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CalculateCrc(byte[] data)
        {
            return Crc32Algorithm.Compute(data).ToString();
        }

        public static string GetDocumentMessage(SendDocument document, Peer peer)
        {
            var obj = new SendMessage<SendDocument>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendDocument>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = document,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        public static string UploadRequest(FileInfo fileInfo, bool isPhoto)
        {
            var fileData = File.ReadAllBytes(fileInfo.FullName);
            var fileName = fileInfo.Name;

            var id = DateTime.Now.Ticks;
            var crc = CalculateCrc(fileData);
            var saveCacheFolder = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".cache";
            var saveCrcFolder = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".crc";
            var infoFolder = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".info";

            File.WriteAllBytes(saveCacheFolder, fileData);
            File.WriteAllText(saveCrcFolder, crc);
            File.WriteAllText(infoFolder, fileName);

            var request = new UploadRequest()
            {
                Body = new UploadRequestBody()
                {
                    Crc = crc,
                    Type = "GetFileUploadUrl",
                    FileType = isPhoto ? "photo" : "file",
                    IsServer = false,
                    Size = fileData.Length
                },
                Id = id,
                Service = "files",
                Type = "Request"
            };

            return JsonConvert.SerializeObject(request);
        }

        public static bool UploadFile(long id, string uploadUrl, WebSocket ws, out string fileName, out long fileSize)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".cache";
            var crcPath = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".crc";
            var infoPath = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".info";

            fileName = string.Empty;
            fileSize = 0;

            if (!File.Exists(filePath))
            {
                ws.Log.Info("FileID not found: " + id);
                return false;
            }

            try
            {
                ws.Log.Info("Upload File");
                ws.Log.Info(uploadUrl);

                var fileData = File.ReadAllBytes(filePath);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "PUT";
                request.Headers.Add("filesize", fileData.Length.ToString());

                ws.Log.Info("LocalFile CRC: " + File.ReadAllText(crcPath));
                ws.Log.Info("LocalFile Size: " + fileData.Length + " byte");

                fileSize = fileData.Length;
                fileName = File.ReadAllText(infoPath);

                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(fileData, 0, fileData.Length);
                    writer.Close();
                }

                var response = (HttpWebResponse)request.GetResponse();
                ws.Log.Info("Upload Response:");
                foreach (string header in response.Headers)
                {
                    ws.Log.Info(string.Format("--{0}\t{1}", header, response.Headers[header]));
                }
                ws.Log.Info("Upload Status: " + response.StatusCode.ToString());

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                ws.Log.Error("Upload ERROR");
                ws.Log.Error(ex.Message);
            }

            return false;
        }
    }
}