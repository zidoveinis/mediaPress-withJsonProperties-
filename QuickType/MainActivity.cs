using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace QuickType
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebClient wc = new WebClient();
        Welcome obj, obj2;
        string StrReaded, StrReaded2;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            rez2();
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");

        }
        public void rez2()
        {
            
            wc.Credentials = new NetworkCredential("robertas", "robertas-2018-05!16");
            string url2 = "http://json.xprsdata.com/get_listings.php?channel=245&updatesFROM=1526428800";
            Stream stream2 = wc.OpenRead(new Uri(url2));
            {

                StreamReader reader2 = new StreamReader(stream2);
                {
                    StrReaded2 = reader2.ReadToEnd();
                    JObject jobject2 = JObject.Parse(StrReaded2);
                    StrReaded = StrReaded2;

                    obj2 = JsonConvert.DeserializeObject<Welcome>(StrReaded2);
                    foreach (var item in obj2.Data)
                    {
                        if (item.Description != null)
                        Console.WriteLine("Channel id:{0}, Channel name: {1}", item.Description.The131.Value, item.SysModified.DayOfWeek);
                        else if (item.Description == null)
                        {
                            Console.WriteLine("The Json not content Description key");
                        }
                    }

                }
            }
        }
    }
     public partial class Welcome
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("log")]
        public Log[] Log { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("category")]
        public Dictionary<string, Category> Category { get; set; }

        [JsonProperty("prodyear", NullValueHandling = NullValueHandling.Ignore)]
        public string Prodyear { get; set; }

        [JsonProperty("time_start")]
        public DateTimeOffset TimeStart { get; set; }

        [JsonProperty("time_stop")]
        public DateTimeOffset TimeStop { get; set; }

        [JsonProperty("unix_start")]
        public string UnixStart { get; set; }

        [JsonProperty("unix_stop")]
        public string UnixStop { get; set; }

      

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public Description Description { get; set; }

        [JsonProperty("sys_status")]
        public SysStatus SysStatus { get; set; }

        [JsonProperty("sys_modified")]
        public DateTimeOffset SysModified { get; set; }

        [JsonProperty("ep_nr", NullValueHandling = NullValueHandling.Ignore)]
        public string EpNr { get; set; }

        [JsonProperty("season", NullValueHandling = NullValueHandling.Ignore)]
        public string Season { get; set; }
    }

    public partial class Category
    {
     //   [JsonProperty("title")]
     //   public Title Title { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("122")]
        public The122 The122 { get; set; }
        [JsonProperty("111")]
        public The122 The111 { get; set; }
        [JsonProperty("131")]
        public The122 The131 { get; set; }
        [JsonProperty("126")]
        public The122 The126 { get; set; }
    }

    public partial class The122
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public partial class The111
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public partial class The131
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public partial class The126
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class SysStatus
    {
        [JsonProperty("1")]
        public The1 The1 { get; set; }
    }

    public partial class Log
    {
        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("success")]
        public long Success { get; set; }

        [JsonProperty("rows")]
        public long Rows { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }

    public enum Title { AutomotiveTraffic, Culture, CurrentAffairs, Documentary, Entertainment, GameShow, Humor, Kids, Movies, News, Politics, RealityShow, Series, Sports, TalkShow, Travel };

    public enum Lang { Lit, Rus, Eng, Pol };

    public enum The1 { Active };

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new TitleConverter(),
                new LangConverter(),
                new The1Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TitleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Title) || t == typeof(Title?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Automotive/Traffic":
                    return Title.AutomotiveTraffic;
                case "Culture":
                    return Title.Culture;
                case "Current Affairs":
                    return Title.CurrentAffairs;
                case "Documentary":
                    return Title.Documentary;
                case "Entertainment":
                    return Title.Entertainment;
                case "Game Show":
                    return Title.GameShow;
                case "Humor":
                    return Title.Humor;
                case "Kids":
                    return Title.Kids;
                case "Movies":
                    return Title.Movies;
                case "News":
                    return Title.News;
                case "Politics":
                    return Title.Politics;
                case "Reality show":
                    return Title.RealityShow;
                case "Series":
                    return Title.Series;
                case "Sports":
                    return Title.Sports;
                case "Talk Show":
                    return Title.TalkShow;
                case "Travel":
                    return Title.Travel;
            }
            throw new Exception("Cannot unmarshal type Title");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Title)untypedValue;
            switch (value)
            {
                case Title.AutomotiveTraffic:
                    serializer.Serialize(writer, "Automotive/Traffic"); return;
                case Title.Culture:
                    serializer.Serialize(writer, "Culture"); return;
                case Title.CurrentAffairs:
                    serializer.Serialize(writer, "Current Affairs"); return;
                case Title.Documentary:
                    serializer.Serialize(writer, "Documentary"); return;
                case Title.Entertainment:
                    serializer.Serialize(writer, "Entertainment"); return;
                case Title.GameShow:
                    serializer.Serialize(writer, "Game Show"); return;
                case Title.Humor:
                    serializer.Serialize(writer, "Humor"); return;
                case Title.Kids:
                    serializer.Serialize(writer, "Kids"); return;
                case Title.Movies:
                    serializer.Serialize(writer, "Movies"); return;
                case Title.News:
                    serializer.Serialize(writer, "News"); return;
                case Title.Politics:
                    serializer.Serialize(writer, "Politics"); return;
                case Title.RealityShow:
                    serializer.Serialize(writer, "Reality show"); return;
                case Title.Series:
                    serializer.Serialize(writer, "Series"); return;
                case Title.Sports:
                    serializer.Serialize(writer, "Sports"); return;
                case Title.TalkShow:
                    serializer.Serialize(writer, "Talk Show"); return;
                case Title.Travel:
                    serializer.Serialize(writer, "Travel"); return;
            }
            throw new Exception("Cannot marshal type Title");
        }
    }

    internal class LangConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Lang) || t == typeof(Lang?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "lit")
            {
                return Lang.Lit;
            }
            else if (value == "Rus")
            {
                return Lang.Rus;
            }
            else if (value == "Eng")
            {
                return Lang.Eng;
            }
            else if (value == "Pol")
            {
                return Lang.Pol;
            }


            throw new Exception("Cannot unmarshal type Lang");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Lang)untypedValue;
            if (value == Lang.Lit)
            {
                serializer.Serialize(writer, "lit"); return;
            }
            else if (value == Lang.Rus)
            {
                serializer.Serialize(writer, "rus"); return;
            }
            else if (value == Lang.Eng)
            {
                serializer.Serialize(writer, "eng"); return;
            }
            else if (value == Lang.Pol)
            {
                serializer.Serialize(writer, "pol"); return;
            }
            throw new Exception("Cannot marshal type Lang");
        }
    }

    internal class The1Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(The1) || t == typeof(The1?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Active")
            {
                return The1.Active;
            }
            throw new Exception("Cannot unmarshal type The1");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (The1)untypedValue;
            if (value == The1.Active)
            {
                serializer.Serialize(writer, "Active"); return;
            }
            throw new Exception("Cannot marshal type The1");
        }
    }


}

