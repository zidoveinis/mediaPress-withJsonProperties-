﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuickType
{
   public class JsonGetter : MainActivity
    {
        WebClient wc = new WebClient();
        Welcome obj, obj2;
        public List<string> list = new List<string>();
        public string StrReaded,labas , StrReaded2, filename, ate;
        public ListView mlistView;

        public void GetJson()
        {

            wc.Credentials = new NetworkCredential("robertas", "robertas-2018-05!16");
            string url2 = "http://json.xprsdata.com/get_listings.php?channel=87&updatesFROM=1526428800";
            Stream stream2 = wc.OpenRead(new Uri(url2));
            {

                StreamReader reader2 = new StreamReader(stream2);
                {
                    StrReaded2 = reader2.ReadToEnd();
                    JObject jobject2 = JObject.Parse(StrReaded2);
                    StrReaded = StrReaded2;
                    JObject jobject = JObject.Parse(StrReaded);

                    string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                    filename = Path.Combine(path, "myfile.txt");
                   // File.Delete(filename);




                    //if (filename ==nuLL )
                    //{
                    //    var streamWriter = new StreamWriter(filename, true);
                    //    {

                    //        streamWriter.WriteLine(StrReaded2);
                    //        streamWriter.Dispose();
                    //    }

                    //}

                    try
                    {
                        var streamReader = new StreamReader(filename);
                        {

                            content = streamReader.ReadToEnd();
                            System.Diagnostics.Debug.WriteLine(content);
                        }
                    }
                    catch (Exception e)
                    {
                        var streamWriter = new StreamWriter(filename, true);
                        {

                            streamWriter.WriteLine(StrReaded2);
                            streamWriter.Dispose();
                        }
                        var streamReader = new StreamReader(filename);
                        {

                            content = streamReader.ReadToEnd();
                            System.Diagnostics.Debug.WriteLine(content);
                        }

                    }
                    obj = JsonConvert.DeserializeObject<Welcome>(StrReaded);
                    obj2 = JsonConvert.DeserializeObject<Welcome>(content);

                    var col = obj.Data.Zip(obj2.Data, (x, y) => new { X = x, Y = y });
                    foreach (var entry in col)
                    {
                        //if (entry.X.SysStatus.The2 == entry.Y.SysStatus.The2)
                        //{
                        //    Console.WriteLine("The show was deleted");
                        //}

                        if (entry.X.Description == null )
                        {
                          //  if (entry.X.ChannelId != null)
                           // {
                               // RunOnUiThread(() => Toast.MakeText(this, "Description is null in channnel:  " + entry.X.ChannelId , ToastLength.Long).Show());
                                Console.WriteLine("Description is null in channnel:  " + entry.X.ChannelId);
                           // }
                            //else
                            //{
                            //    Console.WriteLine("Description is null");
                            //}
                            
                        }
                       
                        //else if ( entry.X.SysStatus.The1 == entry.Y.SysStatus.The2)
                        //{
                        //    Console.WriteLine("deleted show"); 
                        //}


                        else
                        {
                            if (entry.X.Description.The111 != entry.Y.Description.The111)
                            {
                                if (entry.X.Description.The111.Value == entry.Y.Description.The111.Value)
                                {
                                    Console.WriteLine("The value of the show : " + entry.X.Description.The111.Value + "in channel: " + entry.X.ChannelId + "is not as same as" + entry.Y.Description.The111.Value);
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    Console.WriteLine("The time" + entry.X.TimeStart.DateTime + "of the show: " + entry.X.Description.The111.Value + " are not as same as " + entry.Y.TimeStart.DateTime);
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    Console.WriteLine("The time when the show  " + entry.X.Description.The111.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }
                                Console.WriteLine("english version");
                            }

                            if (entry.X.Description.The122 != entry.Y.Description.The122)
                            {
                                if (entry.X.Description.The122.Value != entry.Y.Description.The122.Value)
                                {                                 
                                    list.Add("Lnk (" + entry.X.ChannelId + ") buvo "+ entry.Y.Description.The122.Value +  " dabar "  + entry.X.Description.The122.Value);                       
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    list.Add("Lnk (" + entry.X.ChannelId + ") buvo " + entry.Y.TimeStart.DateTime + " dabar " + entry.X.TimeStart.DateTime);
                                    //list.Add("The time when starting the show " + entry.X.Description.The122.Value + " by time " + entry.X.TimeStart.DateTime + " are not as same as " + entry.Y.TimeStart.DateTime + "/n");
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    //DateTime fff = entry.X.TimeStop.DateTime;
                                    //TimeZoneInfo ff = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
                                    //fff = TimeZoneInfo.ConvertTimeFromUtc(fff, ff);

                                    //DateTime now = DateTime.Now;
                                    //if (now.Month < 10 && now.Month > 3)
                                    //{
                                    //    fff = fff.AddHours(3);
                                    //}
                                    


                                    Console.WriteLine("The time when the show  " + entry.X.Description.The122.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }

                                Console.WriteLine("Lithuanian version");
                            }

                            if (entry.X.Description.The126 != entry.Y.Description.The126)
                            {
                                if (entry.X.Description.The126.Value != entry.Y.Description.The126.Value)
                                {
                                    Console.WriteLine("The value of the show : " + entry.X.Description.The126.Value + " in channel: " + entry.X.ChannelId + " is not as same as " + entry.Y.Description.The126.Value);
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    Console.WriteLine("The time" + entry.X.TimeStart.DateTime + "of the show: " + entry.X.Description.The126.Value + " are not as same as " + entry.Y.TimeStart.DateTime);
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    Console.WriteLine("The time when the show  " + entry.X.Description.The126.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }
                                Console.WriteLine("Polish version");
                            }
                            if (entry.X.Description.The131 != entry.Y.Description.The131)
                            {
                                if (entry.X.Description.The131.Value != entry.Y.Description.The131.Value)
                                {
                                    Console.WriteLine("The value of the show : " + entry.X.Description.The131.Value + " in channel: " + entry.X.ChannelId + " is not as same as " + entry.Y.Description.The131.Value);
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    Console.WriteLine("The time" + entry.X.TimeStart.DateTime + "of the show: " + entry.X.Description.The131.Value + " are not as same as " + entry.Y.TimeStart.DateTime);
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    Console.WriteLine("The time when the show  " + entry.X.Description.The131.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }
                                Console.WriteLine("Russian version");
                            }
                            if (entry.X.Description.The112 != entry.Y.Description.The112)
                            {
                                if (entry.X.Description.The112.Value != entry.Y.Description.The112.Value)
                                {
                                    Console.WriteLine("The value of the show : " + entry.X.Description.The112.Value + " in channel: " + entry.X.ChannelId + " is not as same as " + entry.Y.Description.The112.Value);
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    Console.WriteLine("The time" + entry.X.TimeStart.DateTime + "of the show: " + entry.X.Description.The122.Value + " are not as same as " + entry.Y.TimeStart.DateTime);
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    Console.WriteLine("The time when the show  " + entry.X.Description.The112.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }

                                Console.WriteLine("Estonian version");
                            }
                            if (entry.X.Description.The121 != entry.Y.Description.The121)
                            {
                                if (entry.X.Description.The121.Value != entry.Y.Description.The121.Value)
                                {
                                    Console.WriteLine("The value of the show : " + entry.X.Description.The121.Value + " in channel: " + entry.X.ChannelId + " is not as same as " + entry.Y.Description.The121.Value);
                                }
                                if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                {
                                    Console.WriteLine("The time" + entry.X.TimeStart.DateTime + "of the show: " + entry.X.Description.The121.Value + " are not as same as " + entry.Y.TimeStart.DateTime);
                                }
                                if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                {
                                    Console.WriteLine("The time when the show  " + entry.X.Description.The121.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                }
                                Console.WriteLine("Latvian version");
                            }









                            else if (entry.X.Category == entry.Y.Category)
                            {
                             //   Console.WriteLine("{0}" + entry.X.Category + "nelygu {1}" + entry.Y.Category);
                            }
                            //else if (entry.X.Description.The122.Value != entry.Y.Description.The122.Value)
                            //{
                            //    Console.WriteLine("{0}" + entry.X.Description.The111.Value + "lygu {1}" + entry.Y.Description.The111);
                            //}
                            else
                                Console.WriteLine("nigguh the same");
                        }
                    }
                }
            }
          
        }

    }
}