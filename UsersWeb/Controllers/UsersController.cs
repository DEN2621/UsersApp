using Microsoft.AspNetCore.Mvc;
using UsersDTO;
using UsersWeb.Services;

namespace UsersWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService service;
        public UsersController(UsersService service)
        {
            this.service = service;
        }

        // GET: UsersController
        public ActionResult Users()
        {
            return View(service.Users());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View(service.Details(id));
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO user)
        {
            try
            {
                service.Create(user);
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return Details(id);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserDTO user)
        {
            try
            {
                service.Edit(user);
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserDTO user)
        {
            try
            {
                service.Delete(id);
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }
    }
}
