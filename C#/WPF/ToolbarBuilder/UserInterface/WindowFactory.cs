using System.Windows;

using ToolbarBuilder.UserInterface.Core;
using ToolbarBuilder.UserInterface.MainWindow;

namespace ToolbarBuilder.UserInterface
{
    /// <summary>
    /// Creates the instances of windows.
    /// </summary>
    internal sealed class WindowFactory : IWindowFactory
    {
        /// <summary>
        /// Creates a main window.
        /// </summary>
        /// <returns>An instance of the main window.</returns>
        public Window CreateMainWindow()
        {
            return new MainWindow.MainWindow()
            {
                DataContext = new MainWindowViewModel(),
            };
        }
    }
}
