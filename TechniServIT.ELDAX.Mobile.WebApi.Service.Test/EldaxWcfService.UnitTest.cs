using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

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
            GetXmlDocument();

            //using (var httpResponse = (HttpWebResponse)await _eldaxService.GetResponseAsync())
            //{
            //    if (httpResponse.StatusCode == HttpStatusCode.OK)
            //    {
            //        using (var objResponseStream = httpResponse.GetResponseStream())
            //        {
            //            using (var objXMLReader = new XmlTextReader(objResponseStream))
            //            {
            //                var xmldoc = new XmlDocument();
            //                xmldoc.Load(objXMLReader);
            //            }
            //        }
            //    }
            //}

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

    }
}