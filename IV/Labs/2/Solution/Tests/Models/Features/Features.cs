﻿using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Tests.Models.Features
{

    /// <summary>
    /// Simple struct - Pair <br/>
    /// Contains two property: First and Second <br/>
    /// They both can be any data type
    /// </summary>
    /// <typeparam name="T"> First element data type </typeparam>
    /// <typeparam name="U"> Second element data type </typeparam>
    public struct MyPair<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }

        public MyPair(T first, U second)
        {
            First = first;
            Second = second;
        }

    }

    /// <summary>
    /// This class contains a few useful extenders for the ListBox
    /// </summary>
    public class ListBoxExtenders : DependencyObject
    {
        public static readonly DependencyProperty AutoScrollToEndProperty = 
            DependencyProperty.RegisterAttached("AutoScrollToEnd", typeof(bool),
                typeof(ListBoxExtenders),
                new UIPropertyMetadata(default(bool),
                OnAutoScrollToEndChanged));

        /// <summary>
        /// Returns the value of the AutoScrollToEndProperty
        /// </summary>
        /// <param name="obj">The dependency-object whichs value should be returned</param>
        /// <returns>The value of the given property</returns>
        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }

        /// <summary>
        /// Sets the value of the AutoScrollToEndProperty
        /// </summary>
        /// <param name="obj">The dependency-object whichs value should be set</param>
        /// <param name="value">The value which should be assigned to the AutoScrollToEndProperty</param>
        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }

        /// <summary>
        /// This method will be called when the AutoScrollToEnd
        /// property was changed
        /// </summary>
        /// <param name="s">The sender (the ListBox)</param>
        /// <param name="e">Some additional information</param>
        public static void OnAutoScrollToEndChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var listBox = s as ListBox;
            var listBoxItems = listBox.Items;
            var data = listBoxItems.SourceCollection as INotifyCollectionChanged;

            var scrollToEndHandler = new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
                (s1, e1) =>
                {
                    if (listBox.Items.Count > 0)
                    {
                        object lastItem = listBox.Items[listBox.Items.Count - 1];
                        listBoxItems.MoveCurrentTo(lastItem);
                        listBox.ScrollIntoView(lastItem);
                    }
                });

            if ((bool)e.NewValue)
                data.CollectionChanged += scrollToEndHandler;
            else
                data.CollectionChanged -= scrollToEndHandler;
        }
    }

}
