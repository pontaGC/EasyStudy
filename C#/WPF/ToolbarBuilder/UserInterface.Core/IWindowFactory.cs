using System.Windows;

namespace ToolbarBuilder.UserInterface.Core
{
    /// <summary>
    /// Creates the instances of <see cref="Window"/>.
    /// </summary>
    public interface IWindowFactory
    {
        /// <summary>
        /// Creates a main window.
        /// </summary>
        /// <returns>An instance of the main window.</returns>
        Window CreateMainWindow();
    }
}
