using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.Operations;
using System;

namespace ChaChaCha.Views
{
    public class XorLogic : TemplatedControl
    {
        public static readonly RoutedEvent<PointerEventArgs> PointerEnterEvent =
            RoutedEvent.Register<XorLogic, PointerEventArgs>(
                nameof(PointerEnter), RoutingStrategies.Bubble | RoutingStrategies.Tunnel);

        public event EventHandler<PointerEventArgs> PointerEnter
        {
            add => AddHandler(PointerEnterEvent, value);
            remove => RemoveHandler(PointerEnterEvent, value);
        }
    }
}
