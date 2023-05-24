using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ChaChaCha.Models;
using ChaChaCha.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace ChaChaCha.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerReleased;
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnPointerReleased(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            if (pointerReleasedEventArgs.Source is Control control)
            {
                if (control.DataContext is not LogicElement)
                {
                    pointPointerReleased = pointerReleasedEventArgs.GetPosition(
                this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());
                    if(this.DataContext is MainWindowViewModel viewModel)
                    {
                        if (viewModel.ButtonPressed == 1)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 2)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 3)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 4)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 5)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 6)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                        else if (viewModel.ButtonPressed == 7)
                        {
                            viewModel.Shapes.Add(new LogicElement
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
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.ButtonPressed = 0;
                        }
                    }
                }
            }
            
        }
        private void OnPointerPressed(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Control control)
            {
                if (control.DataContext is LogicElement rectangle)
                {
                    pointPointerPressed = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas")));
                    if (this.DataContext is MainWindowViewModel vModel)
                    {
                        if (vModel.ButtonPressed == -1)
                        {
                            vModel.Shapes.Remove(rectangle);
                            vModel.ButtonPressed = 0;
                        }
                    }

                    if (pointerPressedEventArgs.Source is not Ellipse)
                    {
                        pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(control);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerPressedReleasedDragShape;
                    }
                    else
                    {
                        if (this.DataContext is MainWindowViewModel viewModel)
                        {
                            viewModel.Shapes.Add(new Connector
                            {
                                StartPoint = pointPointerPressed,
                                EndPoint = pointPointerPressed,
                                Name = "Connector",
                                FirstRectangle = rectangle,
                            });


                            this.PointerMoved += PointerMoveDrawLine;
                            this.PointerReleased += PointerPressedReleasedDrawLine;
                        }
                    }
                }
            }
        }

        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Control control)
            {
                if (control.DataContext is LogicElement rectangle)
                {
                    Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                    rectangle.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }

        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Connector connector = viewModel.Shapes[viewModel.Shapes.Count - 1] as Connector;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
            }
        }

        private void PointerPressedReleasedDrawLine(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);

            var element = canvas.InputHitTest(coords);
            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is LogicElement rectangle)
                {
                    Connector connector = viewModel.Shapes[viewModel.Shapes.Count - 1] as Connector;
                    connector.SecondRectangle = rectangle;
                    return;
                }
            }

            viewModel.Shapes.RemoveAt(viewModel.Shapes.Count - 1);
        }
    }
}