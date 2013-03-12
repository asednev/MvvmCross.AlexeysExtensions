using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sample
{
    public class SampleViewModel : MvxViewModel
    {
        public SampleViewModel()
        {
            MyObjects = new ObservableCollection<SamplesBusinessObject>()
            {
                new SamplesBusinessObject() { Title = "My 1st element title", Subtitle = "My first subtitle" },
                new SamplesBusinessObject() { Title = "My 2nd element title", Subtitle = "My second subtitle" },
                new SamplesBusinessObject() { Title = "My 3rd element title", Subtitle = "My third subtitle" }
            };
        }

        public ObservableCollection<SamplesBusinessObject> MyObjects { get; set; }
    }
}
