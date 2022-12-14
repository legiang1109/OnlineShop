using Models.Dao;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password))   ;
                if (result == 1)
                {
                    var user = dao.GetByid(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                } else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                 }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa..");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View("Index");
        }
    }
}