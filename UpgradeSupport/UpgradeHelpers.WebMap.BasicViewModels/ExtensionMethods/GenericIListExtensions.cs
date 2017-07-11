using System;
using System.Collections.Generic;
using System.Linq;

using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{

	public static partial class Extensions
	{


		/// <summary>
		/// Add several items to an IList object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection"></param>
		/// <param name="items"></param>
		public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				collection.Add(item);
			}
		}
	}
}

namespace UpgradeHelpers.BasicViewModels.Extensions
{
    /// <summary>
    /// AddRange method support for generic IList.
    /// </summary>
    public static class GenericIListExtensions
    {
       
        public static int AddExt<T>(this IList<T> list, T item)
        {
            list.Add(item);
            return list.Count - 1;
        }
        public static T FindByString<T>(this IList<T> list, string index)
        {
            throw new System.NotImplementedException();
        }
        public static void Sort<T>(this IList<T> list,Comparison<T> comparison = null)
        {
            var list1 = list.ToList<T>();
            if (comparison != null)
                list1.Sort(comparison);
            else
                list1.Sort();
            list.Clear();
            foreach (var item in list1)
            {
                list.Add(item);
            }
        }

        public static void SortIComparer<T>(this IList<T> list, IComparer<T> comparison = null)
        {
            var list1 = list.ToList<T>();
            if (comparison != null)
                list1.Sort(comparison);
            else
                list1.Sort();
            list.Clear();
            foreach (var item in list1)
            {
                list.Add(item);
            }
        }

        public static int FindIndex<T>(this IList<T> list, Predicate<T> match)
        {
            return list.FindIndex(0, list.Count, match);
        }

        public static int FindIndex<T>(this IList<T> list, int startIndex, Predicate<T> match)
        {
            return list.FindIndex(startIndex, list.Count, match);
        }

        public static int FindIndex<T>(this IList<T> list, int startIndex, int count, Predicate<T> match)
        {

            if (startIndex > list.Count)
                throw new ArgumentOutOfRangeException(string.Format("startIndex {0} is greater than list count {1}", startIndex, list.Count));
            for (int i = startIndex; i < Math.Min(count, list.Count); i++)
            {
                var item = list[i];
                if (match(item))
                    return i;
            }
            return -1;
        }

        public static T Find<T>(this IList<T> list, Predicate<T> match)
        {
			T result = list.ToList<T>().Find(match);
			return result;
        }


        public static List<T> FindAll<T>(this IList<T> list, Predicate<T> match)
        {
			var list1 = list as IListMissingMethods<T>;
			if(list1 != null)
				return list1.FindAll(match);
			return list.ToList<T>().FindAll(match);
        }


		public static bool Exists<T>(this IList<T> list, Predicate<T> match)
		{
			//[Mobilize jperez 11/17/2015] TODO
			bool exists = false;
			foreach (var element in list)
			{
				if (match.Invoke(element))
				{
					exists = true;
					break;
				}
			}
			//throw new NotImplementedException();
			return exists;

		}
        public static void RemoveRange<T>(this IList<T> list, int index, int count)
        {
            throw new NotImplementedException();
        }

        public static int RemoveAll<T>(this IList<T> list, Predicate<T> match)
        {
            //,MOBILIZE,10/27/2016,TODO,mvega,MANUALLY FIXED, previous implementation was buggy, now there are no issues when removing multiple elements.
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (match.Invoke(list[i]))
                {
                    list.RemoveAt(i);
                    i--;
                    count++;
                }
            }

            return count;
        }
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            throw new NotImplementedException();
        }
        public static void Insert<T>(this ICollection<T> list, int index, T item)
        {
            throw new NotImplementedException();
        }
		public static IList<T> ToIList<T>(this IEnumerable<T> collection)
		{
			IList<T> result = StaticContainer.Instance.Resolve<IList<T>>();

			foreach (var item in collection)
			{
				result.Add(item);
			}

			return result;
		}

        public static T Peek<T>(this IList<T> collection)
        {
            if (collection.Count == 0)
                throw new System.InvalidOperationException("Stack empty");

            return collection[0];
        }

        public static T Pop<T>(this IList<T> collection)
        {
            if (collection.Count == 0)
                throw new System.InvalidOperationException("Stack empty");

            T result = collection[0];
            collection.RemoveAt(0);
            return result;
        }

        public static void Push<T>(this IList<T> collection, T element)
        {
            collection.Add(element);
        }

        public static void Move<T>(this IList<T> collection, int oldIndex, int newIndex)
        {
            throw new NotImplementedException();
        }

    }
}
