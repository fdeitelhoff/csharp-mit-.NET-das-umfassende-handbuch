using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RoutedEvent_Sample3
{
    public class SpecializedButton : Button
    {
        public static readonly RoutedEvent SayHelloEvent;

        static SpecializedButton()
        {
            SayHelloEvent = EventManager.RegisterRoutedEvent("SayHello", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SpecializedButton));
        }

        // Ereignis-Wrapper
        public event RoutedEventHandler SayHello
        {
            add { AddHandler(SayHelloEvent, value); }
            remove { RemoveHandler(SayHelloEvent, value); }
        }

        protected override void OnClick()
        {
            RoutedEventArgs e = new RoutedEventArgs();
            e.RoutedEvent = SpecializedButton.SayHelloEvent;
            e.Source = this;
            RaiseEvent(e);
        }
    }
}
