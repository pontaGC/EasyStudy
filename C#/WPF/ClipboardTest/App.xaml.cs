using System.Windows;

namespace ClipboardTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <inheritdoc />
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
