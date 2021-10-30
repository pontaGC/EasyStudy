using System.Windows;

namespace CommandBinding
{
    /// <summary>
    /// Interaction logic for <see cref="App"/>.xaml.
    /// </summary>
    public sealed partial class App
    {
        /// <summary>
        /// Invokes starting up this application.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(),
            };

            mainWindow.ShowDialog();
        }
    }
}
