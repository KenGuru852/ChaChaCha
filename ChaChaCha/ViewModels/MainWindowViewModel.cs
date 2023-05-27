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
        private int circNumber = 0;
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
                if (shapesList.Count != 0)
                {
                    Shapes = shapesList[circNumber];
                    All_connectors.Clear();
                    foreach (var item in Shapes)
                    {
                        if (item is Connector connector)
                        {
                            All_connectors.Add(connector);
                        }
                    }
                    Debug.WriteLine(circNumber);
                }
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
        private List<int> all_id;
        public List<int> allid
        {
            get => all_id;
            set => this.RaiseAndSetIfChanged(ref all_id, value);
        }
        /////////////////////////////////////////////////////////////////////////////////////
        public JSONProjectSaver jsonSaver = new JSONProjectSaver();
        public JSONProjectLoader jsonLoader = new JSONProjectLoader();
        public MainWindowViewModel()
        {
            allid = new List<int>();
            logic_elements = new ObservableCollection<LogicElement>();
            all_connectors = new ObservableCollection<Connector>();
            shapes_name = new ObservableCollection<string>();
            shapes_name.Add("first_citcuit");
            currentCircName = shapes_name[0];
            Shapes = new ObservableCollection<IElement>();
            shapesList= new List<ObservableCollection<IElement>>();
            shapesList.Add(Shapes);
            CircNumber = 0;
            //Debug.WriteLine(shapesList.Count);
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
            if (shapesList != null)
            {
                string[] temp = path.Split("\\");
                string newpath = "";
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    newpath += temp[i] + "\\";
                }
                for (int i = 0; i < shapesList.Count; i++)
                {
                    string newpath_temp = newpath + shapes_name[i] + ".json";
                    all_connectors.Clear();
                    foreach(var item in shapesList[i])
                    {
                        if (item is Connector connector)
                        {
                            all_connectors.Add(connector);
                        }
                    }
                    jsonSaver.Save(all_connectors, newpath_temp);
                   // Debug.WriteLine(newpath_temp);
                }
            }
/*            if (PathFile.GetExtension(path) == ".json")
            {
                //jsonSaver.Save(shapesList, path);
                
            }*/
        }
        public void LoadProject(string[] path)
        {
            //Shapes = new ObservableCollection<IElement>();
            shapesList.Clear();
            logic_elements.Clear();
            all_connectors.Clear();
            shapes_name.Clear();
            //shapesList.Add(Shapes);
            if (path != null)
            {
                for (int i = 0; i < path.Length; i++)
                {
                    List<int> allid = new List<int>();
                    All_connectors = new ObservableCollection<Connector>(jsonLoader.Load(path[i]));
                    //Debug.WriteLine(path);
                    ObservableCollection<IElement> shapetemp = new ObservableCollection<IElement>();
                    foreach (var item in All_connectors)
                    {
                        shapetemp.Add(item);
                        allid.Add(item.connector_id);
                        if ((item.FirstRectangle.Name == "Input") || item.FirstRectangle.Name == "Output")
                        {
                            shapetemp.Add(item.FirstRectangle);
                        }
                        if ((item.SecondRectangle.Name == "Input") || item.SecondRectangle.Name == "Output")
                        {
                            shapetemp.Add(item.SecondRectangle);
                        }
                    }
                    foreach (var item in All_connectors)
                    {
                        if ((item.SecondRectangle.Name == "And") || (item.SecondRectangle.Name == "Or") || (item.SecondRectangle.Name == "XOR") || (item.SecondRectangle.Name == "Not") || (item.SecondRectangle.Name == "SM"))
                        {
                            shapetemp.Add(item.SecondRectangle);
                            int temp = item.connector_id;
                            foreach (var tempo in item.SecondRectangle.conntecor_ids)
                            {
                                if (tempo != temp)
                                {
                                    foreach (var please in All_connectors)
                                    {
                                        if (please.connector_id == tempo)
                                        {
                                            please.SecondRectangle = item.SecondRectangle; break;
                                        }
                                    }
                                }
                            }
                            foreach (var yuppi in All_connectors)
                            {
                                var temp2 = yuppi.FirstRectangle.StartPoint;
                                foreach (var yoppi in shapetemp)
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
                    shapesList.Add(shapetemp);
                    string[] newParseString = path[i].Split("\\");
                    shapes_name.Add(newParseString[newParseString.Length - 1].Substring(0, newParseString[newParseString.Length - 1].Length - 5));
                    Update();
                }
            }
            Shapes = shapesList[0];
            
            Debug.WriteLine(shapesList.Count);
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