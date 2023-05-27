using Avalonia;
using ChaChaCha.ViewModels;
using DynamicData.Binding;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class LogicElement : AbstractNotifyPropertyChanged, IElement
    {
        private Point startPoint;
        private double height;
        private double width;
        private bool firstinput;
        private bool secondinput;
        private bool thirdinput;
        private bool firstoutput;
        private string realname;
        private bool secondoutput;
        private bool thirdoutput;
        private string reccolor;
        private List<int> con_ids { get; set; }
        public List<int> connector_ids
        {
            get;
            set;
        }
        public List<int> conntecor_ids = new List<int>();
        public int output_value = 0;
        public int output_value_second = 0;

        private int OutputChooser(Connector con, ObservableCollection<IElement> shapes, LogicElement firstElement)
        {
            int first_id = con.connector_id;
            int second_id = 0;
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] is Connector secondcon)
                {
                    if (secondcon.connector_id != first_id)
                    {
                        if (secondcon.FirstRectangle == firstElement)
                        {
                            second_id = secondcon.connector_id;
                        }
                    }
                }
            }
            if (first_id < second_id)
            {
                return firstElement.output_value;
            }
            if (first_id > second_id)
            {
                return firstElement.output_value_second;
            }
            return 0;
        }
        public void update(int oper, int current_id, ObservableCollection<IElement> shapes, Connector con)
        {
            int firstVal = 0;
            if (con.FirstRectangle.Name == "SM")
            {
                firstVal = OutputChooser(con, shapes, con.FirstRectangle);
            }
            else
            {
                firstVal = con.FirstRectangle.output_value;
            }
            int secondVal = 0;
            int thirdVal = 0;
            if (oper == 1 || oper == 2 || oper == 3 || oper == 4 || oper == 7)
            {
                for (int i = 0; i < conntecor_ids.Count; i++)
                {
                    if (conntecor_ids[i] != current_id)
                    {
                        foreach (var item in shapes)
                        {
                            if (item is Connector tempcon)
                            {
                                if (tempcon.connector_id == conntecor_ids[i])
                                {
                                    secondVal = tempcon.FirstRectangle.output_value;
                                }
                            }
                        }
                    }
                }
            }
            if (oper == 5)
            {
                for (int i = 0; i < conntecor_ids.Count; i++)
                {
                    foreach (var item in shapes)
                    {
                        if (item is Connector tempcon)
                        {
                            if (tempcon.connector_id == conntecor_ids[i] && i == 0)
                            {
                                firstVal = tempcon.FirstRectangle.output_value;
                            }
                            if (tempcon.connector_id == conntecor_ids[i] && i == 1)
                            {
                                secondVal = tempcon.FirstRectangle.output_value;
                            }
                            if (tempcon.connector_id == conntecor_ids[i] && i == 2)
                            {
                                thirdVal = tempcon.FirstRectangle.output_value;
                            }
                        }
                    }
                }
                int temp = firstVal + secondVal + thirdVal;
                if (temp == 0)
                {
                    output_value = 0;
                    output_value_second = 0;
                }
                if (temp == 1)
                {
                    output_value = 1;
                    output_value_second = 0;
                }
                if (temp == 2)
                {
                    output_value = 0;
                    output_value_second = 1;
                }
                if (temp == 3)
                {
                    output_value = 1;
                    output_value_second = 1;
                }
               /* Debug.WriteLine("Summator: ");
                Debug.WriteLine("X1 = ");
                Debug.WriteLine(firstVal);
                Debug.WriteLine("X2 = ");
                Debug.WriteLine(secondVal);
                Debug.WriteLine("X3 = ");
                Debug.WriteLine(thirdVal);
                Debug.WriteLine("First Output = ");
                Debug.WriteLine(output_value);
                Debug.WriteLine("Second output = ");
                Debug.WriteLine(output_value_second);
                Debug.WriteLine("------------------------------");*/
            }
            if (oper == 1)
            {
                con.SecondRectangle.output_value = firstVal * secondVal;
            }
            if (oper == 2)
            {
                con.SecondRectangle.output_value = firstVal + secondVal;
                if (con.SecondRectangle.output_value == 2)
                {
                    con.SecondRectangle.output_value = 1;
                }
            }
            if (oper == 3)
            {
                if (firstVal == 0)
                    con.SecondRectangle.output_value = 1;
                else con.SecondRectangle.output_value = 0;
            }
            if (oper == 4)
            {
                int tomp = firstVal + secondVal;
                if (tomp == 1)
                {
                    con.SecondRectangle.output_value = 1;
                }
                else con.SecondRectangle.output_value = 0;
            }
            if (oper == 7)
            {
                if (con.FirstRectangle.Name == "SM")
                {
                    con.SecondRectangle.RealName = OutputChooser(con, shapes, con.FirstRectangle).ToString();
                }
                else
                con.SecondRectangle.RealName = con.FirstRectangle.output_value.ToString();
            }
            //Debug.WriteLine(con.SecondRectangle.output_value);
            Debug.WriteLine(conntecor_ids.Count);
        }
        public string RealName
        {
            get => realname;
            set => SetAndRaise(ref realname, value);
        }
        public string Name { get; set; }

        public string RecColor
        {
            get => reccolor;
            set => reccolor = value;
        }
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                Point oldPoint = StartPoint;
                
                SetAndRaise(ref startPoint, value);

                if (ChangeStartPoint != null)
                {
                    ChangeStartPointEventArgs args = new ChangeStartPointEventArgs
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = StartPoint,
                    };
                    
                    ChangeStartPoint(this, args);
                }
            }
        }
        public double Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        public bool FirstInput
        {
            get => firstinput;
            set => SetAndRaise(ref firstinput, value);
        }
        public bool SecondInput
        {
            get => secondinput;
            set => SetAndRaise(ref secondinput, value);
        }
        public bool ThirdInput
        {
            get => thirdinput;
            set => SetAndRaise(ref thirdinput, value);
        }
        public bool FirstOutput
        {
            get => firstoutput;
            set => SetAndRaise(ref firstoutput, value);
        }
        public bool SecondOutput
        {
            get => secondoutput;
            set => SetAndRaise(ref secondoutput, value);
        }
        public bool ThirdOutput
        {
            get => thirdoutput;
            set => SetAndRaise(ref thirdoutput, value);
        }
        public double Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
        public event EventHandler<ChangeStartPointEventArgs> ChangeStartPoint;
    }
}
