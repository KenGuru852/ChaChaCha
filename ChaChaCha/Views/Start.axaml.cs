using Avalonia.Controls;
using ChaChaCha.ViewModels;

namespace ChaChaCha.Views
{
    public partial class Start : Window
    {
        readonly StartViewModel secondWindow;
        public Start()
        {
            InitializeComponent();
            secondWindow = new StartViewModel();
            DataContext = secondWindow;
            secondWindow.AddWindow(this);
        }
    }
}
