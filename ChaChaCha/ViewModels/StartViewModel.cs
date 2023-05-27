using Avalonia.Controls;
using ChaChaCha.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaChaCha.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        Window? secondary;
        public StartViewModel() { }
        public void AddWindow(Window second)
        {
            secondary = second;
            secondary.Show();
        }
    }
}
