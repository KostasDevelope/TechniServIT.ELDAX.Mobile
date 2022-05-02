using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Test.Requests;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Test
{
    public class EldaxWcfServiceUnitTest
    {


        private HttpWebRequest _eldaxService;
        private string _urlWcf = "https://localhost:8003/ELDAX/Service.svc/";


        [SetUp]
        public void Setup()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                      (sender, cert, chain, sslPolicyErrors) => true;

            _eldaxService = (HttpWebRequest)WebRequest.Create(_urlWcf);
            _eldaxService.AllowAutoRedirect = false;
            _eldaxService.Timeout = 30000;
            _eldaxService.ContentType = "text/xml; encoding='utf-8'";
            _eldaxService.Method = "POST";
        }

        [Test]
        public async Task AuthenticateExTestAsync()
        {
            using (var httpRes = await _eldaxService.GetResponseAsync())
            {
                Assert.IsNotNull(httpRes);
                Assert.IsTrue(((HttpWebResponse)httpRes).StatusCode == HttpStatusCode.OK);
            }

        }

        [Test]
        public async Task AuthenticateExTestAsync2()
        {

            try
            {
                var dataXml = SetValuesToXmlDocument();
                var bytes = System.Text.Encoding.UTF8.GetBytes(dataXml);
                using (var objRequestStream = _eldaxService.GetRequestStream())
                {
                    objRequestStream.Write(bytes, 0, bytes.Length);

                    using (var httpResponse = (HttpWebResponse)await _eldaxService.GetResponseAsync())
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {


                        }
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }

        private string GetXmlDocument()
        {
            var result = string.Empty;
            var documentXml = new XmlDocument();
            documentXml.LoadXml(ELDAXServiceRequests.AuthenticateEx);
            var nsmgr = new XmlNamespaceManager(documentXml.NameTable);
            nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsmgr.AddNamespace("tec", "https://www.techniserv-it.cz");
            nsmgr.AddNamespace("tec1", "http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses");
            var applicationLogin = documentXml.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:ApplicationLogin", nsmgr);
            applicationLogin.InnerText = "sa";
            return documentXml.InnerXml;
        }

        private string SetValuesToXmlDocument()
        {
            var result = string.Empty;
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
            authenticationType.InnerText = "cs-CZ";

            var timeZoneId = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TimeZoneId", namespaces);
            timeZoneId.InnerText = "Central Europe Standard Time";

            var twoFactorAuthentication = document.DocumentElement.SelectSingleNode("//tec:AuthenticateEx/tec:ctx/tec1:TwoFactorAuthentication", namespaces);
            twoFactorAuthentication.InnerText = "false";



            return document.InnerXml;
        }



    }
}