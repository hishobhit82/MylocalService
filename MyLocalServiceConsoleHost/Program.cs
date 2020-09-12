using MyLocalService;
using MyLocalServiceClient;
using ServiceSettings;
using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace MyLocalServiceConsoleHost
{
	class Program
	{
		static void Main(string[] args)
		{
			var baseAddress = "http://" + Environment.MachineName + ":8081/Service";
			var host = new ServiceHost(typeof(MyLocalService.MyLocalService), new Uri(baseAddress));

			var webBinding = new WebHttpBinding();
			webBinding.ContentTypeMapper = new RawMapper();
			var behaviour = new NewtonsoftJsonBehavior();


			host.AddServiceEndpoint(typeof(IMyLocalService), webBinding, "api").Behaviors.Add(behaviour);
			host.Description.Behaviors.Add(new ServiceMetadataBehavior());
			Console.WriteLine("Opening the host");
			host.Open();

			Console.WriteLine("Now using the client formatter");

			var x = HttpWebClient.SendRequest("http://localhost:8080/Service/api/GetData?value=5", "GET", null, null);



			Console.ReadLine();
		}

        public static string SendRequest(string uri, string method, string contentType, string body)
        {
            string responseBody = null;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = method;
            if (!String.IsNullOrEmpty(contentType))
            {
                req.ContentType = contentType;
            }
            if (body != null)
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
                req.GetRequestStream().Close();
            }

            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }
            Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (string headerName in resp.Headers.AllKeys)
            {
                Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
            }
            Console.WriteLine();
            Stream respStream = resp.GetResponseStream();
            if (respStream != null)
            {
                responseBody = new StreamReader(respStream).ReadToEnd();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
            }
            Console.WriteLine();
            Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
            Console.WriteLine();

            return responseBody;
        }
    }
}
