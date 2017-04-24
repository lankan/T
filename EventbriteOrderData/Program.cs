using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;

namespace EventbriteOrderData
{
    class Program
    {
        private static string strEventID = "17924981101";
        private static string strToken = "OZKYVMIZCKAKXRZP3OHZ";

        static void Main(string[] args)
        {
            string strUrl =
                @"https://www.eventbriteapi.com/v3/events/" + strEventID + "/orders/?status=all&token=" + strToken + "&expand=attendees";

            EventBriteObj ebMain = Download_serialized_json_data<EventBriteObj>(strUrl);
            List<FlatEventBriteObj> lMainObj = ebMain.FlattenEbObj().GroupBy(x => x.barcode).Select(
                y => y.First()).ToList();

            //DataTable dt = lMainObj.ToDataTable();

            Console.WriteLine("Now downloaded page 1 result");

            int iNumberOfPages = ebMain.pagination.page_count;

            //List<EventBriteObj> lObj = new List<EventBriteObj>();
            List<FlatEventBriteObj> lAllObj = new List<FlatEventBriteObj>();
            lAllObj.AddRange(lMainObj);

            for (int a = 2; a <= iNumberOfPages; a++)
            {
                Console.WriteLine("Downloading page {0} of {1}", a, iNumberOfPages);

                string strPages = strUrl + "&page=" + a.ToString();

                EventBriteObj roItem = Download_serialized_json_data<EventBriteObj>(strPages);

                List<FlatEventBriteObj> lObj = roItem.FlattenEbObj().GroupBy(x => x.barcode).Select(
                    y => y.First()).ToList();

                //DataTable dtItem = roItem.orders.ToDataTable();
                //DataTable dtItem = lObj.ToDataTable();

                lAllObj.AddRange(lObj);

                //dt.Merge(dtItem);
            }

            String strWritePath =
                @"C:\Users\chanuka weerasinghe\Desktop\EventBrite\fileoutput.csv";

            if (lAllObj.Export(strWritePath))
                Console.WriteLine("File have now been output");
            else
                Console.WriteLine("File failed to output");

            lAllObj = AssignSecondaryCodes(lAllObj);

            strWritePath = strWritePath.Replace("fileoutput","barcodeAssigned");

            if (lAllObj.Export(strWritePath))
                Console.WriteLine("Barcode have now been output");
            else
                Console.WriteLine("Barcode failed to output");

            PostSecondaryCode(lAllObj);
            Console.ReadLine();
        }

        private static EventBriteObj Download_serialized_json_data<EventBriteObj>(string url) where EventBriteObj : new()
        {
            EventBriteObj ebData = new EventBriteObj();

            using (var w = new System.Net.WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);

                    ebData = JsonConvert.DeserializeObject<EventBriteObj>(json_data);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

                return ebData;
            }
        }

        public static List<FlatEventBriteObj> AssignSecondaryCodes(List<FlatEventBriteObj> lObjects)
        {
            int iSeq = 1;

            DateTime dtNow = DateTime.Now;
            int iDy = dtNow.DayOfYear;

            foreach (FlatEventBriteObj fbo in lObjects)
            {
                string code = "EBRDI-" + iDy.ToString("000") + "-" + iSeq.ToString("00000") + "-MK8XX";
                fbo.scValue = code;

                iSeq++;
            }

            return lObjects;
        }

        public static void PostSecondaryCode(List<FlatEventBriteObj> lObjects)
        {
            List<ebSecondary> lEbSec = new List<ebSecondary>();

            int idx = 0;

            foreach (FlatEventBriteObj fbo in lObjects)
            {
                if (idx % 100 == 0)
                    Console.WriteLine("Now processed {0} of {1}", idx + 1, lObjects.Count);

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"https://www.eventbriteapi.com/v3/orders/" + 
                        fbo.order_id + @"/barcodes/" + fbo.barcode + @"/associations/?token=" + strToken);
                    httpWebRequest.ContentType = "application/json";
                    //httpWebRequest.Headers.Add("Authorization", strToken);
                    httpWebRequest.Method = "POST";

                    using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            type = "RACE_BIB",
                            value = fbo.scValue,
                            active = true
                        });

                        streamWriter.Write(json);
                    }   //end of using StreamWriter

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    string result;
                    using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();

                        ebSecondary ebSec = JsonConvert.DeserializeObject<ebSecondary>(result);
                        lEbSec.Add(ebSec);
                    }

                    //Console.WriteLine(result);
                }
                catch (WebException wex)
                {
                    if (wex.Response != null)
                    {
                        using (HttpWebResponse htr = (HttpWebResponse)wex.Response)
                        {
                            using (StreamReader sRdr = new StreamReader(htr.GetResponseStream()))
                            {
                                string strErr = sRdr.ReadToEnd();
                            }   //end of using StreamReader
                        }   //end of using HttpWebResponse
                    }   //end of WebException is null check
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

                idx++;
            }   //end of foreach FlatEventBriteObj

            String strWritePath =
                @"C:\Users\mark favor\Desktop\ebSecResponse.csv";

            if (lEbSec.Export(strWritePath))
                Console.WriteLine("Secondary barcode response have now been output");
            else
                Console.WriteLine("Secondary barcode response failed to output");
        }   //end of PostSecondaryCode method
    }
}
