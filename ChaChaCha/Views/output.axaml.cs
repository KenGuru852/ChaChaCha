using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.Operations;
using System;

namespace ChaChaCha.Views
{
    public class OutputLogic : TemplatedControl
    {
        public static readonly RoutedEvent<PointerEventArgs> PointerEnterEvent =
            RoutedEvent.Register<OutputLogic, PointerEventArgs>(
                nameof(PointerEnter), RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

        public event EventHandler<PointerEventArgs> PointerEnter
        {
            add => AddHandler(PointerEnterEvent, value);
            remove => RemoveHandler(PointerEnterEvent, value);
        }
    }
}
