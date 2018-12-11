using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaleBotWin.Model;

namespace BaleBotWin.FileCache
{
    public class FileInfoModel
    {
        public string Crc { get; set; }
        public string Name { get; set; }
        public UploadTypeEnum UploadType { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Duration { get; set; }
        public int Size { get; set; }
    }
}
