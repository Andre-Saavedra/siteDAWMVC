using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        //private readonly UserManager<Utilizadores> userManager;


        public AdminController (RoleManager<IdentityRole> roleManager,
                                UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            //this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CriaRole()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CriaRole(CriaRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListaRole", "Admin");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListaRole()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditaRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = "Não exite nenhum utilizador na função";
                return View("ListaRole");
            }

            var model = new EditaRole
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Utilizadores.Add(user.UserName);
                    //model.Utilizadores.Add(user.Name);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditaRole(EditaRole model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = "Não exite nenhum utilizador na função";
                return View("ListaRole");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListaRole");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditarUtilizadoresNosRoles(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = "Não exite nenhum utilizador na função";
                return View("ListaRole");
            }

            var model = new List<UtilizadoresNoRole>();

            foreach (var utilizador in userManager.Users)
            {
                var utilizadoresNoRole = new UtilizadoresNoRole
                {
                    UtilizadoresId = utilizador.Id,
                    UtilizadoresNome = utilizador.UserName
                    //UtilizadoresNome = utilizador.Name
                };

                if(await userManager.IsInRoleAsync(utilizador,role.Name))
                {
                    utilizadoresNoRole.Selecionado = true;
                }
                else
                {
                    utilizadoresNoRole.Selecionado = false;
                }

                model.Add(utilizadoresNoRole);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUtilizadoresNosRoles(List<UtilizadoresNoRole> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = "Não exite nenhum utilizador na função";
                return View("ListaRole");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var utilizador = await userManager.FindByIdAsync(model[i].UtilizadoresId);

                IdentityResult result = null;

                if (model[i].Selecionado && !(await userManager.IsInRoleAsync(utilizador, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(utilizador, role.Name);
                }
                else if (!model[i].Selecionado && await userManager.IsInRoleAsync(utilizador, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(utilizador, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditaRole", new { Id = roleId });
                    }
                }
            }

            return RedirectToAction("EditaRole", new { Id = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> ApagaRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = "Não exite nenhum utilizador na função";
                return View("ListaRole");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListaRole");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListaRole");
            }
        }
    }
}
