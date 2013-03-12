using System;
using MonoTouch.UIKit;
using System.Drawing;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Dialog.Touch;
using CrossUI.Touch.Dialog.Elements;
using AlexeysExtensions.Touch;

namespace Sample
{
    public class MyViewController : MvxTouchDialogViewController<SampleViewModel>
    {
        BindableSection<SampleStringElement> StringElementsSection { get; set; }
        BindableSection<SampleCustomElement> CustomElementsSection { get; set; }

        public MyViewController(MvxShowViewModelRequest request) : base(request)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            StringElementsSection = new BindableSection<SampleStringElement>(this, "String Elements");
            CustomElementsSection = new BindableSection<SampleCustomElement>(this, "Custom Elements");

            Root = new RootElement("Sample")
            {
                StringElementsSection, 
                CustomElementsSection
            };

            StringElementsSection.Bind(this, "{'ItemsSource':{'Path':'MyObjects'}}");
            CustomElementsSection.Bind(this, "{'ItemsSource':{'Path':'MyObjects'}}");

        }

    }
}

