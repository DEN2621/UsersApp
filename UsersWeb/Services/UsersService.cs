using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System;
using UsersDTO;
using System.Collections.Generic;

namespace UsersWeb.Services
{
    public class UsersService : Controller
    {
        public static ActionResult MakeRequest(int id = 0, IFormCollection collection = null, string page = "", string method = "GET")
        {
            try
            {
                WebRequest request = WebRequest.Create($"https://localhost:44325/api/Users/{page}");
                request.Method = method;
                switch (request.Method)
                {
                    case "GET":
                        using (WebResponse response = request.GetResponse())
                        {
                            using Stream stream = response.GetResponseStream();
                            using StreamReader reader = new(stream);
                            return View(id == 0
                                ? JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(reader.ReadToEnd())
                                : JsonConvert.DeserializeObject<UserDTO>(reader.ReadToEnd()));
                        }
                    case "DELETE":
                        break;
                    default:
                        UserDTO user = new()
                        {
                            Name = collection["Name"],
                            Age = Convert.ToInt32(collection["Age"]),
                            City = collection["City"],
                            Email = collection["Email"]
                        };
                        if (request.Method == "PUT")
                        {
                            user.Id = id;
                        }
                        byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));
                        request.ContentLength = bytes.Length;
                        request.ContentType = "application/json";
                        using (Stream stream = request.GetRequestStream())
                        {
                            stream.Write(bytes);
                        }
                        break;
                }
                using (WebResponse response = request.GetResponse())
                {
                    return MakeRequest();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
