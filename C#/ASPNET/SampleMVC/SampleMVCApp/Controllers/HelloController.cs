using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        #region Constructors

        /// <summary>
        /// Initializes a new isntance of the <see cref="HelloController"/> class.
        /// </summary>
        public HelloController()
        {
            this.countries.Add("Japan");
            this.countries.Add("USA");
            this.countries.Add("UK");
        }

        #endregion

        #region Properties

        public IList<string> countries = new List<string>();

        #endregion

        [HttpGet("Hello/{id?}/{username?}")]
        public IActionResult Index(int id, string username)
        {
            ViewData["Title"] = "Index/Hello!!!";

            ViewData["Message"] = "Input your data!";

            ViewData["name"] = string.Empty;
            ViewData["mail"] = string.Empty;
            ViewData["tel"] = string.Empty;

            ViewData["Selected countries label"] = "Select your country";
            ViewData["CurrentCountries"] = string.Empty;
            ViewData["Countries"] = this.countries;

            ViewData["SessionMessage"] = "セッションにIDとUsernameを保存しました";
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("username", username ?? string.Empty);

            return View();
        }

        [HttpGet]
        public IActionResult Other()
        {
            ViewData["Title"] = "Index/Hello!!!";

            ViewData["Message"] = "Input your data!";

            ViewData["name"] = string.Empty;
            ViewData["mail"] = string.Empty;
            ViewData["tel"] = string.Empty;

            ViewData["Selected countries label"] = "Select your country";
            ViewData["CurrentCountries"] = string.Empty;
            ViewData["Countries"] = this.countries;

            ViewData["SessionMessage"] = "保存されたセッションの値を表示します";
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");

            return View("Index");
        }

        // Sample1
        // HttpGetもあるが、[HttpGet, HttpPost]のときしか通常使わない（デフォルトでアクションはGetメソッドのため）
        //[HttpPost]
        //public IActionResult Form(string msg) // name属性と同じ引数名とすると、自動で値が渡ってくる
        //{
        // Requestクラス: クライアント(サーバ)から送られてくるリクエストに関する情報を管理するクラス
        // Responseクラス: ホスト(ゲスト)からクライアントへ送られる

        //ViewData["Message"] = Request.Form["msg"]; // "msg"はnameの値
        //ViewData["Message"] = msg;

        // "Index"アクション用のテンプレート（つまり「Hello」内のIndex.cshtml)をテンプレートとして指定
        //    return View("Index");
        //}

        [HttpPost]
        public IActionResult Form(string name, string mail, string tel)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["tel"] = tel;

            ViewData["message"] = ViewData["name"] + ", "
                                + ViewData["mail"] + ", "
                                + ViewData["tel"] + ", ";

            ViewData["Selected countries label"] = $"Select your country: {Request.Form["CurrentCountries"]}";
            ViewData["CurrentCountries"] = Request.Form["CurrentCountries"];
            ViewData["Countries"] = this.countries;

            return View("Index");
        }
    }
}
