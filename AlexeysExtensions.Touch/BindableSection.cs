using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Attributes;
using Cirrious.MvvmCross.Binding.Touch.Interfaces;
using Cirrious.MvvmCross.Interfaces.Platform.Diagnostics;
using CrossUI.Touch.Dialog.Elements;
using MonoTouch.UIKit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AlexeysExtensions.Touch
{
    public class BindableSection<TElementTemplate> : Section
            where TElementTemplate : Element, IBindableElement
    {
        private IMvxBindingTouchView _bindingTouchView;
        private IEnumerable _itemsSource;

        public BindableSection(IMvxBindingTouchView bindingTouchView) : base() { _bindingTouchView = bindingTouchView; }
        public BindableSection(IMvxBindingTouchView bindingTouchView, string caption) : base(caption) { _bindingTouchView = bindingTouchView; }

        [MvxSetToNullAfterBinding]
        public IEnumerable ItemsSource
        {
            get { return _itemsSource; }
            set { SetItemsSource(value); }
        }

        protected virtual void SetItemsSource(IEnumerable value)
        {
            if (_itemsSource == value)
                return;
            var existingObservable = _itemsSource as INotifyCollectionChanged;
            if (existingObservable != null)
                existingObservable.CollectionChanged -= OnItemsSourceCollectionChanged;
            _itemsSource = value;
            if (_itemsSource != null && !(_itemsSource is IList))
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,
                                      "Binding to IEnumerable rather than IList - this can be inefficient, especially for large lists");
            var newObservable = _itemsSource as INotifyCollectionChanged;
            if (newObservable != null)
                newObservable.CollectionChanged += OnItemsSourceCollectionChanged;
            NotifyDataSetChanged();
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }

        void NotifyDataSetChanged()
        {
            List<Element> newElements = new List<Element>();
            foreach (var item in _itemsSource)
            {
                TElementTemplate element = Activator.CreateInstance<TElementTemplate>();

                element.MvxBindingTouchView = _bindingTouchView;
                element.DataContext = item;

                newElements.Add((Element)element);
            }

            Elements.Clear();
            Elements.AddRange(newElements);

            var root = this.Parent as RootElement;
            if (root == null) root = this.GetImmediateRootElement();

            if (root != null) root.TableView.ReloadData();
        }

        protected override UITableViewCell GetCellImpl(UITableView tv)
        {
            return base.GetCellImpl(tv);
        }

    }
}
