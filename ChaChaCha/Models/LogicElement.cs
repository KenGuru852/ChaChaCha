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
        public List<int> conntecor_ids = new List<int>();
        public int output_value = 0;
        public void update(int oper, int current_id, ObservableCollection<IElement> shapes, Connector con)
        {
            int firstVal = con.FirstRectangle.output_value;
            int secondVal = 0;
            for (int i = 0; i < conntecor_ids.Count; i++)
            {
                if (conntecor_ids[i] != current_id)
                {
                    foreach(var item in shapes)
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
                if (con.FirstRectangle.output_value == 0)
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
                con.SecondRectangle.RealName = con.FirstRectangle.output_value.ToString();
            }
            //Debug.WriteLine(con.SecondRectangle.output_value);
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
