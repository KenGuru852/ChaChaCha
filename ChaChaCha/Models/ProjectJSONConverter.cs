using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class ProjectJSONConverter : JsonConverter<ProjectInfo>
    {
        public override ProjectInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Missed StartObject token");
            }
            reader.Read();
            string? nameProp = reader.GetString();
            reader.Read();
            string? nameValue = reader.GetString();

            reader.Read();
            string? dateProp = reader.GetString();
            reader.Read();
            string? dateValue = reader.GetString();

            reader.Read();
            string? SReсIDsProp = reader.GetString();
            reader.Read();
            string? SRecIDsProp1 = reader.GetString();

            bool to_count_next = true;
            List<string> newPaths = new List<string>();
            while (to_count_next)
            {
                reader.Read();
                string? IDs = reader.GetString();
                if (IDs != "id = ")
                {
                    reader.Read();
                    string? trash = reader.GetString();
                    to_count_next = false;
                    break;
                }
                else
                {
                    reader.Read();
                    string? NumID = reader.GetString();
                    newPaths.Add(NumID);
                }
            }

            ProjectInfo newproj = new ProjectInfo { Project_Name = nameValue, Project_Date = dateValue, Project_Path = newPaths };

            reader.Read();

            return newproj;
        }
        public override void Write(Utf8JsonWriter writer, ProjectInfo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("Project name", value.Project_Name);
            writer.WriteString("Project date", value.Project_Date);
            writer.WriteString("Project paths", "0");
            if (value.Project_Path != null)
            {
                for (int i = 0; i < value.Project_Path.Count; i++)
                {
                    writer.WriteString("id = ", value.Project_Path[i]);
                }
            }
            writer.WriteString("Project paths ends", "1");
            writer.WriteEndObject();
        }
    }
}
