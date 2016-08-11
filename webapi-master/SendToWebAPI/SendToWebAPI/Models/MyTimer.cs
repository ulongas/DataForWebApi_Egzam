using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using Newtonsoft.Json;

namespace SendToWebAPI.Models
{
    public class MyTimer
    {
        private System.Timers.Timer _aTimer;

        public void StartWriting()
        {
            _aTimer = new System.Timers.Timer(2000);

            _aTimer.Elapsed += OnTimedEvent;

            _aTimer.AutoReset = true;

            _aTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            DataManager dataManager = new DataManager();
            NewUsageData usageData = new NewUsageData();
            usageData.ProcessorUsage = dataManager.GetCpuUsage();
            usageData.MemoryUsage = dataManager.GetRamUsage();
            usageData.TimeStamp = DateTime.Now;
            SendDataToWebApi(usageData);
        }

        private void SendDataToWebApi(NewUsageData usageData)
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri("http://192.168.10.106");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var newUsageReport = new NewUsageData { TimeStamp = DateTime.Now, ProcessorUsage = 40, MemoryUsage = 30 };

                var json = JsonConvert.SerializeObject(usageData);

                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = client.PostAsync("api/virtualmachines/13/usagereports", content);

                var result = response.Result;
            }
        }
    }
}
    


