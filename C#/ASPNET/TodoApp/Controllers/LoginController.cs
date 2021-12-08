using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [AllowAnonymous] // 未認証状態でログインコントローラへアクセス可能にする
    public class LoginController : Controller
    {
        private readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include="UserName,Password")]LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (this.membershipProvider.ValidateUser(loginViewModel.UserName, loginViewModel.Password))
                {
                    // Cookieにユーザ情報がある場合は，認証状態が維持される
                    FormsAuthentication.SetAuthCookie(loginViewModel.UserName, false);
                    return RedirectToAction("Index", "ToDoItems"); // TodoItemsコントローラのIndexへリダイレクト
                }
            }

            // 認証に失敗した場合は，ログイン画面へ戻す
            ViewBag.Message = "ログインに失敗しました";
            return View(loginViewModel);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); // Cookieからユーザ情報を削除
            return RedirectToAction("Index"); // ログイン画面へ戻す

        }
    }
}