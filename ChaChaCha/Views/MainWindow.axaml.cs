using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ChaChaCha.Models;
using ChaChaCha.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChaChaCha.Views
{
    public partial class MainWindow : Window
    {
        readonly MainWindowViewModel firstWindow;
        int id_counter = 0;
        private Point pointPointerReleased;
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        public MainWindow()
        {
            InitializeComponent();
            firstWindow = new MainWindowViewModel();
            DataContext =firstWindow;
            firstWindow.AddWindow(this);
        }
        public async void ExitClick(object? sender, RoutedEventArgs eventArgs)
        {
            pointerPositionIntoShape = new Point(-104821, double.Parse("asaisrfy"));
        }
        public async void ExportClick(object? sender, RoutedEventArgs eventArgs)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveProject(path);
                }
            }
        }
        public async void ImportClick(object? sender, RoutedEventArgs eventsArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
               new FileDialogFilter
               {
                   Name = "JSON files",
                   Extensions = new string[] { "json" }.ToList(),
                   
               });
            openFileDialog.AllowMultiple = true;
            string[]? path = await openFileDialog.ShowAsync(this);
            foreach (var item in path)
            {
                Debug.WriteLine(item);
            }

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadProject(path);
                    int newid = 0;
                    foreach(var item in dataContext.All_connectors)
                    {
                        if (item.connector_id > newid)
                        {
                            newid = item.connector_id;
                        }
                    }
                    id_counter += 100;
                    dataContext.Content = dataContext.allContent[1];
                    dataContext.StartWindow = true;
                }
            }
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
                            viewModel.Logic_elements.Add(new LogicElement
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
                            viewModel.Logic_elements.Add(new LogicElement
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
                            viewModel.Logic_elements.Add(new LogicElement
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
                            viewModel.Logic_elements.Add(new LogicElement
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
                            viewModel.Logic_elements.Add(new LogicElement
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
                                RealName = "0",
                                RecColor = "Green",
                                FirstInput = false,
                                SecondInput = false,
                                ThirdInput = false,
                                FirstOutput = false,
                                SecondOutput = true,
                                ThirdOutput = false,
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.Logic_elements.Add(new LogicElement
                            {
                                Height = 100,
                                Width = 100,
                                Name = "Input",
                                RealName = "0",
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
                                RealName = "0",
                                RecColor = "Red",
                                FirstInput = false,
                                SecondInput = true,
                                ThirdInput = false,
                                FirstOutput = false,
                                SecondOutput = false,
                                ThirdOutput = false,
                                StartPoint = pointPointerReleased,
                            });
                            viewModel.Logic_elements.Add(new LogicElement
                            {
                                Height = 100,
                                Width = 100,
                                Name = "Output",
                                RealName = "0",
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
                        if (pointerPressedEventArgs.Source is not Ellipse)
                        {
                            if (vModel.ButtonPressed == 0)
                            {
                                if (rectangle.Name == "Input")
                                {
                                    if (rectangle.RealName == "0")
                                    {
                                        rectangle.output_value = 1;
                                        rectangle.RealName = "1";
                                        vModel.Update();
                                    }
                                    else
                                    { rectangle.RealName = "0";
                                        rectangle.output_value = 0;
                                        vModel.Update();
                                    }
                                }
                            }
                            if (vModel.ButtonPressed == -1)
                            {
                                vModel.Shapes.Remove(rectangle);
                                vModel.Logic_elements.Remove(rectangle);
                                vModel.ButtonPressed = 0;
                            }
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
                                connector_id = id_counter++,
                                FirstRectangle = rectangle,
                            });
                            viewModel.All_connectors.Add(new Connector
                            {
                                StartPoint = pointPointerPressed,
                                EndPoint = pointPointerPressed,
                                Name = "Connector",
                                connector_id = id_counter - 1,
                                FirstRectangle = rectangle,
                            });
                            this.PointerMoved += PointerMoveDrawLine;
                            this.PointerReleased += PointerPressedReleasedDrawLine;
                        }
                    }
                }
                else if (control.DataContext is Connector connector)
                {
                    if (this.DataContext is MainWindowViewModel vModel)
                    {
                        if (vModel.ButtonPressed == -1)
                        {
                            vModel.Shapes.Remove(connector);
                            vModel.All_connectors.Remove(connector);
                            vModel.ButtonPressed = 0;
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
                Connector connector2 = viewModel.All_connectors[viewModel.All_connectors.Count - 1] as Connector;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
                connector2.EndPoint = new Point(
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
                    Connector connector2 = viewModel.All_connectors[viewModel.All_connectors.Count - 1] as Connector;
                    connector.SecondRectangle = rectangle;
                    connector2.SecondRectangle = rectangle;
                    rectangle.conntecor_ids.Add(id_counter - 1);
                    //Debug.WriteLine(rectangle.conntecor_ids.Count);
                    if (this.DataContext is MainWindowViewModel vvModel)
                    {
                        vvModel.Update();
                    }
                    return;
                }
            }

            viewModel.Shapes.RemoveAt(viewModel.Shapes.Count - 1);
            viewModel.All_connectors.RemoveAt(viewModel.All_connectors.Count - 1);
        }
    }
}