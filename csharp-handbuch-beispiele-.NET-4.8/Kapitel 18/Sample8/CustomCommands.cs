using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample8
{
    public static class CustomCommands
    {
        private static RoutedUICommand _DoSomething = new RoutedUICommand("Mach was ...", "DoSomething", typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                           new KeyGesture(Key.Q, ModifierKeys.Alt)
                        }
                   );

        public static RoutedUICommand DoSomething
        {
            get { return _DoSomething; }
        }
    }
}
