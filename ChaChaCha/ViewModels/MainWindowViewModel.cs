using Avalonia.Controls.Shapes;
using ChaChaCha.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ChaChaCha.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<IElement> shapes;

        public MainWindowViewModel()
        {
            Shapes = new ObservableCollection<IElement>();
            Shapes.Add(new LogicElement
            {
                Height = 100,
                FirstInput = true,
                SecondInput = false,
                ThirdInput = true,
                FirstOutput = false,
                SecondOutput = true,
                ThirdOutput = false,
                Width = 100,
                Name = "And",
                RealName = "And",
                RecColor = "Black",
                StartPoint = new Avalonia.Point(100, 100),
            });

            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                RealName = "Or",
                Name = "Or",
                RecColor = "Black",
                FirstInput = true,
                SecondInput = false,
                ThirdInput = true,
                FirstOutput = false,
                SecondOutput = true,
                ThirdOutput = false,
                StartPoint = new Avalonia.Point(400, 300),
            });
            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                Name = "Not",
                RealName = "Not",
                RecColor = "Black",
                FirstInput = false,
                SecondInput = true,
                ThirdInput = false,
                FirstOutput = false,
                SecondOutput = true,
                ThirdOutput = false,
                StartPoint = new Avalonia.Point(300, 200),
            });
            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                Name = "SM",
                RealName = "SM",
                RecColor = "Black",
                FirstInput = true,
                SecondInput = true,
                ThirdInput = true,
                FirstOutput = true,
                SecondOutput = false,
                ThirdOutput = true,
                StartPoint = new Avalonia.Point(150, 400),
            });
            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                Name = "XOR",
                RealName = "XOR",
                RecColor = "Black",
                FirstInput = true,
                SecondInput = false,
                ThirdInput = true,
                FirstOutput = false,
                SecondOutput = true,
                ThirdOutput = false,
                StartPoint = new Avalonia.Point(300, 400),
            });
            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                Name = "Input",
                RealName = "1",
                RecColor = "Green",
                FirstInput = false,
                SecondInput = false,
                ThirdInput = false,
                FirstOutput = false,
                SecondOutput = true,
                ThirdOutput = false,
                StartPoint = new Avalonia.Point(500, 500),
            });
            Shapes.Add(new LogicElement
            {
                Height = 100,
                Width = 100,
                Name = "Output",
                RealName = "1",
                RecColor = "Red",
                FirstInput = false,
                SecondInput = true,
                ThirdInput = false,
                FirstOutput = false,
                SecondOutput = false,
                ThirdOutput = false,
                StartPoint = new Avalonia.Point(500, 300),
            });
        }
        public ObservableCollection<IElement> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }
    }
}