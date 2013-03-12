<h1>MvvmCross.AlexeysExtensions</h1>

<h3>BindableSection&lt;TElementTemplate&gt;</h3>
MonoTouch.Dialog section element that supports data binding. 
A collection of elements should be bound to <strong>ItemsSource</strong> property. 
An element of type <strong>TElementTemplate</strong> will be created at run-time for each of the items in the collection. 
These elements are expected to implement an interface <strong>IBindableElement</strong> and take care of the data binding inside of the element. 

```c#
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
```

Using BindableSection inside of MonoTouch.Dialog:

```c#
        BindableSection<SampleStringElement> StringElementsSection { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            StringElementsSection = new BindableSection<SampleStringElement>(this, "String Elements");

            Root = new RootElement("Sample")
            {
                StringElementsSection
            };

            StringElementsSection.Bind(this, "{'ItemsSource':{'Path':'MyObjects'}}");
        }
```

See <i>Sample</i> project for more detailed example.
