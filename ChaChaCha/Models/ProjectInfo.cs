using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class ProjectInfo : AbstractNotifyPropertyChanged
    {
        private string project_Name;
        public string Project_Name
        {
            get => project_Name;
            set => SetAndRaise(ref project_Name, value);
        }
        private string project_Date;
        public string Project_Date
        {
            get => project_Date;
            set => SetAndRaise(ref project_Date, value);
        }
        public List<string> Project_Path = new List<string>();
    }
}
