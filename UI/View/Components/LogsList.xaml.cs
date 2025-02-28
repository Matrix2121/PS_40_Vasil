using DataLayer.Database;
using System.Windows;
using System.Windows.Controls;
using UI.ViewModel;

namespace UI.View.Components
{
    public partial class LogsList : UserControl
    {
        private LogsListViewModel viewModel = new LogsListViewModel();
        public LogsList()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            logs.Items.Clear();
            logs.ItemsSource = viewModel.Records;
        }
        private void OpenMessage_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Show(sender, e);
        }
    }
}
