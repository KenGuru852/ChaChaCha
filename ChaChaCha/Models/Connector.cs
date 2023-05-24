using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public class Connector : AbstractNotifyPropertyChanged, IElement, IDisposable
    {
        private Point startPoint;
        private Point endPoint;
        private LogicElement firstRectangle;
        private LogicElement secondRectangle;
        private bool firstinput;
        private bool secondinput;
        private bool thirdinput;
        private bool firstoutput;
        private bool secondoutput;
        private bool thirdoutput;
        private string reccolor;
        public string RecColor
        {
            get => reccolor;
            set => reccolor = value;
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
        public string Name { get; set; }
        public string RealName { get; set; }
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }

        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }

        public LogicElement FirstRectangle
        {
            get => firstRectangle;
            set
            {
                if(firstRectangle != null)
                {
                    firstRectangle.ChangeStartPoint -= OnFirstRectanglePositionChanged;
                }

                firstRectangle = value;

                if(firstRectangle != null)
                {
                    firstRectangle.ChangeStartPoint += OnFirstRectanglePositionChanged;
                }
            }
        }

        public LogicElement SecondRectangle
        {
            get => secondRectangle;
            set
            {
                if (secondRectangle != null)
                {
                    secondRectangle.ChangeStartPoint -= OnSecondRectanglePositionChanged;
                }

                secondRectangle = value;

                if (secondRectangle != null)
                {
                    secondRectangle.ChangeStartPoint += OnSecondRectanglePositionChanged;
                }
            }
        }

        private void OnFirstRectanglePositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondRectanglePositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        }

        public void Dispose()
        {
            if (FirstRectangle != null)
            {
                FirstRectangle.ChangeStartPoint -= OnFirstRectanglePositionChanged;
            }

            if (SecondRectangle != null)
            {
                SecondRectangle.ChangeStartPoint -= OnSecondRectanglePositionChanged;
            }
        }
    }
}
