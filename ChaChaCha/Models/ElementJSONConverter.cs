using Avalonia.Controls.Shapes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class ElementJSONConverter : JsonConverter<Connector>
    {
        public override Connector? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return null;
        }
        public override void Write(Utf8JsonWriter writer, Connector value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value is Connector con)
            {
                writer.WriteString("id", con.connector_id.ToString());
                writer.WriteString("name", con.Name);
                writer.WriteString("X_Start", con.StartPoint.X.ToString());
                writer.WriteString("Y_Start", con.StartPoint.Y.ToString());
                writer.WriteString("X_End", con.EndPoint.X.ToString());
                writer.WriteString("Y_End", con.EndPoint.Y.ToString());
               
                writer.WriteString("First_Rec_Name", con.FirstRectangle.Name);
                writer.WriteString("First_Rec_RealName", con.FirstRectangle.RealName);
                writer.WriteString("First_Rec_RecColor", con.FirstRectangle.RecColor);
                writer.WriteString("First_Rec_Start_X", con.FirstRectangle.StartPoint.X.ToString());
                writer.WriteString("First_Rec_Start_Y", con.FirstRectangle.StartPoint.Y.ToString());
                writer.WriteString("First_Rec_Height", con.FirstRectangle.Height.ToString());
                writer.WriteString("First_Rec_Width", con.FirstRectangle.Width.ToString());
                writer.WriteString("First_Rec_FirstInput", con.FirstRectangle.FirstInput.ToString());
                writer.WriteString("First_Rec_SecondInput", con.FirstRectangle.SecondInput.ToString());
                writer.WriteString("First_Rec_ThirdInput", con.FirstRectangle.ThirdInput.ToString());
                writer.WriteString("First_Rec_FirstOutput", con.FirstRectangle.FirstOutput.ToString());
                writer.WriteString("First_Rec_SecondOutput", con.FirstRectangle.SecondOutput.ToString());
                writer.WriteString("First_Rec_ThirdOutput", con.FirstRectangle.ThirdOutput.ToString());
                writer.WriteString("Output_Value", con.FirstRectangle.output_value.ToString());
                writer.WriteString("Output_Value_2", con.FirstRectangle.output_value_second.ToString());
                writer.WriteStartArray("First_Rec_IDs");
                if (con.FirstRectangle.conntecor_ids != null)
                {
                    foreach (var item in con.FirstRectangle.conntecor_ids)
                    {
                        writer.WriteNumberValue(item);
                    }
                }
                writer.WriteEndArray();

                writer.WriteString("Second_Rec_Name", con.SecondRectangle.Name);
                writer.WriteString("Second_Rec_RealName", con.SecondRectangle.RealName);
                writer.WriteString("Second_Rec_RecColor", con.SecondRectangle.RecColor);
                writer.WriteString("Second_Rec_Start_X", con.SecondRectangle.StartPoint.X.ToString());
                writer.WriteString("Second_Rec_Start_Y", con.SecondRectangle.StartPoint.Y.ToString());
                writer.WriteString("Second_Rec_Height", con.SecondRectangle.Height.ToString());
                writer.WriteString("Second_Rec_Width", con.SecondRectangle.Width.ToString());
                writer.WriteString("Second_Rec_FirstInput", con.SecondRectangle.FirstInput.ToString());
                writer.WriteString("Second_Rec_SecondInput", con.SecondRectangle.SecondInput.ToString());
                writer.WriteString("Second_Rec_ThirdInput", con.SecondRectangle.ThirdInput.ToString());
                writer.WriteString("Second_Rec_FirstOutput", con.SecondRectangle.FirstOutput.ToString());
                writer.WriteString("Second_Rec_SecondOutput", con.SecondRectangle.SecondOutput.ToString());
                writer.WriteString("Second_Rec_ThirdOutput", con.SecondRectangle.ThirdOutput.ToString());
                writer.WriteString("Second_Value", con.SecondRectangle.output_value.ToString());
                writer.WriteString("Second_Value_2", con.SecondRectangle.output_value_second.ToString());
                writer.WriteStartArray("Second_Rec_IDs");
                if (con.SecondRectangle.conntecor_ids != null)
                {
                    foreach (var item in con.SecondRectangle.conntecor_ids)
                    {
                        writer.WriteNumberValue(item);
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
