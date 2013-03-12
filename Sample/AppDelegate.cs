
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ExtensionMethods;

namespace Sample
{
    [Register("AppDelegate")]
    public partial class AppDelegate :
        MvxApplicationDelegate, IMvxServiceConsumer
    {
        UIWindow window;
        MyViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            // initialize app for single screen iPhone display with no modal support
            var presenter = new MvxTouchViewPresenter(this, window);
            var setup = new Setup(this, presenter);
            setup.Initialize();

            // start the app
            var start = this.GetService<IMvxStartNavigation>();
            start.Start();

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

