using Avalonia.Controls.Shapes;
using ChaChaCha.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ChaChaCha.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<IElement> shapes;
        //////////////////// ДЛЯ ДОБАВЛЕНИЯ ФИГУР НА ПОЛОТНО ////////////////////////////////
        private int buttonpressed;
        public int ButtonPressed
        {
            get => buttonpressed;
            set => this.RaiseAndSetIfChanged(ref buttonpressed, value);
        }
        private int andButton;
        public int AndButton
        {
            get => andButton;
            set => this.RaiseAndSetIfChanged(ref andButton, value);
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
        public MainWindowViewModel()
        {
            Shapes = new ObservableCollection<IElement>();
            buttonpressed = 0;
        }
        public ObservableCollection<IElement> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }
        
        public void ElementToDraw(int number)
        {
            buttonpressed = number;
        }
        
    }
}