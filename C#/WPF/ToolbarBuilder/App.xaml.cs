using Microsoft.Extensions.DependencyInjection;

using System.Windows;

using ToolbarBuilder.UserInterface;
using ToolbarBuilder.UserInterface.Core;

namespace ToolbarBuilder
{
    // 本ツールの目的: クライアント・サーバ構造をもつ
    // 結論: ToolBarはクライアントで生成して、サーバ側で注入する

    /// <summary>
    /// Interaction logic for <see cref="App"/>.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Startup the application.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Prepares DI container
            var container = new ServiceCollection();

            var uiContainerRegistrar = new DependencyRegistrar();
            uiContainerRegistrar.Register(container);

            container.AddSingleton<IMainWindowInitializer, MainWindowInitializer>();

            var serviceProvider = container.BuildServiceProvider();

            // Shows a main window
            var windowFactory = serviceProvider.GetService<IWindowFactory>();
            var mainWindow = windowFactory.CreateMainWindow();

            var mainWindowInitializer = serviceProvider.GetService<IMainWindowInitializer>();
            mainWindowInitializer.Initialize();

            mainWindow.ShowDialog();
        }
    }
}
