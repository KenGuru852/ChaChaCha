using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaChaCha.Models
{
    public interface IElement
    {
        string Name { get; set; }
        string RealName { get; set; }
        Point StartPoint { get; set; }
        string RecColor { get; set; }
        bool FirstInput { get; set; }
        bool SecondInput { get; set; }
        bool ThirdInput { get; set; }
        bool FirstOutput { get; set; }
        bool SecondOutput { get; set; }
        bool ThirdOutput { get; set; }

    }
}
