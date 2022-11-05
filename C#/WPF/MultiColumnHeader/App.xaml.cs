using System.Windows;

using MultiColumnHeader.MainWindowView;

namespace MultiColumnHeader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
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
