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
        Point StartPoint { get; set; }

    }
}
