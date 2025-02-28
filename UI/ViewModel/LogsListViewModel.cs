using DataLayer.Database;
using DataLayer.Model;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UI.ViewModel
{
    class LogsListViewModel : ObservableObject
    {
        private List<DatabaseLog> _records;

        public LogsListViewModel()
        {
            using(var context = new DatabaseContext())
            {
                _records = context.Logs.ToList();
            }
        }

        public List<DatabaseLog> Records
        {
            get { return _records; }
        }
        public void Show(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string message)
            {
                MessageBox.Show(message, "Log Message", MessageBoxButton.OK);
            }
        }
    }
}
