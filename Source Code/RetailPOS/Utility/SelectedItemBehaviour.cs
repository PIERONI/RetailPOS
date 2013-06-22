using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;


namespace RetailPOS.Utility
{
    public static class SelectedItemsBehavior
    {
        public static readonly DependencyProperty SelectedItemsChangedHandlerProperty =
            DependencyProperty.RegisterAttached("SelectedItemsChangedHandler",
                typeof(RelayCommand),
                typeof(SelectedItemsBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedItemsChangedHandlerChanged)));


        public static RelayCommand GetSelectedItemsChangedHandler(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return element.GetValue(SelectedItemsChangedHandlerProperty) as RelayCommand;
        }

        public static void SetSelectedItemsChangedHandler(DependencyObject element, RelayCommand value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(SelectedItemsChangedHandlerProperty, value);
        }

        public static void OnSelectedItemsChangedHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            DataGrid dataGrid = (DataGrid)d;

            if (e.OldValue == null && e.NewValue != null)
            {
                dataGrid.SelectionChanged += new SelectionChangedEventHandler(ItemsControl_SelectionChanged);
            }

            if (e.OldValue != null && e.NewValue == null)
            {
                dataGrid.SelectionChanged -= new SelectionChangedEventHandler(ItemsControl_SelectionChanged);
            }
        }


        public static void ItemsControl_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {

            DataGrid dataGrid = (DataGrid)sender;

            RelayCommand itemsChangedHandler = GetSelectedItemsChangedHandler(dataGrid);

            itemsChangedHandler.Execute(dataGrid.SelectedItems);
        }
    }
}
