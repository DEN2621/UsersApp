using System.IO;
using System.Net;

namespace UsersWeb.Services
{
    public interface IWebRequest
    {
        string Method { set; }
        string ContentType { set; }
        Stream GetRequestStream();
        string GetResponse();
    }
}
