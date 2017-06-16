namespace HelloWorld
{
    using System.Threading.Tasks;
    using System;
    using System.Xml;
    using  System.Security.Cryptography.Xml;
    public class Startup
    {
        public async Task<object> Invoke(object input)
        {
           var doc = new System.Xml.XmlDocument();
           doc.LoadXml("<a></a>");

        var signedXml = new System.Security.Cryptography.Xml.SignedXml();
        var time = DateTime.Now;
          var x= "";
            return "Hello from dot net core" + time;
        }
    }
}
