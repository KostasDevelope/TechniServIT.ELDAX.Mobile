using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TechniServIT.ELDAX.Mobile.Eldax.Common.Services
{
    //public class CalculatorServiceAgent
    //{
    //    private static EndpointAddress endPoint = new EndpointAddress("http://192.168.216.1:1234/CalculatorService.svc");
    //    private static BasicHttpBinding binding;

    //    static CalculatorServiceAgent()
    //    {
    //        binding = CreateBasicHttpBinding();
    //    }

    //    private static BasicHttpBinding CreateBasicHttpBinding()
    //    {
    //        BasicHttpBinding binding = new BasicHttpBinding
    //        {
    //            Name = "basicHttpBinding",
    //            MaxBufferSize = 2147483647,
    //            MaxReceivedMessageSize = 2147483647
    //        };

    //        TimeSpan timeout = new TimeSpan(0, 0, 30);
    //        binding.SendTimeout = timeout;
    //        binding.OpenTimeout = timeout;
    //        binding.ReceiveTimeout = timeout;
    //        return binding;
    //    }

    //    public async static Task<int> DoSum(int value1, int value2)
    //    {
    //        ICalculatorService _client;
    //        try
    //        {
    //            _client = new CalculatorServiceClient(binding, endPoint);
    //            var res = Task<int>.Factory.FromAsync(_client.BeginDoSum, _client.EndDoSum, value1, value2, null);
    //            await res;
    //            return res.Result;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //}

    public class CalculatorServiceAgent
    {
        //https://www.c-sharpcorner.com/article/consume-wcf-services-in-xamarin-android-app/
        //https://www.codeproject.com/Questions/457616/how-to-send-xml-file-over-HttpWebRequest
        public void TestSend() {
            var request = HttpWebRequest.CreateHttp("https://localhost:8003/ELDAX/Service");
            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            request.Method = "GET";
            var body = new byte[0];
            var newStream = request.GetRequestStream();
            newStream.Write(body, 0, body.Length);

            using (HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    var result = System.Text.RegularExpressions.Regex.Replace(content, @"[^a-zA-Z0-9]", "");
                    var addSpace = result.Replace("Name", " Name ");
                    var addedSpace = addSpace.Replace("Id", " Id ");
                    
                }
            }

        }
    }

}
