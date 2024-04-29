using GestaoColaboradores.Models.Colaborador;
using GestaoColaboradores.Models.User;
using GestaoColaboradores.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestaoColaboradores.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index(bool? status)
        {
            return View(await _userService.GetAllAsync(status));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Login,Password")] User newUser)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(newUser);
                return RedirectToAction("Index");
            }
            return View(newUser);
        }

        public async Task<IActionResult> Edit([Bind("Id")] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            //UserRequest request = new UserRequest(userSelected.Id, userSelected.Login, "", userSelected.Active.Value);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Login, Password, Active")] User userEdit)
        {
            if (ModelState.IsValid)
            {
                _userService.Edit(userEdit);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}
