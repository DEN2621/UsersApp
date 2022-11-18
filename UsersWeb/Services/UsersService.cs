using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using UsersDTO;

namespace UsersWeb.Services
{
    public class UsersService
    {
        private readonly IUsersConfiguration configuration;
        readonly Func<string, IWebRequest> getWebRequest;
        public UsersService(IUsersConfiguration configuration, Func<string, IWebRequest> getWebRequest)
        {
            this.configuration = configuration;
            this.getWebRequest = getWebRequest;
        }
        private string MakeRequest(UserDTO user = null, string page = "", string method = WebRequestMethods.Http.Get)
        {
            IWebRequest request = getWebRequest($"{configuration.APIBaseURL}api/Users/{page}");
            request.Method = method;
            request.ContentType = MediaTypeNames.Application.Json;
            if (user != null)
            {
                using Stream stream = request.GetRequestStream();
                using StreamWriter writer = new(stream);
                writer.Write(JsonConvert.SerializeObject(user));
            }
            return request.GetResponse();
        }
        public IEnumerable<UserDTO> Index()
        {
            return JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(MakeRequest());
        }
        public void Create(UserDTO user)
        {
            MakeRequest(user, method: WebRequestMethods.Http.Post);
        }
        public UserDTO Details(int id)
        {
            return JsonConvert.DeserializeObject<UserDTO>(MakeRequest(page: $"{id}"));
        }
        public void Edit(UserDTO user)
        {
            MakeRequest(user, $"{user.Id}", WebRequestMethods.Http.Put);
        }
        public void Delete(int id)
        {
            MakeRequest(page: $"{id}", method: HttpMethod.Delete.ToString());
        }
    }
}
