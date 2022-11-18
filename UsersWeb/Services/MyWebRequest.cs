using System.IO;
using System.Net;

namespace UsersWeb.Services
{
    public class MyWebRequest : IWebRequest
    {
        private readonly WebRequest request;
        public MyWebRequest(string url)
        {
            request = WebRequest.Create(url);
        }
        public string Method { set => request.Method = value; }
        public string ContentType { set => request.ContentType = value; }

        public Stream GetRequestStream()
        {
            return request.GetRequestStream();
        }

        public string GetResponse()
        {
            using WebResponse response = request.GetResponse();
            using StreamReader reader = new(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}
