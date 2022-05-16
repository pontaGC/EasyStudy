using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// アプリケーションの設定情報
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(); // セッション(クライアントとホスト間の接続を維持する仕組み）を利用する
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // 開発モード時の例外ページ設定
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // リリースモード時の例外ページ設定
                app.UseExceptionHandler("/Home/Error"); // "/Home/Error/"をエラーページとしてハンドル

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // STS(Strict Transport Security)使用のためのミドルウェアを追加 => WebブラウザへHTTPS通信を行うように指示
                // HTML的な処理としては、Strict-Transport-Securityヘッダを追加している
                app.UseHsts(); 
            }

            // HTTPをHTTPSにリダイレクトする
            app.UseHttpsRedirection();

            //  静的ファイルの利用を可能にする
            app.UseStaticFiles();

            // 「ルーティング機能」をONにする
            // ルーティング機能: 特定のアドレスにアクセス時、特定の処理を設定できる機能 (ネットワークのルーティングとは違う意味）
            app.UseRouting();

            // 認証機能の追加
            app.UseAuthorization();

            // セッションを利用
            app.UseSession();

            // パイプラインの"最後に呼び出される"エンドポイントの設定
            app.UseEndpoints(endpoints =>
            {
                // MVCコントローラを利用したルートの設定 (MVCで実装するならMUSTな設定）
                // name: ルートの名前
                // patternがテンプレート
                // - {controller=Home}: コントローラ名。"Home"はデフォルト値
                // - {action=iIndex}: アクション名。"Index"はデフォルト値
                // - {id?}: ID値。上記2つと異なり、省略可能
                //
                // 例) 「/abc/xyz/123」とアクセスされた場合は、「abcコントローラのxyzアクションに123というIDを付けて呼び出す」ということ
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoint =>
            {
                // 第一引数のパスにアクセスすると、第2引数の処理を実行する
                endpoint.MapGet("/",
                                async context => await context.Response.WriteAsync("Hello world"));
            });
        }
    }
}
