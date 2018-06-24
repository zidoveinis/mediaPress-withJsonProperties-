using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;


namespace QuickType
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public string content;
        public ListView mlistView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.activity_main);
            //TextView tv = (TextView)FindViewById(Resource.Id.TextFirstname);
         


            JsonGetter json = new JsonGetter();
            json.GetJson();
            // tv.Text = json.labas+ "\r\n" + json.labas;
            // tv.Text = json.labas;
          
            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            //  var view = LayoutInflater.Inflate(Resource.Layout.TextFirstname, null, false);
            mlistView = FindViewById<ListView>(Resource.Id.mylistView);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, json.list);
            mlistView.Adapter = adapter;


            saveButton.Click += delegate
            {

                File.Delete(json.filename);
                using (var streamWriter = new StreamWriter(json.filename, true))
                {
                    streamWriter.WriteLine(json.StrReaded);
                    streamWriter.Dispose();
                    try
                    {
                        RunOnUiThread(() => Toast.MakeText(this, "File saved", ToastLength.Long).Show());
                    }
                    catch (Exception e)
                    {
                        RunOnUiThread(() => Toast.MakeText(this, "Failed to save file  ", ToastLength.Long).Show());
                    }
                }
            };
        }
        public void Rewrite()
        {
            JsonGetter j = new JsonGetter();
            j.GetJson();
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

    public partial class SysStatus
    {
        [JsonProperty("1")]
        public string The1 { get; set; }
        [JsonProperty("2")]
        public string The2 { get; set; }
   
    }
    public partial class Description
    {
        [JsonProperty("122")]
        public The122 The122 { get; set; }
        [JsonProperty("111")]
        public The111 The111 { get; set; }
        [JsonProperty("131")]
        public The131 The131 { get; set; }
        [JsonProperty("126")]
        public The126 The126 { get; set; }
        [JsonProperty("112")]
        public The126 The112 { get; set; }
        [JsonProperty("121")]
        public The126 The121 { get; set; }
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
    public partial class The112
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public partial class The121
    {
        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
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

    public enum Title {Adult, Concert, Cooking, Crime, Environment, Health, History, HomeImprovement, Music, Nature, Pets, Radio, Religious, Rurallife, Science, TeleShop, Theatre,  AutomotiveTraffic, Culture, CurrentAffairs, Documentary, Entertainment, GameShow, Humor, Kids, Movies, News, Politics, RealityShow, Series, Sports, TalkShow, Travel };

    public enum Lang { Lit, Rus, Eng, Pol, Est, Lat };





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
             //   new SysStatusConverter.Singleton,
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
            var value2 = serializer.Deserialize<string>(reader);

          
            switch (value)
            {
                case "Automotive/Traffic":
                    return Title.AutomotiveTraffic;
                case "Adult":
                    return Title.Adult;
                case "Concert":
                    return Title.Concert;
                case "Cooking":
                    return Title.Cooking;
                case "Crime":
                    return Title.Crime;
                case "Environment":
                    return Title.Entertainment;
                case "Health":
                    return Title.Health;
                case "History":
                    return Title.History;
                case "Home Improvement":
                    return Title.HomeImprovement;
                case "Music":
                    return Title.Music;
                case "Nature":
                    return Title.Nature;
                case "Pets":
                    return Title.Pets;
                case "Radio":
                    return Title.Radio;
                case "Religious":
                    return Title.Religious;
                case "Rural life":
                    return Title.Rurallife;
                case "Science":
                    return Title.Science;
                case "Teleshop":
                    return Title.TeleShop;
                case "Theatre":
                    return Title.Theatre;
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
                case Title.Adult:
                    serializer.Serialize(writer, "Adult");
                    return;
                case Title.Concert:
                    serializer.Serialize(writer, "Concert");
                    return;
                case Title.Cooking:
                    serializer.Serialize(writer, "Concert");
                    return;
                case Title.Crime:
                    serializer.Serialize(writer, "Crime");
                    return;
                case Title.Environment:
                    serializer.Serialize(writer, "Environment");
                    return;
                case Title.Health:
                    serializer.Serialize(writer, "Health");
                    return;
                case Title.History:
                    serializer.Serialize(writer, "History");
                    return;
                case Title.HomeImprovement:
                    serializer.Serialize(writer, "Home Improvement");
                    return;
                case Title.Music:
                    serializer.Serialize(writer, "Music");
                    return;
                case Title.Nature:
                    serializer.Serialize(writer, "Nature");
                    return;
                case Title.Pets:
                    serializer.Serialize(writer, "Pets");
                    return;
                case Title.Radio:
                    serializer.Serialize(writer, "Radio");
                    return;
                case Title.Religious:
                    serializer.Serialize(writer, "Religious");
                    return;
                case Title.Rurallife:
                    serializer.Serialize(writer, "Rural Life");
                    return;
                case Title.Science:
                    serializer.Serialize(writer, "Science");
                    return;
                case Title.TeleShop:
                    serializer.Serialize(writer, "TeleShop");
                    return;
                case Title.Theatre:
                    serializer.Serialize(writer, "Theatre");
                    return;

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
            else if (value == "Est")
            {
                return Lang.Est;
            }
            else if (value == "Lat")
            {
                return Lang.Lat;
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
            else if (value == Lang.Est)
            {
                serializer.Serialize(writer, "est"); return;
            }
            else if (value == Lang.Lat)
            {
                serializer.Serialize(writer, "lat"); return;
            }
            throw new Exception("Cannot marshal type Lang");
        }
    }
    //public static readonly SysStatusConverter Singleton = new SysStatusConverter();








}

