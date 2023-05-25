﻿using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml.Templates;
using ChaChaCha.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        public MainWindowViewModel()
        {
            shapes_name = new ObservableCollection<string>();
            shapes_name.Add("first_citcuit");
            currentCircName = shapes_name[0];
            Shapes = new ObservableCollection<IElement>();
            shapesList= new List<ObservableCollection<IElement>>();
            shapesList.Add(Shapes);
            CircNumber = 0;
            Debug.WriteLine(shapesList.Count);
            buttonpressed = 0;
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