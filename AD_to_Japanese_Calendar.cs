using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Japanese_calendar_conversion
{
    public static class AD_to_Japanese_Calendar
    {
        [FunctionName("AD to Japanese Calendar")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req, ILogger log)
        {
            try
            {
                Console.WriteLine(req.Content.ReadAsStringAsync().Result);
                var data = req.Content.ReadAsAsync<DialogFlowRequest>().Result;
                var date1 = new DateTime(int.Parse(data.queryResult.parameters.number.ToString()), 1, 1);
                var date2 = new DateTime(int.Parse(data.queryResult.parameters.number.ToString()), 12, 31);

                var culture = new CultureInfo("ja-JP");
                culture.DateTimeFormat.Calendar = new JapaneseCalendar();

                var gg1 = date1.ToString("ggy年", culture);
                var gg2 = date2.ToString("ggy年", culture);

                var ResponceObject = new DialogFlowResponce();
                if (gg1 == gg2)
                {
                    ResponceObject.fulfillmentText = $"{gg1}です。";
                }
                else
                {
                    ResponceObject.fulfillmentText = $"{gg1}、もしくは{gg2}です。";
                }

                string json = JsonConvert.SerializeObject(ResponceObject);

                var ReturnObject = new ObjectResult(json);
                return ReturnObject;
            }
            catch (Exception)
            {
                var ResponceObject = new DialogFlowResponce
                {
                    fulfillmentText = $"ごめんなさい計算できません。"
                };
                string json = JsonConvert.SerializeObject(ResponceObject);

                var ReturnObject = new ObjectResult(json);
                return ReturnObject; ;
            }
        }
    }
}
