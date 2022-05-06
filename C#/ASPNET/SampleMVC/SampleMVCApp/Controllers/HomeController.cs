using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Actions

        // アクションはあらかじめ設定されたアドレスにクライアントがアクセスしたときに呼び出されるメソッド

        public IActionResult Index()
        {
            // Indexと紐づいたテンプレートファイル（cshtmlファイル）を返す

            // Viewメソッドでは、「コントローラ名」と「アクション名」をもとに、
            // 自動的に「どのテンプレートファイルを利用するか」を判断する
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // リスポンスをキャッシュする
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
