using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
