using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ChaChaCha.Models;
using ChaChaCha.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace ChaChaCha.Views
{
    public partial class StartUser : UserControl
    {
        public StartUser()
        {
            InitializeComponent();
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Debug.WriteLine("asd");
            }
        }
    }
}
