using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace UpgradeHelpers.Helpers
{
	public class ColorConverter : TypeConverter
    {
        private class ColorComparer : IComparer
        {
            public int Compare(object left, object right)
            {
                Color color = (Color)left;
                Color color2 = (Color)right;
                return string.Compare(color.Name, color2.Name, false, CultureInfo.InvariantCulture);
            }
        }

        private static string ColorConstantsLock = "colorConstants";

        private static Hashtable colorConstants;

        private static string SystemColorConstantsLock = "systemColorConstants";

        private static Hashtable systemColorConstants;

        private static string ValuesLock = "values";

        private static TypeConverter.StandardValuesCollection values;

        private static Hashtable Colors
        {
            get
            {
                if (ColorConverter.colorConstants == null)
                {
                    lock (ColorConverter.ColorConstantsLock)
                    {
                        if (ColorConverter.colorConstants == null)
                        {
                            Hashtable hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
                            ColorConverter.FillConstants(hash, typeof(Color));
                            ColorConverter.colorConstants = hash;
                        }
                    }
                }
                return ColorConverter.colorConstants;
            }
        }

        private static Hashtable SystemColors
        {
            get
            {
                if (ColorConverter.systemColorConstants == null)
                {
                    lock (ColorConverter.SystemColorConstantsLock)
                    {
                        if (ColorConverter.systemColorConstants == null)
                        {
                            Hashtable hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
                            ColorConverter.FillConstants(hash, typeof(SystemColors));
                            ColorConverter.systemColorConstants = hash;
                        }
                    }
                }
                return ColorConverter.systemColorConstants;
            }
        }

        /// <summary>Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
        /// <returns>true if this object can perform the conversion; otherwise, false.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. You can use this object to get additional information about the environment from which this converter is being invoked. </param>
        /// <param name="sourceType">The type from which you want to convert. </param>
        /// <filterpriority>1</filterpriority>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        /// <summary>Returns a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
        /// <returns>true if this converter can perform the operation; otherwise, false.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type to which you want to convert. </param>
        /// <filterpriority>1</filterpriority>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        internal static object GetNamedColor(string name)
        {
            object obj = UpgradeHelpers.Helpers.Color.FromName(name);

            return obj;
        }

        /// <summary>Converts the given object to the converter's native type.</summary>
        /// <returns>An <see cref="T:System.Object" /> representing the converted value.</returns>
        /// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor" /> that provides a format context. You can use this object to get additional information about the environment from which this converter is being invoked. </param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> that specifies the culture to represent the color. </param>
        /// <param name="value">The object to convert. </param>
        /// <exception cref="T:System.ArgumentException">The conversion cannot be performed.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text = value as string;
            if (text != null)
            {
                object obj = null;
                string text2 = text.Trim();
                if (text2.Length == 0)
                {
                    obj = Color.Empty;
                }
                else
                {
                    obj = ColorConverter.GetNamedColor(text2);
                    if (obj == null)
                    {
                        if (culture == null)
                        {
                            culture = CultureInfo.CurrentCulture;
                        }
                        char c = culture.TextInfo.ListSeparator.ToCharArray()[0];
                        bool flag = true;
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                        if (text2.IndexOf(c) == -1)
                        {
                            if (text2.Length >= 2 && (text2.ToCharArray()[0] == '\'' || text2.ToCharArray()[0] == '"') && text2.ToCharArray()[0] == text2.ToCharArray()[text2.Length - 1])
                            {
                                string name = text2.Substring(1, text2.Length - 2);
                                obj = Color.FromName(name);
                                flag = false;
                            }
                            else if ((text2.Length == 7 && text2.ToCharArray()[0] == '#') || (text2.Length == 8 && (text2.StartsWith("0x") || text2.StartsWith("0X"))) || (text2.Length == 8 && (text2.StartsWith("&h") || text2.StartsWith("&H"))))
                            {
                                obj = Color.FromArgb(-16777216 | (int)converter.ConvertFromString(context, culture, text2));
                            }
                        }
                        if (obj == null)
                        {
                            string[] array = text2.Split(new char[]
							{
								c
							});
                            int[] array2 = new int[array.Length];
                            for (int i = 0; i < array2.Length; i++)
                            {
                                array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
                            }
                            switch (array2.Length)
                            {
                                case 1:
                                    obj = Color.FromArgb(array2[0]);
                                    break;
                                case 3:
                                    obj = Color.FromArgb(array2[0], array2[1], array2[2]);
                                    break;
                                case 4:
                                    obj = Color.FromArgb(array2[0], array2[1], array2[2], array2[3]);
                                    break;
                            }
                            flag = true;
                        }
                        if (obj != null && flag)
                        {
                            int num = ((Color)obj).ToArgb();
                            IEnumerator enumerator = ColorConverter.Colors.Values.GetEnumerator();
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    Color color = (Color)enumerator.Current;
                                    if (color.ToArgb() == num)
                                    {
                                        obj = color;
                                        break;
                                    }
                                }
                            }
                            finally
                            {
                                IDisposable disposable = enumerator as IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                        }
                    }
                    if (obj == null)
                    {
                        throw new ArgumentException(string.Format("InvalidColor: [{0}]", text2));
                    }
                }
                return obj;
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>Converts the specified object to another type. </summary>
        /// <returns>An <see cref="T:System.Object" /> representing the converted value.</returns>
        /// <param name="context">A formatter context. Use this object to extract additional information about the environment from which this converter is being invoked. Always check whether this value is null. Also, properties on the context object may return null. </param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> that specifies the culture to represent the color. </param>
        /// <param name="value">The object to convert. </param>
        /// <param name="destinationType">The type to convert the object to. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="destinationtype" /> is null.</exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is Color)
            {
                if (destinationType == typeof(string))
                {
                    Color left = (Color)value;
                    if (left == Color.Empty)
                    {
                        return string.Empty;
                    }
                    if (left.IsKnownColor)
                    {
                        return left.Name;
                    }
                    if (left.IsNamedColor)
                    {
                        return "'" + left.Name + "'";
                    }
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string text = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    int num = 0;
                    string[] array;
                    if (left.A < 255)
                    {
                        array = new string[4];
                        array[num++] = converter.ConvertToString(context, culture, left.A);
                    }
                    else
                    {
                        array = new string[3];
                    }
                    array[num++] = converter.ConvertToString(context, culture, left.R);
                    array[num++] = converter.ConvertToString(context, culture, left.G);
                    array[num++] = converter.ConvertToString(context, culture, left.B);
                    return string.Join(text, array);
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    object[] array2 = null;
                    Color color = (Color)value;
                    MemberInfo memberInfo;
                    if (color.IsEmpty)
                    {
                        memberInfo = typeof(Color).GetField("Empty");
                    }
                    else if (color.IsSystemColor)
                    {
                        memberInfo = typeof(SystemColors).GetProperty(color.Name);
                    }
                    else if (color.IsKnownColor)
                    {
                        memberInfo = typeof(Color).GetProperty(color.Name);
                    }
                    else if (color.A != 255)
                    {
                        memberInfo = typeof(Color).GetMethod("FromArgb", new Type[]
						{
							typeof(int),
							typeof(int),
							typeof(int),
							typeof(int)
						});
                        array2 = new object[]
						{
							color.A,
							color.R,
							color.G,
							color.B
						};
                    }
                    else if (color.IsNamedColor)
                    {
                        memberInfo = typeof(Color).GetMethod("FromName", new Type[]
						{
							typeof(string)
						});
                        array2 = new object[]
						{
							color.Name
						};
                    }
                    else
                    {
                        memberInfo = typeof(Color).GetMethod("FromArgb", new Type[]
						{
							typeof(int),
							typeof(int),
							typeof(int)
						});
                        array2 = new object[]
						{
							color.R,
							color.G,
							color.B
						};
                    }
                    if (memberInfo != null)
                    {
                        return new InstanceDescriptor(memberInfo, array2);
                    }
                    return null;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static void FillConstants(Hashtable hash, Type enumType)
        {
            MethodAttributes methodAttributes = (MethodAttributes) 22;
            PropertyInfo[] properties = enumType.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                if (propertyInfo.PropertyType == typeof(Color))
                {
                    MethodInfo getMethod = propertyInfo.GetGetMethod();
                    if (getMethod != null && (getMethod.Attributes & methodAttributes) == methodAttributes)
                    {
                        object[] array = null;
                        hash[(object)propertyInfo.Name] =propertyInfo.GetValue(null, array);
                    }
                }
            }
        }

        /// <summary>Retrieves a collection containing a set of standard values for the data type for which this validator is designed. This will return null if the data type does not support a standard set of values.</summary>
        /// <returns>A collection containing null or a standard set of valid values. The default implementation always returns null.</returns>
        /// <param name="context">A formatter context. Use this object to extract additional information about the environment from which this converter is being invoked. Always check whether this value is null. Also, properties on the context object may return null. </param>
        /// <filterpriority>1</filterpriority>
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (ColorConverter.values == null)
            {
                lock (ColorConverter.ValuesLock)
                {
                    if (ColorConverter.values == null)
                    {
                        ArrayList arrayList = new ArrayList();
                        arrayList.AddRange(ColorConverter.Colors.Values);
                        arrayList.AddRange(ColorConverter.SystemColors.Values);
                        int num = arrayList.Count;
                        for (int i = 0; i < num - 1; i++)
                        {
                            for (int j = i + 1; j < num; j++)
                            {
                                if (arrayList[i].Equals(arrayList[j]))
                                {
                                    arrayList.RemoveAt(j);
                                    num--;
                                    j--;
                                }
                            }
                        }
                        arrayList.Sort(0, arrayList.Count, new ColorConverter.ColorComparer());
                        ColorConverter.values = new TypeConverter.StandardValuesCollection(arrayList.ToArray());
                    }
                }
            }
            return ColorConverter.values;
        }

        /// <summary>Determines if this object supports a standard set of values that can be chosen from a list.</summary>
        /// <returns>true if <see cref="Overload:System.Drawing.ColorConverter.GetStandardValues" /> must be called to find a common set of values the object supports; otherwise, false.</returns>
        /// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor" /> through which additional context can be provided. </param>
        /// <filterpriority>1</filterpriority>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

    }
}
