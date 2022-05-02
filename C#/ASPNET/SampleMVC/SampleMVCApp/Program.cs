using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp
{
    // NOTE: ASP.NET MVC�̃������R�����g�ŏ����Ă���
    // �����̓��e => https://www.amazon.co.jp/%E3%83%95%E3%83%AC%E3%83%BC%E3%83%A0%E3%83%AF%E3%83%BC%E3%82%AF-ASP-NET-Core3%E5%85%A5%E9%96%80-%E6%8E%8C%E7%94%B0-%E6%B4%A5%E8%80%B6%E4%B9%83/dp/479806050X

    public class Program
    {
        public static void Main(string[] args)
        {
            // Web�z�X�g���쐬���A�N��
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Startup�N���X�Ńz�X�g�N�����̏������ݒ���s��
                    webBuilder.UseStartup<Startup>();
                });
    }
}
