using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleRazorApp.Pages
{
    public enum Gender
    {
        Male,
        Female,
    }

    public enum Platform
    {
        Windows,
        MacOS,
        Linux,
        ChromeOS,
        Android,
        iOS,
    }

    public class OtherModel : PageModel
    {
        #region Properties

        public string Message { get; set; }

        public bool Check { get; set; }

        public Gender Gender { get; set; }

        public Platform Platform { get; set; }

        public Platform[] Platforms { get; set; }

        #endregion

        public void OnGet()
        {
            this.Message = "check & select it";
        }

        public void OnPost(bool check, string gender, Platform platform, Platform[] platforms)
        {
            this.Message = $"Result: {check}, {gender}, {platform} {platforms.Length}";
        }
    }
}
