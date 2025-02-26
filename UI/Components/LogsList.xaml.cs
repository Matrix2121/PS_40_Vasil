using DataLayer.Database;
using System.Windows.Controls;

namespace UI.Components
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

                foreach (var log in records)
                {
                    Console.WriteLine($"ID: {log.Id}, Time: {log.TimeStamp}, Message: {log.Message}");
                }

                logs.Items.Clear();
                logs.ItemsSource = records;
            }
        }

    }
}
