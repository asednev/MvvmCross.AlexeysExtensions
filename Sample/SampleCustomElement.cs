using AlexeysExtensions.Touch;
using Cirrious.MvvmCross.Dialog.Touch;
using CrossUI.Touch.Dialog.Elements;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using System.Drawing;

namespace Sample
{
    public class SampleCustomElement : UIViewElement, IBindableElement
    {
        public SampleCustomElement()
            : base("", new SampleView(), false)
        {
        }

        protected override UITableViewCell GetCellImpl(UITableView tv)
        {
            MyView.Bind(MvxBindingTouchView, DataContext, "{'Title':{'Path':'Title'}}");
            MyView.Bind(MvxBindingTouchView, DataContext, "{'Subtitle':{'Path':'Subtitle'}}");

            return base.GetCellImpl(tv);
        }

        public SampleView MyView
        {
            get
            {
                return this.View as SampleView;
            }
        }

        #region IBindableElement
        public Cirrious.MvvmCross.Binding.Touch.Interfaces.IMvxBindingTouchView MvxBindingTouchView { get; set; }

        public object DataContext { get; set; }
        #endregion

        public class SampleView : UIView
        {
            public SampleView() 
                : base(new RectangleF(0f, 0f, 450f, 44f))
            {
                this.BackgroundColor = UIColor.Clear;
            }

            public string Title { get; set; }
            public string Subtitle { get; set; }

            public override void Draw(System.Drawing.RectangleF rect)
            {
                using (CGContext context = UIGraphics.GetCurrentContext())
                {
                    UIColor.Black.SetColor();

                    var boldFont = UIFont.BoldSystemFontOfSize(14.0f);
                    var regularFont = UIFont.SystemFontOfSize(14.0f);

                    this.DrawString(Title, new RectangleF(54f, 4f, 450f, 44f), boldFont);
                    this.DrawString(Subtitle, new RectangleF(54f, 22f, 450f, 44f), regularFont);

                }
            }

        }
    }
}
