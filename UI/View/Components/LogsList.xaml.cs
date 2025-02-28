using DataLayer.Database;
using System.Windows;
using System.Windows.Controls;

namespace UI.View.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new DatabaseContext())
            {
                var records = context.Logs.ToList();
                logs.Items.Clear();
                logs.ItemsSource = records;
            }
        }
        private void OpenMessage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string message)
            {
                MessageBox.Show(message, "Log Message", MessageBoxButton.OK);
            }
        }
    }
}
