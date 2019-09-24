namespace EnquiryResponse
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public partial class Welcome
    {
        [JsonProperty("ChildNodes")]
        public object ChildNodes { get; set; }

        [JsonProperty("Children")]
        public object Children { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("SubKey")]
        public SubKey SubKey { get; set; }

        [JsonProperty("IsContainerNode")]
        public bool IsContainerNode { get; set; }

        [JsonProperty("RawValue")]
        public string RawValue { get; set; }

        [JsonProperty("AttemptedValue")]
        public string AttemptedValue { get; set; }

        [JsonProperty("Errors")]
        public object[] Errors { get; set; }

        [JsonProperty("ValidationState")]
        public long ValidationState { get; set; }
    }

    public partial class SubKey
    {
        [JsonProperty("Buffer")]
        public string Buffer { get; set; }

        [JsonProperty("Offset")]
        public long Offset { get; set; }

        [JsonProperty("Length")]
        public long Length { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("HasValue")]
        public bool HasValue { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome[] FromJson(string json) => JsonConvert.DeserializeObject<Welcome[]>(json, EnquiryResponse.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome[] self) => JsonConvert.SerializeObject(self, EnquiryResponse.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
