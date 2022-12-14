using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Test.Requests;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Test
{
    public class EldaxWcfServiceUnitTest
    {


        //private HttpWebRequest _eldaxService;
        //private string _urlWcf = "https://localhost:8003/ELDAX/Service";


        [SetUp]
        public void Setup()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                      (sender, cert, chain, sslPolicyErrors) => true;

            //_eldaxService = (HttpWebRequest)WebRequest.Create(_urlWcf);
            //_eldaxService.AllowAutoRedirect = false;
            //_eldaxService.Timeout = 30000;
            //_eldaxService.Headers.Add(@"SOAP:Action");
            //_eldaxService.ContentType = "text/xml; encoding='utf-8'";
            //_eldaxService.Accept = "text/xml";
            //_eldaxService.Method = "POST";
        }

        //[Test]
        //public async Task AuthenticateExTestAsync()
        //{
        //    using (var httpRes = await _eldaxService.GetResponseAsync())
        //    {
        //        Assert.IsNotNull(httpRes);
        //        Assert.IsTrue(((HttpWebResponse)httpRes).StatusCode == HttpStatusCode.OK);
        //    }

        //}

        //[Test]
        //public async Task AuthenticateExTestAsync2()
        //{

        //    try
        //    {
        //        var dataXml = SetValuesToXmlDocument();
        //        var bytes = System.Text.Encoding.UTF8.GetBytes(dataXml);
        //        using (var objRequestStream = _eldaxService.GetRequestStream())
        //        {
        //            objRequestStream.Write(bytes, 0, bytes.Length);

        //            using (var httpResponse = (HttpWebResponse)await _eldaxService.GetResponseAsync())
        //            {
        //                if (httpResponse.StatusCode == HttpStatusCode.OK)
        //                {


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {

        //    }
        //}

        //private string SetValuesToXmlDocument()
        //{
        //    var result = string.Empty;
        //    var document = new XmlDocument();
        //    document.LoadXml(ELDAXServiceRequests.AuthenticateEx);
        //    var namespaces = new XmlNamespaceManager(document.NameTable);
        //    namespaces.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope");
        //    namespaces.AddNamespace("tec", "https://www.techniserv-it.cz");
        //    namespaces.AddNamespace("tec1", "http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses");

        //    var applicationLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ApplicationLogin", namespaces);
        //    applicationLogin.InnerText = "sa";

        //    var userLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:UserLogin", namespaces);
        //    userLogin.InnerText = "sa";

        //    var password = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:Password", namespaces);
        //    password.InnerText = "123";

        //    var authenticationType = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:AuthenticationType", namespaces);
        //    authenticationType.InnerText = "Classic";

        //    var ClientVersion = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ClientVersion", namespaces);
        //    ClientVersion.InnerText = "2.0.0";

        //    var cultureCode = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:CultureCode", namespaces);
        //    authenticationType.InnerText = "cs-CZ";

        //    var timeZoneId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TimeZoneId", namespaces);
        //    timeZoneId.InnerText = "Central Europe Standard Time";

        //    var twoFactorAuthentication = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TwoFactorAuthentication", namespaces);
        //    twoFactorAuthentication.InnerText = "false";



        //    return document.InnerXml;
        //}


        [Test]
        public void Execute()
        {
            var request = CreateWebRequest();
            var document = new XmlDocument();
            document.LoadXml(ELDAXServiceRequests.AuthenticateEx);
            var namespaces = new XmlNamespaceManager(document.NameTable);
            namespaces.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope");
            namespaces.AddNamespace("tec", "https://www.techniserv-it.cz");
            namespaces.AddNamespace("tec1", "http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses");

            var applicationLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ApplicationLogin", namespaces);
            applicationLogin.InnerText = "sa";

            var userLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:UserLogin", namespaces);
            userLogin.InnerText = "sa";

            var password = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:Password", namespaces);
            password.InnerText = "123";

            var authenticationType = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:AuthenticationType", namespaces);
            authenticationType.InnerText = "Classic";

            var ClientVersion = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ClientVersion", namespaces);
            ClientVersion.InnerText = "2.0.0";

            var cultureCode = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:CultureCode", namespaces);
            cultureCode.InnerText = "cs-CZ";

            var timeZoneId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TimeZoneId", namespaces);
            timeZoneId.InnerText = "Central Europe Standard Time";

            var twoFactorAuthentication = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TwoFactorAuthentication", namespaces);
            twoFactorAuthentication.InnerText = "false";


            var byteArray = Encoding.UTF8.GetBytes(document.InnerXml);

            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            WebResponse response = request.GetResponse();

            //using (Stream stream = request.GetRequestStream())
            //{
            //    document.Save(stream);
            //}

            //using (WebResponse response = request.GetResponse())
            //{
            //    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            //    {
            //        string soapResult = rd.ReadToEnd();
            //        Console.WriteLine(soapResult);
            //    }
            //}
        }


        [Test]
        public async Task TestSoap()
        {
            //var httpReq = (HttpWebRequest)WebRequest.Create("https://localhost:8003/ELDAX/Service");
            //httpReq.AllowAutoRedirect = false;
            //httpReq.Timeout = 30000;
            //httpReq.Headers.Add(@"SOAP:AuthenticateEx");
            //httpReq.ContentType = "text/xml;charset=\"utf-8\"";
            //httpReq.Accept = "text/xml";
            //httpReq.Method = "POST";

            var httpReq = CreateWebRequest();

            var document = new XmlDocument();
            document.LoadXml(ELDAXServiceRequests.AuthenticateEx);
            var namespaces = new XmlNamespaceManager(document.NameTable);
            namespaces.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope");
            namespaces.AddNamespace("tec", "https://www.techniserv-it.cz");
            namespaces.AddNamespace("tec1", "http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses");

            var applicationLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ApplicationLogin", namespaces);
            applicationLogin.InnerText = "sa";

            var userLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:UserLogin", namespaces);
            userLogin.InnerText = "sa";

            var password = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:Password", namespaces);
            password.InnerText = "123";

            var authenticationType = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:AuthenticationType", namespaces);
            authenticationType.InnerText = "Classic";

            var ClientVersion = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ClientVersion", namespaces);
            ClientVersion.InnerText = "2.0.0";

            var cultureCode = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:CultureCode", namespaces);
            cultureCode.InnerText = "cs-CZ";

            var timeZoneId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TimeZoneId", namespaces);
            timeZoneId.InnerText = "Central Europe Standard Time";

            var twoFactorAuthentication = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TwoFactorAuthentication", namespaces);
            twoFactorAuthentication.InnerText = "false";

            var IsTokenValid = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IsTokenValid", namespaces);
            IsTokenValid.InnerText = "false";

            var IsLockedOut = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IsLockedOut", namespaces);
            IsLockedOut.InnerText = "false";

            var EntityId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:EntityId", namespaces);
            EntityId.InnerText = "00000000-0000-0000-0000-000000000000";

            var IPAddress = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IPAddress", namespaces);
            IPAddress.InnerText = "192.168.1.101";




            using (Stream stream = httpReq.GetRequestStream())
            {
                document.Save(stream);
            }

            try
            {
                using (var httpRes = await httpReq.GetResponseAsync())
                {
                    var ss = ((HttpWebResponse)httpRes).StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest()
        {//https://localhost:8003/ELDAX/Service
            var url = "https://localhost:8003/ELDAX/Service";
            var actionUrl = $"{url}"; //$"{url}?op=AuthenticateEx";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(actionUrl);
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 30000;
            webRequest.Headers.Add("SOAPAction", actionUrl);
            //webRequest.Headers.Add(@"SOAP:AuthenticateEx");
            webRequest.ContentType = "application/soap+xml; charset=utf-8";//"text/xml;charset=\"utf-8\"";
            //webRequest.Accept = "text/xml"; // "application/soap+xml";
            webRequest.Method = "POST";
            return webRequest;
        }


        [Test]
        public async Task TestSoap2()
        {
            var url = "https://localhost:8003/ELDAX/Service";
            var action = "AuthenticateEx";
            var soapAction = "https://localhost:8003/ELDAX/Service?op=AuthenticateEx";

            SOAPHelper.SendSOAPRequest(url, action, soapAction);
        }
    }


    public static class SOAPHelper
    {
        /// <summary>
        /// Sends a custom sync SOAP request to given URL and receive a request
        /// </summary>
        /// <param name="url">The WebService endpoint URL</param>
        /// <param name="action">The WebService action name</param>
        /// <param name="parameters">A dictionary containing the parameters in a key-value fashion</param>
        /// <param name="soapAction">The SOAPAction value, as specified in the Web Service's WSDL (or NULL to use the url parameter)</param>
        /// <param name="useSOAP12">Set this to TRUE to use the SOAP v1.2 protocol, FALSE to use the SOAP v1.1 (default)</param>
        /// <returns>A string containing the raw Web Service response</returns>
        public static string SendSOAPRequest(string url, string action, string soapAction = null, bool useSOAP12 = false)
        {
            // Create the SOAP envelope
            var document = new XmlDocument();
            document.LoadXml(ELDAXServiceRequests.AuthenticateEx);
            var namespaces = new XmlNamespaceManager(document.NameTable);
            namespaces.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope");
            namespaces.AddNamespace("tec", "https://www.techniserv-it.cz");
            namespaces.AddNamespace("tec1", "http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses");

            var applicationLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ApplicationLogin", namespaces);
            applicationLogin.InnerText = "sa";

            var userLogin = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:UserLogin", namespaces);
            userLogin.InnerText = "sa";

            var password = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:Password", namespaces);
            password.InnerText = "123";

            var authenticationType = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:AuthenticationType", namespaces);
            authenticationType.InnerText = "Classic";

            var ClientVersion = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ClientVersion", namespaces);
            ClientVersion.InnerText = "2.0.0";

            var cultureCode = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:CultureCode", namespaces);
            cultureCode.InnerText = "cs-CZ";

            var timeZoneId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TimeZoneId", namespaces);
            timeZoneId.InnerText = "Central Europe Standard Time";

            var twoFactorAuthentication = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TwoFactorAuthentication", namespaces);
            twoFactorAuthentication.InnerText = "false";

            var IsTokenValid = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IsTokenValid", namespaces);
            IsTokenValid.InnerText = "false";

            var IsLockedOut = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IsLockedOut", namespaces);
            IsLockedOut.InnerText = "false";

            var EntityId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:EntityId", namespaces);
            EntityId.InnerText = "00000000-0000-0000-0000-000000000000";

            var IPAddress = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:IPAddress", namespaces);
            IPAddress.InnerText = "192.168.1.101";




            // Create the web request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);


            webRequest.Headers.Add("SOAPAction", action ?? soapAction);

            //webRequest.Headers.Add(@"SOAP:Action");

            webRequest.ContentType = (useSOAP12) ? "application/soap+xml;charset=\"utf-8\"" : "text/xml;charset=\"utf-8\"";
            webRequest.Accept = (useSOAP12) ? "application/soap+xml" : "text/xml";
            webRequest.Method = "POST";

            // Insert SOAP envelope
            using (Stream stream = webRequest.GetRequestStream())
            {
                document.Save(stream);
            }


            // Send request and retrieve result
            var result = string.Empty;

            try
            {
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        result = rd.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return result;
        }
    }


}




