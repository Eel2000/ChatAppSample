using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatAppSample.Behaviors
{
    public class InfiniteScroll : Behavior<ListView>
    {
        public static readonly BindableProperty LoadMoreCommandProperty =
            BindableProperty.Create("LoadMoreCommand", typeof(ICommand), typeof(InfiniteScroll));

        public ICommand LoadMoreCommand
        {
            get => (ICommand)GetValue(LoadMoreCommandProperty);
            set => SetValue(LoadMoreCommandProperty, value);
        }

        public ListView AssociateObject
        {
            get;
            private set;
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            AssociateObject = bindable;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            bindable.ItemAppearing += InfiniteListView_ItemAppearing;
        }

        private void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = AssociateObject.ItemsSource as IList<object>;
            if (items != null && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    LoadMoreCommand.Execute(null);
            }
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociateObject.BindingContext;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
            bindable.ItemAppearing -= InfiniteListView_ItemAppearing;
        }
    }
}
