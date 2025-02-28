using DataLayer.Database;
using System.Windows.Controls;

namespace UI.View.Components
{
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();
            using(var context = new DatabaseContext())
            {
                var records = context.Users.ToList();
                students.Items.Clear();
                students.ItemsSource = records;
            }
        }
    }
}
