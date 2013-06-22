using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RetailPOS.Utility
{
    public static class ExtensionMethods
    {
        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            //return the value
            return string.Format(format, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            //return the value
            return string.Format(provider, format, args);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            var newCollection = new ObservableCollection<T>();

            //loops through the collection object and adds item in observable collection
            foreach (var item in collection)
            {
                newCollection.Add(item);
            }            
            //return the value
            return newCollection;
        }

        public static void Update<T>(this IEnumerable<T> source, params Action<T>[] updates)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (updates == null)
                throw new ArgumentNullException("updates");

            foreach (T item in source)
            {
                foreach (Action<T> update in updates)
                {
                    update(item);
                }
            }
        }
    }
}