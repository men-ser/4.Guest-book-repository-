using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Guest_book.Models;
using System.Security.Cryptography;
using System.Text;
using Guest_book.Repository;

namespace Guest_book.Controllers
{
    public class AccountController : Controller
    {

        //private readonly GuestBookContext _context;
        IRepository repo;

        public AccountController(IRepository r)
        {
            repo = r;
        }

        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }

        // GET: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel logon)
        {
            if (ModelState.IsValid)
            {
                if (repo.GetUsersCount() == 0)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                var users = repo.GetUserByLogin(logon);//_context.Users.Where(a => a.Login == logon.Login);
                if (users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                var user = users.First();
                //string? salt = user.Salt;

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes( logon.Password); //salt +

                //создаем объект для получения средств шифрования  
                var md5 = MD5.Create();

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = md5.ComputeHash(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                HttpContext.Session.SetString("login", user.Login);
                return RedirectToAction("Index", "Home");
            }
            return View(logon);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationModel reg)
        {
            if (repo.GetUsersCount() != 0)  //_context.Users.ToList().Count
            {
                foreach (var user in repo.GetUsersList())
                    {
                    if (reg.Login == user.Login)
                    {
                        ModelState.AddModelError("", "Такой логин уже используется!");
                    }
                    }
            }

            if (ModelState.IsValid)
            {
                
                User user = new User();
                user.Login = reg.Login;

                #region salt 
                //byte[] saltbuf = new byte[16];

                //RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                //randomNumberGenerator.GetBytes(saltbuf);

                //StringBuilder sb = new StringBuilder(16);
                //for (int i = 0; i < 16; i++)
                //    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                //string salt = sb.ToString();
                #endregion

                byte[] password = Encoding.Unicode.GetBytes( reg.Password); //salt +
                var md5 = MD5.Create();
                byte[] byteHash = md5.ComputeHash(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                user.Password = hash.ToString();
                //user.Salt = salt;
                repo.CreateUser(user);//_context.Users.Add(user);
                repo.Save();          //_context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(reg);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
