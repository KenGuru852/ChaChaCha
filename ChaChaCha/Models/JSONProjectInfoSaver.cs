using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class JSONProjectInfoSaver
    {
        //public void Save(List<ObservableCollection<IElement>> shapes, string path)
        public void Save(ObservableCollection<ProjectInfo> con, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.Serialize<ObservableCollection<ProjectInfo>>
                    (fs, con, new JsonSerializerOptions
                    {
                        Converters = { new ProjectJSONConverter() },
                        WriteIndented = true
                    });
            }
        }
    }
}
