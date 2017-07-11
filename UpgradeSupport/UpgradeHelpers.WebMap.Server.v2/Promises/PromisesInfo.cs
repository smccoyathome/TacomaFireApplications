using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Fasterflect;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;
using UpgradeHelpers.WebMap.Server.Promises;
using UpgradeHelpers.Helpers;
using System.Collections.Generic;

namespace UpgradeHelpers.WebMap.Server
{

	public class PromisesInfoConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(PromisesInfo).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			PromisesInfo target = null;
			if (reader.TokenType == JsonToken.Null)
				return null;
			target = existingValue as PromisesInfo;
			target.EventsName = reader.Value.ToString();
			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var obj = value as PromisesInfo;
			writer.WriteValue(obj.EventsName);
		}
	}
	[JsonConverter(typeof(PromisesInfoConverter))]

	/// <summary>
	/// Defines a array promise object that array handles code
	/// </summary>
	internal class PromisesInfo : IStateObject, NoInterception
	{
		public static PromisesInfo CreateInstance(string handlersUniqueId)
        {
            PromisesInfo instance = null;
            instance = StateManager.Current.GetObject(handlersUniqueId) as PromisesInfo;
            if (instance == null)
            {
                instance = new PromisesInfo
                {
                    UniqueID = handlersUniqueId,
                    EventsName = ""
                };
				StateManager.Current.AddNewObject(instance);
            }
			return instance;
		}

		public void Add(string methodnameid)
		{
			if (!this.EventsName.Contains(methodnameid))
			{
				this.EventsName += methodnameid + "|";
			}
		}

		public void Remove(string methodnameid)
		{
			string handlerremove = methodnameid + "|";
			int pos = this.EventsName.IndexOf(handlerremove);
			if (pos > -1)
			{
				this.EventsName = this.EventsName.Remove(pos, handlerremove.Length);
			}
		}

		public string[] GetListMethodsMame()
		{
			string[] vreturn = new string[] { };
			if (this.EventsName != "")
			{
				string allnames = this.EventsName.Remove(this.EventsName.Length - 1, 1); //remove the last separator
				vreturn = allnames.Split('|');
			}
			return vreturn;
		}

		public bool IsEmpty()
		{
			return this.EventsName.Length == 0;
		}
		public string EventsName { get; set; }

		public string UniqueID { get; set; }
	}
}