using System;
using System.Collections.Generic;
using System.Reflection;

namespace UpgradeHelpers.WebMap.Server
{
	public class ReflectionBinderForPromisesResolution : Binder
	{

		public ReflectionBinderForPromisesResolution() : base() { }
		//private class BinderState
		//{
		//	public object[] args;
		//}

		public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers)
		{
			if (match == null)
				throw new ArgumentNullException("match");
			if (match.Length == 1)
			{
				var method = match[0] as MethodInfo;
				if (method.IsGenericMethod)
				{
					List<Type> typearguments = new List<Type>();
					int index = 0;
					var methodParameter = method.GetParameters();
					if (methodParameter.Length != types.Length)
						throw new InvalidOperationException("No possible match");
					foreach (var p in method.GetParameters())
					{

						if (p.ParameterType.IsGenericParameter)
							typearguments.Add(types[index]);
						index++;
					}
					method = method.MakeGenericMethod(typearguments.ToArray());
				}
				return method;
			}
			for (int i = 0; i < match.Length; i++)
			{
				// Count the number of parameters that match.
				int count = 0;
				ParameterInfo[] parameters = match[i].GetParameters();
				// Go on to the next method if the number of parameters do not match.
				if (types.Length != parameters.Length)
					continue;
				// Match each of the parameters that the user expects the method to have.
				for (int j = 0; j < types.Length; j++)
					// Determine whether the types specified by the user can be converted to parameter type.
					if (CanConvertFrom(types[j], parameters[j].ParameterType))
						count += 1;
					else
						break;
				// Determine whether the method has been found.
				if (count == types.Length)
					return match[i];
			}
			return null;
		}


		// Determines whether type1 can be converted to type2. Check only for primitive types.
		private bool CanConvertFrom(Type type1, Type type2)
		{
			if (type1.IsPrimitive && type2.IsPrimitive)
			{
				TypeCode typeCode1 = Type.GetTypeCode(type1);
				TypeCode typeCode2 = Type.GetTypeCode(type2);
				// If both type1 and type2 have the same type, return true.
				if (typeCode1 == typeCode2)
					return true;
				// Possible conversions from Char follow.
				if (typeCode1 == TypeCode.Char)
					switch (typeCode2)
					{
						case TypeCode.UInt16: return true;
						case TypeCode.UInt32: return true;
						case TypeCode.Int32: return true;
						case TypeCode.UInt64: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from Byte follow.
				if (typeCode1 == TypeCode.Byte)
					switch (typeCode2)
					{
						case TypeCode.Char: return true;
						case TypeCode.UInt16: return true;
						case TypeCode.Int16: return true;
						case TypeCode.UInt32: return true;
						case TypeCode.Int32: return true;
						case TypeCode.UInt64: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from SByte follow.
				if (typeCode1 == TypeCode.SByte)
					switch (typeCode2)
					{
						case TypeCode.Int16: return true;
						case TypeCode.Int32: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from UInt16 follow.
				if (typeCode1 == TypeCode.UInt16)
					switch (typeCode2)
					{
						case TypeCode.UInt32: return true;
						case TypeCode.Int32: return true;
						case TypeCode.UInt64: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from Int16 follow.
				if (typeCode1 == TypeCode.Int16)
					switch (typeCode2)
					{
						case TypeCode.Int32: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from UInt32 follow.
				if (typeCode1 == TypeCode.UInt32)
					switch (typeCode2)
					{
						case TypeCode.UInt64: return true;
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from Int32 follow.
				if (typeCode1 == TypeCode.Int32)
					switch (typeCode2)
					{
						case TypeCode.Int64: return true;
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from UInt64 follow.
				if (typeCode1 == TypeCode.UInt64)
					switch (typeCode2)
					{
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from Int64 follow.
				if (typeCode1 == TypeCode.Int64)
					switch (typeCode2)
					{
						case TypeCode.Single: return true;
						case TypeCode.Double: return true;
						default: return false;
					}
				// Possible conversions from Single follow.
				if (typeCode1 == TypeCode.Single)
					switch (typeCode2)
					{
						case TypeCode.Double: return true;
						default: return false;
					}
			}
			return false;
		}

		public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] names, out object state)
		{
			throw new NotImplementedException();
		}

		public override object ChangeType(object value, Type type, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override void ReorderArgumentArray(ref object[] args, object state)
		{
			throw new NotImplementedException();
		}

		public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers)
		{
			throw new NotImplementedException();
		}
	}
}