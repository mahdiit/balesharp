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
    
    public partial class Track
    {
        [JsonProperty("VideoCount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? VideoCount { get; set; }
        
        [JsonProperty("Format_Profile", NullValueHandling = NullValueHandling.Ignore)]
        public string FormatProfile { get; set; }

        [JsonProperty("CodecID", NullValueHandling = NullValueHandling.Ignore)]
        public string CodecId { get; set; }

        [JsonProperty("CodecID_Compatible", NullValueHandling = NullValueHandling.Ignore)]
        public string CodecIdCompatible { get; set; }

        [JsonProperty("FrameRate", NullValueHandling = NullValueHandling.Ignore)]
        public string FrameRate { get; set; }

        [JsonProperty("FrameCount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FrameCount { get; set; }

        [JsonProperty("HeaderSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? HeaderSize { get; set; }

        [JsonProperty("DataSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? DataSize { get; set; }

        [JsonProperty("FooterSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FooterSize { get; set; }

        [JsonProperty("IsStreamable", NullValueHandling = NullValueHandling.Ignore)]
        public string IsStreamable { get; set; }

        [JsonProperty("Encoded_Application", NullValueHandling = NullValueHandling.Ignore)]
        public string EncodedApplication { get; set; }

        [JsonProperty("StreamOrder", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? StreamOrder { get; set; }

        [JsonProperty("Format_Level", NullValueHandling = NullValueHandling.Ignore)]
        public string FormatLevel { get; set; }

        [JsonProperty("Format_Settings_CABAC", NullValueHandling = NullValueHandling.Ignore)]
        public string FormatSettingsCabac { get; set; }

        [JsonProperty("Format_Settings_RefFrames", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FormatSettingsRefFrames { get; set; }

        [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Width { get; set; }

        [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Height { get; set; }

        [JsonProperty("Sampled_Width", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SampledWidth { get; set; }

        [JsonProperty("Sampled_Height", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SampledHeight { get; set; }

        [JsonProperty("PixelAspectRatio", NullValueHandling = NullValueHandling.Ignore)]
        public string PixelAspectRatio { get; set; }

        [JsonProperty("DisplayAspectRatio", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayAspectRatio { get; set; }

        [JsonProperty("DisplayAspectRatio_Original", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayAspectRatioOriginal { get; set; }

        [JsonProperty("Rotation", NullValueHandling = NullValueHandling.Ignore)]
        public string Rotation { get; set; }

        [JsonProperty("FrameRate_Mode", NullValueHandling = NullValueHandling.Ignore)]
        public string FrameRateMode { get; set; }

        [JsonProperty("FrameRate_Minimum", NullValueHandling = NullValueHandling.Ignore)]
        public string FrameRateMinimum { get; set; }

        [JsonProperty("FrameRate_Maximum", NullValueHandling = NullValueHandling.Ignore)]
        public string FrameRateMaximum { get; set; }

        [JsonProperty("ColorSpace", NullValueHandling = NullValueHandling.Ignore)]
        public string ColorSpace { get; set; }

        [JsonProperty("ChromaSubsampling", NullValueHandling = NullValueHandling.Ignore)]
        public string ChromaSubsampling { get; set; }

        [JsonProperty("BitDepth", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? BitDepth { get; set; }

        [JsonProperty("ScanType", NullValueHandling = NullValueHandling.Ignore)]
        public string ScanType { get; set; }

        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        public Extra Extra { get; set; }

        [JsonProperty("Format_AdditionalFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public string FormatAdditionalFeatures { get; set; }

        [JsonProperty("ChannelPositions", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelPositions { get; set; }

        [JsonProperty("ChannelLayout", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelLayout { get; set; }

        [JsonProperty("SamplesPerFrame", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SamplesPerFrame { get; set; }

        [JsonProperty("StreamSize_Proportion", NullValueHandling = NullValueHandling.Ignore)]
        public string StreamSizeProportion { get; set; }

        [JsonProperty("Default", NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; }

        [JsonProperty("AlternateGroup", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? AlternateGroup { get; set; }
    }

    public partial class Extra
    {
        [JsonProperty("Codec_configuration_box", NullValueHandling = NullValueHandling.Ignore)]
        public string CodecConfigurationBox { get; set; }
    }
}