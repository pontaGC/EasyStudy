using Microsoft.Extensions.DependencyInjection;

using System.Windows;

using ToolbarBuilder.UserInterface;
using ToolbarBuilder.UserInterface.Core;

namespace ToolbarBuilder
{
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

            var serviceProvider = container.BuildServiceProvider();

            // Performs the module initialization
            var uiInitializer = serviceProvider.GetService<IModuleInitializer>();
            uiInitializer.Initialize();

            // Shows a main window
            var windowFactory = serviceProvider.GetService<IWindowFactory>();
            var mainWindow = windowFactory.CreateMainWindow();

            mainWindow.ShowDialog();
        }
    }
}
