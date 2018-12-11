using System;
using BaleBotWin.Model;
using Newtonsoft.Json;

namespace BaleBotWin.BinTools.MediaInfoMeta.Model
{
    public partial class Track
    {
        [JsonProperty("@type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("AudioCount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? AudioCount { get; set; }

        [JsonProperty("FileExtension", NullValueHandling = NullValueHandling.Ignore)]
        public string FileExtension { get; set; }

        [JsonProperty("Format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty("FileSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FileSize { get; set; }

        [JsonProperty("Duration", NullValueHandling = NullValueHandling.Ignore)]
        public string Duration { get; set; }

        [JsonProperty("OverallBitRate_Mode", NullValueHandling = NullValueHandling.Ignore)]
        public string OverallBitRateMode { get; set; }

        [JsonProperty("OverallBitRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? OverallBitRate { get; set; }

        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("Album", NullValueHandling = NullValueHandling.Ignore)]
        public string Album { get; set; }

        [JsonProperty("Track", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackTrack { get; set; }

        [JsonProperty("Performer", NullValueHandling = NullValueHandling.Ignore)]
        public string Performer { get; set; }

        [JsonProperty("Genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty("File_Created_Date", NullValueHandling = NullValueHandling.Ignore)]
        public string FileCreatedDate { get; set; }

        [JsonProperty("File_Created_Date_Local", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FileCreatedDateLocal { get; set; }

        [JsonProperty("File_Modified_Date", NullValueHandling = NullValueHandling.Ignore)]
        public string FileModifiedDate { get; set; }

        [JsonProperty("File_Modified_Date_Local", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FileModifiedDateLocal { get; set; }

        [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }

        [JsonProperty("Format_Settings_Floor", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FormatSettingsFloor { get; set; }

        [JsonProperty("BitRate_Mode", NullValueHandling = NullValueHandling.Ignore)]
        public string BitRateMode { get; set; }

        [JsonProperty("BitRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? BitRate { get; set; }

        [JsonProperty("Channels", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Channels { get; set; }

        [JsonProperty("SamplingRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SamplingRate { get; set; }

        [JsonProperty("SamplingCount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SamplingCount { get; set; }

        [JsonProperty("Compression_Mode", NullValueHandling = NullValueHandling.Ignore)]
        public string CompressionMode { get; set; }

        [JsonProperty("StreamSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? StreamSize { get; set; }

        [JsonProperty("Encoded_Library", NullValueHandling = NullValueHandling.Ignore)]
        public string EncodedLibrary { get; set; }

        [JsonProperty("Encoded_Library_Name", NullValueHandling = NullValueHandling.Ignore)]
        public string EncodedLibraryName { get; set; }

        [JsonProperty("Encoded_Library_Version", NullValueHandling = NullValueHandling.Ignore)]
        public string EncodedLibraryVersion { get; set; }

        [JsonProperty("Encoded_Library_Date", NullValueHandling = NullValueHandling.Ignore)]
        public string EncodedLibraryDate { get; set; }
    }
}