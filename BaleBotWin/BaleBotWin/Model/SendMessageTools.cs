﻿using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using BaleBotWin.BinTools.MediaInfoMeta.Model;
using BaleBotWin.FileCache;
using CliWrap;
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

        public static string GetPhotoMessage(SendPhoto photo, Peer peer)
        {
            var obj = new SendMessage<SendPhoto>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendPhoto>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = photo,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        public static string UploadRequest(FileInfo fileInfo, UploadTypeEnum uploadType)
        {
            var fileData = File.ReadAllBytes(fileInfo.FullName);
            var fileName = fileInfo.Name;

            var id = DateTime.Now.Ticks;
            var crc = CalculateCrc(fileData);

            var cacheInfo = new FileInfoModel() { Crc = crc, Name = fileName, UploadType = uploadType, Size = fileData.Length };

            var cacheFile = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".cache";
            var infoFile = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".info";


            var isPhoto = uploadType == UploadTypeEnum.Photo || uploadType == UploadTypeEnum.MoneyPhoto;

            if (isPhoto)
            {
                using (var img = System.Drawing.Image.FromFile(fileInfo.FullName))
                {
                    cacheInfo.Width = img.Width;
                    cacheInfo.Height = img.Height;
                }
            }

            if (uploadType == UploadTypeEnum.Voice)
            {
                var result = new Cli(AppDomain.CurrentDomain.BaseDirectory + "BinTools\\MediaInfoMeta\\MediaInfo.exe")
                    .SetArguments("\"" + fileInfo.FullName + "\" --Output=JSON")
                    .Execute();

                var jsonResult = JsonConvert.DeserializeObject<AudioMediaInfo>(result.StandardOutput);
                cacheInfo.Duration = jsonResult.Media.Track[0].Duration;
            }

            File.WriteAllBytes(cacheFile, fileData);
            File.WriteAllText(infoFile, JsonConvert.SerializeObject(cacheInfo));

            var request = new FileRequest<UploadRequestBody>()
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

        public static bool UploadFile(long id, string uploadUrl, WebSocket ws, out FileCache.FileInfoModel fileInfoModel)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".cache";
            var infoPath = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".info";

            fileInfoModel = null;

            if (!File.Exists(filePath))
            {
                ws.Log.Info("FileID not found: " + id);
                return false;
            }

            fileInfoModel = JsonConvert.DeserializeObject<FileInfoModel>(File.ReadAllText(infoPath));

            try
            {
                ws.Log.Info("Upload File");
                ws.Log.Info(uploadUrl);

                var fileData = File.ReadAllBytes(filePath);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "PUT";
                request.Headers.Add("filesize", fileData.Length.ToString());

                ws.Log.Info("LocalFile CRC: " + fileInfoModel.Crc);
                ws.Log.Info("LocalFile Size: " + fileData.Length + " byte");

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

        public static void DeleteCacheUpload(long id)
        {
            var saveCacheFolder = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".cache";
            var infoFolder = AppDomain.CurrentDomain.BaseDirectory + "FileCache\\" + id + ".info";

            File.Delete(saveCacheFolder);
            File.Delete(infoFolder);
        }

        public static string GetTemplateMessage(SendTemplate template, Peer peer)
        {
            var obj = new SendMessage<SendTemplate>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendTemplate>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = template,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        public static string GetMoneyMessage(SendMeMoney sendMeMoney, Peer peer)
        {
            var obj = new SendMessage<SendMeMoney>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendMeMoney>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = sendMeMoney,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        public static string GetSendVoice(SendVoice sendVoice, Peer peer)
        {
            var obj = new SendMessage<SendVoice>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendVoice>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = sendVoice,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        public static string GetStickerMessage(SendSticker sendSticker, Peer peer)
        {
            var obj = new SendMessage<SendSticker>()
            {
                service = "messaging",
                type = "Request",
                id = "0",
                body = new Body<SendSticker>()
                {
                    type = "SendMessage",
                    randomId = DateTime.Now.Ticks.ToString(),
                    quotedMessage = null,
                    message = sendSticker,
                    peer = peer
                }
            };

            return JsonConvert.SerializeObject(obj);
        }
    }
}