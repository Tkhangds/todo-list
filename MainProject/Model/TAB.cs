using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Model
{
    public class TAB
    {
        [Key]
        public int TabId { get; set; }

        public string Title { get; set; }

        public ObservableCollection<TASK> TASKs { get; set; } = new ObservableCollection<TASK>();
    }
}
