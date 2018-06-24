using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//veikiantis originalas
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


                        try
                        {
                            obj2 = JsonConvert.DeserializeObject<Welcome>(content);
                        }
                        catch (Exception ex)
                        {
                            File.Delete(filename);

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
                            GetJson();
                        }
                    }

                        var col = obj.Data.Zip(obj2.Data, (x, y) => new { X = x, Y = y });
                       
                            foreach (var entry in col)
                            {
                        if (entry.X.ChannelId != entry.Y.ChannelId)
                        {
                            File.Delete(filename);

                            var streamWriter = new StreamWriter(filename, true);
                            {

                                streamWriter.WriteLine(StrReaded2);
                                streamWriter.Dispose();
                            }

                            Rewrite();
                            break;
                        }

                        else if (entry.X.SysStatus.The2 == null && entry.Y.SysStatus.The2 != null) 
                                         {
                            list.Add("Laida " + entry.X.Id + "buvo ištrinta");
                                         }
                                else if (entry.X.Description == null || entry.Y.Description == null)
                                {

                                }

                                else
                                {
                                    if (entry.X.Description.The111 != entry.Y.Description.The111)
                                    {
                                        if (entry.X.Description.The111.Value == entry.Y.Description.The111.Value)
                                        {
                                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The111.Value);

                                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The111.Value);
                                        }
                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                                           list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The111.Value);

                                           list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The111.Value);
                            }
                                        if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                        {
                                list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The111.Value);
                                list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The111.Value);
                            }
                                        Console.WriteLine("english version");
                                    }

                                    if (entry.X.Description.The122 != entry.Y.Description.The122)
                                    {
                                        if (entry.X.Description.The122.Value != entry.Y.Description.The122.Value)
                                        {
                                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The122.Value);
                                           
                                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The122.Value);
                                           
                                    //IEnumerable<char> differenceQuery4 = entry.X.Except(entry.Y);
                                    //Console.WriteLine("The following lines are in names1.txt but not names2.txt");

                                    //foreach (char s in differenceQuery4)
                                    //{
                                    //    Console.WriteLine(s);
                                    //}
                                }

                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The122.Value);
                                           
                                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The122.Value);
                                          

                                            //     list.Add("Lnk (" + entry.X.ChannelId + ") buvo " + entry.Y.TimeStart.DateTime + " dabar " + entry.X.TimeStart.DateTime);
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

                                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The122.Value);
                                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The122.Value);

                                            Console.WriteLine("The time when the show  " + entry.X.Description.The122.Value + " are stoped by time " + entry.X.TimeStop.DateTime + " are not as same as " + entry.Y.TimeStop.DateTime);
                                        }

                                        Console.WriteLine("Lithuanian version");
                                    }

                                    if (entry.X.Description.The126 != entry.Y.Description.The126)
                                    {
                                        if (entry.X.Description.The126.Value != entry.Y.Description.The126.Value)
                                        {
                                              list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The126.Value);

                                              list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The126.Value);
                            }
                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                                list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The126.Value);

                                list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The126.Value);
                            }
                                        if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                        {
                                list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The126.Value);
                                list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The126.Value);
                            }
                                        Console.WriteLine("Polish version");
                                    }
                                    if (entry.X.Description.The131 != entry.Y.Description.The131)
                                    {
                                        if (entry.X.Description.The131.Value != entry.Y.Description.The131.Value)
                                        {
                                list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The131.Value);

                                list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The131.Value);
                            }
                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                                list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The131.Value);

                                list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The131.Value);
                            }
                        }
                                        if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The131.Value);
                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The131.Value);
                        }
                                        Console.WriteLine("Russian version");
                                    }
                                    if (entry.X.Description.The112 != entry.Y.Description.The112)
                                    {
                                        if (entry.X.Description.The112.Value != entry.Y.Description.The112.Value)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The112.Value);

                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The112.Value);
                        }
                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The112.Value);

                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The112.Value);
                        }
                                        if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The112.Value);
                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The112.Value);
                        }

                                        Console.WriteLine("Estonian version");
                                    }
                                    if (entry.X.Description.The121 != entry.Y.Description.The121)
                                    {
                                        if (entry.X.Description.The121.Value != entry.Y.Description.The121.Value)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.Y.Description.The121.Value);

                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The121.Value);
                        }
                                        if (entry.X.TimeStart.DateTime != entry.Y.TimeStart.DateTime)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStart.DateTime + " " + entry.X.Description.The121.Value);

                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStart.DateTime + " " + entry.X.Description.The121Value);
                        }
                                        if (entry.X.TimeStop.DateTime != entry.Y.TimeStop.DateTime)
                                        {
                            list.Add("Buvo: " + "Lnk (" + entry.X.ChannelId + ") " + entry.Y.TimeStop.DateTime + " " + entry.X.Description.The121.Value);
                            list.Add("Pakeista: " + "Lnk (" + entry.X.ChannelId + ") " + entry.X.TimeStop.DateTime + " " + entry.X.Description.The121.Value);
                        }
                                        Console.WriteLine("Latvian version");
                                    }


                                    if (entry.X.ChannelId != null && entry.Y.ChannelId == null)
                                    {
                                        Console.WriteLine("ChannelNull");                      
                                    }

                                    else
                                        Console.WriteLine("All the same");
                                }
                            }
                        }
                    
                }
            }
          
        }

    
