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
    public class JSONProjectInfoLoader
    {
        public ObservableCollection<ProjectInfo> Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ObservableCollection<ProjectInfo>? load_projects =
                     JsonSerializer.Deserialize<ObservableCollection<ProjectInfo>>(fs, new
                     JsonSerializerOptions
                     {
                         Converters = { new ProjectJSONConverter() },
                         WriteIndented = true
                     });
                /* ObservableCollection<Connector>? connectors = JsonSerializer.Deserialize<ObservableCollection<Connector>>(fs);

                 if (connectors == null)
                 {
                     connectors = new ObservableCollection<Connector>();
                 }
 */
                return load_projects;
            }
        }
    }
}
