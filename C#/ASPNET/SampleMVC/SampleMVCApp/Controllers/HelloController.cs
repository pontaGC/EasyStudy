using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Index/Hello!!!";

            ViewData["Message"] = "Input your data!";

            ViewData["name"] = string.Empty;
            ViewData["mail"] = string.Empty;
            ViewData["tel"] = string.Empty;

            return View();
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

            return View("Index");
        }
    }
}
