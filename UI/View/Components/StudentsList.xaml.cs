using DataLayer.Database;
using System.Windows.Controls;
using UI.ViewModel;

namespace UI.View.Components
{
    public partial class StudentsList : UserControl
    {
        private StudentsListViewModel viewModel = new StudentsListViewModel();

        public StudentsList()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            students.Items.Clear();
            students.ItemsSource = viewModel.Records;
        }
    }
}
