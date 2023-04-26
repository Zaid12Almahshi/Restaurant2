using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Linq;
using Restaurant.ViewModels;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Restaurant.Data;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public AppDbcontext Db { get; }

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager,AppDbcontext _db)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
            Db = _db;
        }
        // GET: AccountController1
        
        public ActionResult Index()
        {
            var user = UserManager.Users.Select(x=>new UsersModel
            {

                Email= x.Email,
                Id  =x.Id,
                UserName   =x.UserName,

            }).ToList();

            return View(user);
        }

        // GET: AccountController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Enter Email and password");
                    return View();
                }
                var User = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email
                };
                var Resault = await UserManager.CreateAsync(User, collection.Password);
                if (Resault.Succeeded)
                {
                    await SignInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "wrong Email or Password");
                    return View();
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Enter Email and password");
                return View();
            }

            var Resault = await SignInManager.PasswordSignInAsync(collection.Email, collection.Password, isPersistent: collection.RememberMe, false);
            if (Resault.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "wrong Email or Password");
                return View();
            }
            return View();
        }
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
        // GET: AccountController1/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var data = await UserManager.FindByIdAsync(id);
           
            UsersModel model = new UsersModel();
            model.Email = data.Email;
            model.UserName=data.UserName;

            return View(model);
        }

        // POST: AccountController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( string id,UsersModel collection)
        {
            try
            {
               
                    var user = await UserManager.FindByIdAsync(collection.Id);
                //user.PasswordHash = UserManager.PasswordHasher.HashPassword(user, collection.Password);
                //var data = await UserManager.UpdateAsync(user);
                //return RedirectToAction("Index", "Account");

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {collection.Id} cannot be found";
                    return View("NotFound");
                }
                else if (user != null)
                {
                    user.Email = collection.Email;
                    user.UserName = collection.UserName;
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(user, collection.Password);



                    var result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(collection);


                }
                return RedirectToAction("Index", "Account");

            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController1/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var data = await UserManager.FindByIdAsync(id);
            var delete = await UserManager.DeleteAsync(data);
            return RedirectToAction("Index", "Account");
        }

        // POST: AccountController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
