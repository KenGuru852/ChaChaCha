using Avalonia.Controls.Shapes;
using ChaChaCha.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Missed StartObject token");
            }
            reader.Read();
            string? idProp = reader.GetString();
            reader.Read();
            string? idValue = reader.GetString();

            reader.Read();
            string? nameProp = reader.GetString();
            reader.Read();
            string? nameValue = reader.GetString();

            reader.Read();
            string? XStartProp = reader.GetString();
            reader.Read();
            string? XStartValue = reader.GetString();

            reader.Read();
            string? YStartProp = reader.GetString();
            reader.Read();
            string? YStartValue = reader.GetString();

            reader.Read();
            string? XEndProp = reader.GetString();
            reader.Read();
            string? XEndValue = reader.GetString();

            reader.Read();
            string? YEndProp = reader.GetString();
            reader.Read();
            string? YEndValue = reader.GetString();



            reader.Read();
            string? FRecNameProp = reader.GetString();
            reader.Read();
            string? FRecNameValue = reader.GetString();

            reader.Read();
            string? FRecRealNameProp = reader.GetString();
            reader.Read();
            string? FRecRealNameValue = reader.GetString();

            reader.Read();
            string? FRecColorProp = reader.GetString();
            reader.Read();
            string? FRecColorValue = reader.GetString();

            reader.Read();
            string? FRecStartXProp = reader.GetString();
            reader.Read();
            string? FRecStartXValue = reader.GetString();

            reader.Read();
            string? FRecStartYProp = reader.GetString();
            reader.Read();
            string? FRecStartYValue = reader.GetString();

            reader.Read();
            string? FRecHeightProp = reader.GetString();
            reader.Read();
            string? FRecHeightValue = reader.GetString();

            reader.Read();
            string? FRecWidthProp = reader.GetString();
            reader.Read();
            string? FRecWidthValue = reader.GetString();

            reader.Read();
            string? FRecFirstInputProp = reader.GetString();
            reader.Read();
            string? FRecFirstInputValue = reader.GetString();

            reader.Read();
            string? FRecSecondInputProp = reader.GetString();
            reader.Read();
            string? FRecSecondInputValue = reader.GetString();

            reader.Read();
            string? FRecThirdInputProp = reader.GetString();
            reader.Read();
            string? FRecThirdInputValue = reader.GetString();

            reader.Read();
            string? FRecFirstOutputProp = reader.GetString();
            reader.Read();
            string? FRecFirstOutputValue = reader.GetString();

            reader.Read();
            string? FRecSecondOutputProp = reader.GetString();
            reader.Read();
            string? FRecSecondOutputValue = reader.GetString();

            reader.Read();
            string? FRecThirdOutputProp = reader.GetString();
            reader.Read();
            string? FRecThirdOutputValue = reader.GetString();

            reader.Read();
            string? FRecOutputValueProp = reader.GetString();
            reader.Read();
            string? FRecOutputValueValue = reader.GetString();

            reader.Read();
            string? FRecOutputValue_SecondProp = reader.GetString();
            reader.Read();
            string? FRecOutputValue_SecondValue = reader.GetString();

            reader.Read();
            string? FReсIDsProp = reader.GetString();
            reader.Read();
            string? FRecIDsProp1 = reader.GetString();

            bool to_count_next = true;
            List<int> newFirstIDs = new List<int>();
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
                    newFirstIDs.Add(int.Parse(NumID));
                }
            }


            reader.Read();
            string? SRecNameProp = reader.GetString();
            reader.Read();
            string? SRecNameValue = reader.GetString();

            reader.Read();
            string? SRecRealNameProp = reader.GetString();
            reader.Read();
            string? SRecRealNameValue = reader.GetString();

            reader.Read();
            string? SRecColorProp = reader.GetString();
            reader.Read();
            string? SRecColorValue = reader.GetString();

            reader.Read();
            string? SRecStartXProp = reader.GetString();
            reader.Read();
            string? SRecStartXValue = reader.GetString();

            reader.Read();
            string? SRecStartYProp = reader.GetString();
            reader.Read();
            string? SRecStartYValue = reader.GetString();

            reader.Read();
            string? SRecHeightProp = reader.GetString();
            reader.Read();
            string? SRecHeightValue = reader.GetString();

            reader.Read();
            string? SRecWidthProp = reader.GetString();
            reader.Read();
            string? SRecWidthValue = reader.GetString();

            reader.Read();
            string? SRecFirstInputProp = reader.GetString();
            reader.Read();
            string? SRecFirstInputValue = reader.GetString();

            reader.Read();
            string? SRecSecondInputProp = reader.GetString();
            reader.Read();
            string? SRecSecondInputValue = reader.GetString();

            reader.Read();
            string? SRecThirdInputProp = reader.GetString();
            reader.Read();
            string? SRecThirdInputValue = reader.GetString();

            reader.Read();
            string? SRecFirstOutputProp = reader.GetString();
            reader.Read();
            string? SRecFirstOutputValue = reader.GetString();

            reader.Read();
            string? SRecSecondOutputProp = reader.GetString();
            reader.Read();
            string? SRecSecondOutputValue = reader.GetString();

            reader.Read();
            string? SRecThirdOutputProp = reader.GetString();
            reader.Read();
            string? SRecThirdOutputValue = reader.GetString();

            reader.Read();
            string? SRecOutputValueProp = reader.GetString();
            reader.Read();
            string? SRecOutputValueValue = reader.GetString();

            reader.Read();
            string? SRecOutputValue_SecondProp = reader.GetString();
            reader.Read();
            string? SRecOutputValue_SecondValue = reader.GetString();

            reader.Read();
            string? SReсIDsProp = reader.GetString();
            reader.Read();
            string? SRecIDsProp1 = reader.GetString();

            to_count_next = true;
            List<int> newSecondIDs = new List<int>();
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
                    newSecondIDs.Add(int.Parse(NumID));
                }
            }


            Connector newcons = new Connector
            {
                connector_id = int.Parse(idValue),
                Name = nameValue,
                StartPoint = new Avalonia.Point(int.Parse(XStartValue), int.Parse(YStartValue)),
                EndPoint = new Avalonia.Point(int.Parse(XEndValue), int.Parse(YEndValue)),
                FirstRectangle = new LogicElement
                { Name = FRecNameValue,
                    RealName = FRecRealNameValue,
                    RecColor = FRecColorValue,
                    StartPoint = new Avalonia.Point(int.Parse(FRecStartXValue), int.Parse(FRecStartYValue)),
                    Height = int.Parse(FRecHeightValue),
                    Width = int.Parse(FRecWidthValue),
                    FirstInput = bool.Parse(FRecFirstInputValue),
                    SecondInput = bool.Parse(FRecSecondInputValue),
                    ThirdInput = bool.Parse(FRecThirdInputValue),
                    FirstOutput = bool.Parse(FRecFirstOutputValue),
                    SecondOutput = bool.Parse(FRecSecondOutputValue),
                    ThirdOutput = bool.Parse(FRecThirdOutputValue),
                    output_value = int.Parse(FRecOutputValueValue),
                    output_value_second = int.Parse(FRecOutputValue_SecondValue),
                    conntecor_ids = newFirstIDs
                },
                SecondRectangle = new LogicElement
                {
                    Name = SRecNameValue,
                    RealName = SRecRealNameValue,
                    RecColor = SRecColorValue,
                    StartPoint = new Avalonia.Point(int.Parse(SRecStartXValue), int.Parse(SRecStartYValue)),
                    Height = int.Parse(SRecHeightValue),
                    Width = int.Parse(SRecWidthValue),
                    FirstInput = bool.Parse(SRecFirstInputValue),
                    SecondInput = bool.Parse(SRecSecondInputValue),
                    ThirdInput = bool.Parse(SRecThirdInputValue),
                    FirstOutput = bool.Parse(SRecFirstOutputValue),
                    SecondOutput = bool.Parse(SRecSecondOutputValue),
                    ThirdOutput = bool.Parse(SRecThirdOutputValue),
                    output_value = int.Parse(SRecOutputValueValue),
                    output_value_second = int.Parse(SRecOutputValue_SecondValue),
                    conntecor_ids = newSecondIDs
                }
            };

            reader.Read();
                
            return newcons;
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
                writer.WriteString("First_Rec_IDs_Start", "0");
                if (con.FirstRectangle.conntecor_ids != null)
                {
                    for (int i = 0; i < con.FirstRectangle.conntecor_ids.Count; i++)
                    {
                        writer.WriteString("id = ", con.FirstRectangle.conntecor_ids[i].ToString());
                    }
                }
                writer.WriteString("First_Rec_IDs_End", "1");
/*                writer.WriteStartArray("First_Rec_IDs");
                if (con.FirstRectangle.conntecor_ids != null)
                {
                    foreach (var item in con.FirstRectangle.conntecor_ids)
                    {
                        writer.WriteNumberValue(item);
                    }
                }
                writer.WriteEndArray();*/

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
                writer.WriteString("Second_Rec_IDs_Start", "0");
                if (con.SecondRectangle.conntecor_ids != null)
                {
                    for (int i = 0; i < con.SecondRectangle.conntecor_ids.Count; i++)
                    {
                        writer.WriteString("id = ", con.SecondRectangle.conntecor_ids[i].ToString());
                    }
                }
                writer.WriteString("Second_Rec_IDs_End", "1");
                /*                writer.WriteStartArray("Second_Rec_IDs");
                                if (con.SecondRectangle.conntecor_ids != null)
                                {
                                    foreach (var item in con.SecondRectangle.conntecor_ids)
                                    {
                                        writer.WriteNumberValue(item);
                                    }
                                }
                                writer.WriteEndArray();*/
            }
            writer.WriteEndObject();
        }
    }
}
