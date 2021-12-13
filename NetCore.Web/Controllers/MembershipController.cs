using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        private IUser? _user;

        public MembershipController(IUser user)
        {
            _user = user;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;

            if (ModelState.IsValid)
            {

            //    if (login.UserID.Equals(userId) && login.Password.Equals(password))
            if(_user.MatchTheUserInfo(login))  
                {
                TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";

                return RedirectToAction("index", "Membership");

                }
                else
                {
                    message = "로그인 실패";
                }
            }
            else
            {
                message = "로그인 정보를 올바르게 입력하세요";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }
    }
}
