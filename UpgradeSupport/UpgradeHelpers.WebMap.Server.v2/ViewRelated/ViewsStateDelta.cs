#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.WebMap.Server.Common;

#endregion

namespace UpgradeHelpers.WebMap.Server
{
	public class ViewsStateDelta
	{
		private List<ClientCommand> _newCommands;
		private List<string> _newViews;
		private List<string> _removedViews;
		private List<string> _modalView;
		private List<string> _currentFocusedControl;

		public List<string> ModalViews { get { return _modalView; }  }

		public List<ClientCommand> Commands
		{
			get { return _newCommands ?? (_newCommands = new List<ClientCommand>()); }
		}



		public List<string> RemovedViews
		{
			get { return _removedViews; }
		}

		public List<string> NewViews
		{
			get { return _newViews; }
		}

        public List<string> CurrentFocusedControl
        {
            get { return _currentFocusedControl; }
            set { _currentFocusedControl = value; }
        }

		internal void AddNewView(IViewModel viewModel, bool isModal)
		{
			IViewModel view = viewModel;
			if (_newViews == null)
			{
				_newViews = new List<string>();
				_newViews.Add(view.UniqueID);
			}
			else
			{
				if (!_newViews.Any(x => x == view.UniqueID))
				{
					_newViews.Add(view.UniqueID);
				}
				else
				{
					TraceUtil.WriteLine("View already marked as new!. Please review this should not happen");
				}
			}
			if (isModal)
			{
				if (_modalView == null)
				{
					_modalView = new List<string>();
				}
				_modalView.Add(view.UniqueID);
			}
		}

		internal void RemoveView(IViewModel view)
		{
			if (_newViews != null && _newViews.Any(x => x == view.UniqueID))
			{

                _newViews.Remove(view.UniqueID);
            }
			else
			{
				if (_removedViews == null)
				{
					_removedViews = new List<string> {view.UniqueID};
				}
				else
				{
					if (!_removedViews.Contains(view.UniqueID))
					{
						_removedViews.Add(view.UniqueID);
					}
				}
			}
		}
	}


/// <summary>
/// Turns the ViewStateDelta into JSON
/// </summary>
    internal class ViewsStateDeltaConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var viewStateDelta = (ViewsStateDelta) value;
            writer.WriteStartObject();
            if (viewStateDelta.Commands!=null && viewStateDelta.Commands.Any())
            {
                writer.WritePropertyName("Commands");
                serializer.Serialize(writer,viewStateDelta.Commands);
            }
            if (viewStateDelta.NewViews!=null && viewStateDelta.NewViews.Any())
            {
                writer.WritePropertyName("NewViews");
                serializer.Serialize(writer,viewStateDelta.NewViews);
            }
            if (viewStateDelta.RemovedViews!=null && viewStateDelta.RemovedViews.Any())
            {
                writer.WritePropertyName("RemovedViews");
                serializer.Serialize(writer, viewStateDelta.RemovedViews);
            }
			if (viewStateDelta.ModalViews != null )
			{
				writer.WritePropertyName("ModalViews");
				serializer.Serialize(writer, viewStateDelta.ModalViews);
			}
            if (viewStateDelta.CurrentFocusedControl != null)
            {
                writer.WritePropertyName("CurrentFocusedControl");
                serializer.Serialize(writer, viewStateDelta.CurrentFocusedControl);
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ViewsStateDelta).IsAssignableFrom(objectType);
        }
    }
}