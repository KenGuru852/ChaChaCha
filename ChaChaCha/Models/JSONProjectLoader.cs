﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class JSONProjectLoader
    {
        public ObservableCollection<Connector> Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ObservableCollection<Connector>? connectors = JsonSerializer.Deserialize<ObservableCollection<Connector>>(fs);

                if (connectors == null)
                {
                    connectors = new ObservableCollection<Connector>();
                }

                return connectors;
            }
        }
    }
}
