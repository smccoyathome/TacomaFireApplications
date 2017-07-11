using System.Collections.Generic;
using UpgradeHelpers.Interfaces;
using System;
using System.Collections;
using System.Text.RegularExpressions;


namespace UpgradeHelpers.Helpers
{

	public static partial class Extensions
	{

        public static void Build(IList<IDependentViewModel> collection, IIocContainer ctx)
        {
            foreach (var subView in collection)
            {
                subView.Build(ctx);
            }
        }



       

#if PORTABLE
        /// <summary>Indicates whether a specified string is null, empty, or consists only of white-space characters.</summary>
        /// <returns>true if the <paramref name="value" /> parameter is null or <see cref="F:System.String.Empty" />, or if <paramref name="value" /> consists exclusively of white-space characters. </returns>
        /// <param name="value">The string to test.</param>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null)
            {
                return true;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
#endif

		/// <summary>
		/// Initializes the individual items of an List<T> 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static List<T> Init<T>(this List<T> list)
		{
			for (int i = 0; i < list.Capacity; i++) list.Add(default(T));
			return list;
		}

        /// <summary>
        /// File existance verification can depend on the platform. This delegate is used to allow
        /// platform independence
        /// </summary>
        public static Func<string, bool> FileExists { private get; set; }

	

        /// <summary>
        /// Use this property top setup a delegate to map to an platform specific method of mapping url
        /// For example using System.Web.HttpContext.Current.Server.MapPath
        /// </summary>
        public static Func<string, string> MapPath { private get; set; }

		/// <summary>
		/// Returns an url path as physical path
		/// </summary>
		/// <param name="urlPath"></param>
		/// <returns></returns>
		public static string AsPhysicalPath(this string urlPath) 
		{
            System.Diagnostics.Debug.Assert(MapPath != null, "MapPath delegate must be set before use");
            urlPath = urlPath.Replace(@"\\", @"\").Replace(@"\", "/").Replace("//", "/");
			urlPath = System.Text.RegularExpressions.Regex.Replace(urlPath, @"(\w+)(:/)(\w+.*)", "$1$2/$3");
			try
			{
				urlPath = MapPath(urlPath);
			}
			catch { }
			return urlPath;
		}

		/// <summary>
		/// Build a new property name depending of the owner property
		/// </summary>
		/// <param name="source"></param>
		/// <param name="sender"></param>
		/// <param name="basePropertyName"></param>
		/// <returns></returns>
		public static string AssemblePropertyName(this object source, object sender, string basePropertyName)
		{
			IList propValueIList = null;
			try
			{
				if (source != null)
				{
					IControl iControl = sender as IControl;
					if (iControl != null && !string.IsNullOrEmpty(iControl.Name))
					{
						Match match;
						if ((match = Regex.Match(iControl.Name, @"_(\w+)_(\d+)", RegexOptions.IgnoreCase)) != Match.Empty)
							return match.Groups[1].Value + "[" + match.Groups[2].Value + "]." + basePropertyName;
						else
							return iControl.Name + "." + basePropertyName;
					}
					else
					{
						foreach (var pInfo in source.GetType().GetProperties())
						{
							var propValue = pInfo.GetValue(source, null);
							if (propValue != null)
							{
								if (object.Equals(propValue, sender))
								{
									return pInfo.Name + "." + basePropertyName;
								}
								else if ((propValueIList = propValue as IList) != null)
								{
									int i = 0;
									foreach (var item in propValueIList)
									{
										if (object.Equals(item, sender))
										{
											return pInfo.Name + "[" + i + "]." + basePropertyName;
										}
										i++;
									}
								}
							}
						}
					}
				}
			}
			catch { }

			return basePropertyName;
		}
	}


	public static class Utils
	{

        /// <summary>
        /// Helper method that can be used for fields declared
        /// with an interface or type that do not expose the IStateObject interface
        /// directly
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string UniqueID(this object obj)
        {
            var stateObject = obj as IStateObject;
            return stateObject == null ? null : stateObject.UniqueID;
        }

		public static string ApplicationPath()
		{
		    var appPath = System.Configuration.ConfigurationManager.AppSettings["ApplicationPath"];
		    return appPath ?? ".";
		}

		public static float TwipsPerPixelY()
		{
			return 15;
		}

		public static float TwipsPerPixelX()
		{
			return 15;
		}

		public static double TwipsToPixelsX(double twips)
		{
			return System.Convert.ToInt32(twips / TwipsPerPixelX());
		}

		public static int TwipsToPixelsY(double twips)
		{
			return System.Convert.ToInt32(twips / TwipsPerPixelY());
		}

		public static float PixelsToTwipsX(double p)
		{
			return (float)p * TwipsPerPixelX();
		}

		public static float PixelsToTwipsY(double p)
		{
			return (float)p * TwipsPerPixelY();
		}

		public static Array CopyArray<T>(T[] p)
		{
			var newArray = new T[p.Length];
			Array.Copy(p, newArray, p.Length);
			return newArray;
		}

	}
}