using AlexeysExtensions.Touch;
using CrossUI.Touch.Dialog.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Dialog.Touch;

namespace Sample
{
    public class SampleStringElement : StringElement, IBindableElement
    {
        public SampleStringElement()
            : base(string.Empty)
        {
            
        }

        protected override MonoTouch.UIKit.UITableViewCell GetCellImpl(MonoTouch.UIKit.UITableView tv)
        {
            //Implement binding of Title property in the business object to Caption propery of String Element
            this.Bind(MvxBindingTouchView, DataContext, "{'Caption':{'Path':'Title'}}");

            return base.GetCellImpl(tv);
        }

        #region IBindableElement
        public Cirrious.MvvmCross.Binding.Touch.Interfaces.IMvxBindingTouchView MvxBindingTouchView { get; set; }

        public object DataContext { get; set; }
        #endregion
    }
}
