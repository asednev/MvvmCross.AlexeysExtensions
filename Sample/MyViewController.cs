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
        BindableSection<SampleElement> SampleSection { get; set; }

        public MyViewController(MvxShowViewModelRequest request) : base(request)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SampleSection = new BindableSection<SampleElement>(this, "Section");

            Root = new RootElement("Sample")
            {
                SampleSection
            };

            SampleSection.Bind(this, "{'ItemsSource':{'Path':'MyObjects'}}");

        }

        /*
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            button = UIButton.FromType(UIButtonType.RoundedRect);

            button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                View.Frame.Height / 2 - buttonHeight / 2,
                buttonWidth,
                buttonHeight);

            button.SetTitle("Click me", UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) =>
            {
                button.SetTitle(String.Format("clicked {0} times", numClicks++), UIControlState.Normal);
            };

            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(button);
        }*/

    }
}

