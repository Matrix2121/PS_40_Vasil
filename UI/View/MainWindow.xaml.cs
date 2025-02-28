using System.Windows;

namespace UI.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLogWindow_Click(object sender, RoutedEventArgs e)
        {
            LogsWindow newWindow = new LogsWindow();
            newWindow.Show();
        }
    }
}