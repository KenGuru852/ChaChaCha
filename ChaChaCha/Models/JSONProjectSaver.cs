using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class JSONProjectSaver
    {
        //public void Save(List<ObservableCollection<IElement>> shapes, string path)
        public void Save(ObservableCollection<Connector> con, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, con,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true
                    });
            }
        }
    }
}
