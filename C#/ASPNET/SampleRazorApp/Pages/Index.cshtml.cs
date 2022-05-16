using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Fields

        private readonly ILogger<IndexModel> _logger;

        #endregion

        #region Constructors

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Properties

        // BindProperty: クエリ文字列の値をモデルプロパティにバインディング
        // SupportsGet: GETメソッドによるアクセスを許可する(= "Id"という名前のクエリパラメータ値がそのままプロパティに格納される)
        [BindProperty(SupportsGet = true)]
        public int Id { get; }

        public string Message { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// このページにGETアクセスしたときに実行したい処理をこのメソッドに記述する
        /// </summary>
        public void OnGet()
        {
            this.Message = "入力してください";
        }

        public void OnPost(string name, string password, string mail, string tel)
        {
            this.Message = $"Name: {name} Password:({password.Length} chars) Mail: {mail} TEL: <{tel}>";

        }

        #endregion
    }
}
