using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;/*
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UsersDTO;*/
using UsersWeb.Services;

namespace UsersWeb.Controllers
{
    public class UsersController : Controller
    {
        // GET: UsersController
        public ActionResult Index()
        {
            return UsersService.MakeRequest();/*
            using WebResponse response = WebRequest.Create("https://localhost:44325/api/Users").GetResponse();
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new(stream);
            return View(JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(reader.ReadToEnd()));*/
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return UsersService.MakeRequest(id, null, $"{id}");/*
            using WebResponse response = WebRequest.Create($"https://localhost:44325/api/Users/{id}").GetResponse();
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new(stream);
            return View(JsonConvert.DeserializeObject<UserDTO>(reader.ReadToEnd()));*/
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return UsersService.MakeRequest(0, collection, "", "POST");/*
            try
            {
                WebRequest request = WebRequest.Create("https://localhost:44325/api/Users");
                request.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new UserDTO()
                {
                    Name = collection["Name"],
                    Age = Convert.ToInt32(collection["Age"]),
                    City = collection["City"],
                    Email = collection["Email"]
                }));
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using Stream stream = request.GetRequestStream();
                stream.Write(bytes);
                using WebResponse response = request.GetResponse();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return Details(id);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return UsersService.MakeRequest(id, collection, $"{id}", "PUT");/*
            try
            {
                WebRequest request = WebRequest.Create($"https://localhost:44325/api/Users/{id}");
                request.Method = "PUT";
                byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new UserDTO()
                {
                    Id = id,
                    Name = collection["Name"],
                    Age = Convert.ToInt32(collection["Age"]),
                    City = collection["City"],
                    Email = collection["Email"]
                }));
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using Stream stream = request.GetRequestStream();
                stream.Write(bytes);
                using WebResponse response = request.GetResponse();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return UsersService.MakeRequest(id, collection, $"{id}", "DELETE");/*
            try
            {
                WebRequest request = WebRequest.Create($"https://localhost:44325/api/Users/{id}");
                request.Method = "DELETE";
                using WebResponse response = request.GetResponse();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }
    }
}
