using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Database;
using DataLayer.Model;

namespace UI.ViewModel
{
    public class StudentsListViewModel : ObservableObject
    {
        private List<DatabaseUser> _records;
        public StudentsListViewModel()
        {
            using (var context = new DatabaseContext())
            {
                _records = context.Users.ToList();
            }
        }
        public List<DatabaseUser> Records
        {
            get { return _records; }
        }
    }
}
