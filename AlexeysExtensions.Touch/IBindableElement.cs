using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexeysExtensions.Touch
{
    public interface IBindableElement
    {
        Cirrious.MvvmCross.Binding.Touch.Interfaces.IMvxBindingTouchView MvxBindingTouchView { get; set; }
        object DataContext { get; set; }
    }
}
