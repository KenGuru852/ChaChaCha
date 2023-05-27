using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml.Templates;
using ChaChaCha.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using PathFile = System.IO.Path;

namespace ChaChaCha.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private ObservableCollection<IElement> shapes;
        public ObservableCollection<IElement> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }
        private ObservableCollection<LogicElement> logic_elements;
        public ObservableCollection<LogicElement> Logic_elements
        {
            get => logic_elements;
            set => this.RaiseAndSetIfChanged(ref logic_elements, value);
        }
        private ObservableCollection<Connector> all_connectors;
        public ObservableCollection<Connector> All_connectors
        {
            get => all_connectors;
            set => this.RaiseAndSetIfChanged(ref all_connectors, value);
        }
        private ObservableCollection<string> shapes_name;
        public ObservableCollection<string> Shapes_name
        {
            get => shapes_name;
            set => this.RaiseAndSetIfChanged(ref shapes_name, value);
        }
        private List<ObservableCollection<IElement>> shapesList;
        //////////////////// ДЛЯ ДОБАВЛЕНИЯ ФИГУР НА ПОЛОТНО ////////////////////////////////
        private int buttonpressed;
        public int ButtonPressed
        {
            get => buttonpressed;
            set => this.RaiseAndSetIfChanged(ref buttonpressed, value);
        }
        private int circNumber;
        public int CircNumber
        {
            get => circNumber;
            set
            {
                this.RaiseAndSetIfChanged(ref circNumber, value);
                if (CircNumber == -1)
                {
                    CircNumber = 0;
                }
                Shapes = shapesList[CircNumber];
            
            }
        }
        private int andButton;
        public int AndButton
        {
            get => andButton;
            set => this.RaiseAndSetIfChanged(ref andButton, value);
        }
        private string currentCircName;
        public string CurrentCircName
        {
            get => currentCircName;
            set
            {
                this.RaiseAndSetIfChanged(ref currentCircName, value);
                //shapes_name[circNumber] = currentCircName;
            }
        }
        private int orButton;
        public int OrButton
        {
            get => orButton;
            set => this.RaiseAndSetIfChanged(ref orButton, value);
        }
        private int notButton;
        public int NotButton
        {
            get => notButton;
            set => this.RaiseAndSetIfChanged(ref notButton, value);
        }
        private int xorButton;
        public int XorButton
        {
            get => xorButton;
            set => this.RaiseAndSetIfChanged(ref xorButton, value);
        }
        private int smButton;
        public int SMButton
        {
            get => smButton;
            set => this.RaiseAndSetIfChanged(ref smButton, value);
        }
        private int inputButton;
        public int InputButton
        {
            get => inputButton;
            set => this.RaiseAndSetIfChanged(ref inputButton, value);
        }
        private int outputButton;
        public int OutputButton
        {
            get => outputButton;
            set => this.RaiseAndSetIfChanged(ref outputButton, value);
        }
        /////////////////////////////////////////////////////////////////////////////////////
        public JSONProjectSaver jsonSaver = new JSONProjectSaver();
        public JSONProjectLoader jsonLoader = new JSONProjectLoader();
        public MainWindowViewModel()
        {
            logic_elements = new ObservableCollection<LogicElement>();
            all_connectors = new ObservableCollection<Connector>();
            shapes_name = new ObservableCollection<string>();
            shapes_name.Add("first_citcuit");
            currentCircName = shapes_name[0];
            Shapes = new ObservableCollection<IElement>();
            shapesList= new List<ObservableCollection<IElement>>();
            shapesList.Add(Shapes);
            CircNumber = 0;
            Debug.WriteLine(shapesList.Count);
            buttonpressed = 0;
            //(ObservableCollection<LogicElement>, ObservableCollection<Connector>) tuple = (logic_elements, all_connectors);
        }
        public void ElementToDraw(int number)
        {
            buttonpressed = number;
        }
        public void AddCircuit()
        {
            shapesList.Add(new ObservableCollection<IElement>());
            shapes_name.Add("new_circuit");
        }
        public void DeleteCircuit()
        {
            int temp = circNumber;
            if (shapesList.Count > 1) 
            {
                shapesList.RemoveAt(temp);
                shapes_name.RemoveAt(temp);
                circNumber = 0;
            }
        }
        public void Rename()
        {

            shapes_name[circNumber] = currentCircName;
        }
        public void SaveProject(string path)
        {
            if (PathFile.GetExtension(path) == ".json")
            {
                //jsonSaver.Save(shapesList, path);
                jsonSaver.Save(all_connectors, path);
            }
        }
        public void LoadProject(string path)
        {
            All_connectors = new ObservableCollection<Connector>(jsonLoader.Load(path));
            Shapes.Clear();
/*            foreach(var item in All_connectors)
            {
                Debug.WriteLine(item.SecondRectangle.RecColor);
            }*/
            foreach(var item in All_connectors)
            {
                Shapes.Add(item);
                if ((item.FirstRectangle.Name == "Input") || item.FirstRectangle.Name == "Output")
                {
                    Shapes.Add(item.FirstRectangle);
                }
                if ((item.SecondRectangle.Name == "Input") || item.SecondRectangle.Name == "Output")
                {
                    Shapes.Add(item.SecondRectangle);
                }
            }
            foreach(var item in All_connectors)
            {
                if((item.SecondRectangle.Name == "And") || (item.SecondRectangle.Name == "Or") || (item.SecondRectangle.Name == "XOR") || (item.SecondRectangle.Name == "Not") || (item.SecondRectangle.Name == "SM"))
                {
                    Shapes.Add(item.SecondRectangle);
                    int temp = item.connector_id;
                    foreach(var tempo in item.SecondRectangle.conntecor_ids)
                    {
                        if (tempo != temp)
                        {
                            foreach(var please in All_connectors)
                            {
                                if (please.connector_id == tempo)
                                {
                                    please.SecondRectangle = item.SecondRectangle; break;
                                }
                            }
                        }
                    }
                    foreach(var yuppi in All_connectors)
                    {
                        var temp2 = yuppi.FirstRectangle.StartPoint;
                        foreach (var yoppi in Shapes)
                        {
                            if (yoppi is LogicElement elem)
                            {
                                if (yoppi.StartPoint == temp2)
                                {
                                    yuppi.FirstRectangle = elem;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Update();
            
            //Debug.WriteLine(All_connectors.Count);
        }
        public void Update()
        {
            for (int i = 0; i < 10;)
            {
                foreach (var item in Shapes)
                {
                    if (item is Connector connector)
                    {
                        int opertaion = 0;
                        switch (connector.SecondRectangle.Name)
                        {
                            case "And":
                                opertaion = 1;
                                break;
                            case "Or":
                                opertaion = 2;
                                break;
                            case "Not":
                                opertaion = 3;
                                break;
                            case "XOR":
                                opertaion = 4;
                                break;
                            case "SM":
                                opertaion = 5;
                                break;
                            case "Input":
                                opertaion = 6;
                                break;
                            case "Output":
                                opertaion = 7;
                                break;
                        }
                        if (opertaion != 0)
                        {
                            connector.SecondRectangle.update(opertaion, connector.connector_id, Shapes, connector);
                        }
                    }
                }
                i++;
            }
        }
    }
}