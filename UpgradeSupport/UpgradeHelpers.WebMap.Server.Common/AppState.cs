using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Returns a Json Object the represents the current state of the 
	/// WebMap application
	/// 
	///	{
	///	LoadedViews [{UniqueID:"2",ZOrder="-1",Visible:false}] 
	///	Commands : 
	///	[
	///		{
	///		id: "message", 
	///		UniqueID:"0034", 
	///		Continuation_UniqueID: "0123", 
	///		parameters: { text : "message1", caption = "Dialog Caption", buttons = , icons = icons, messageBoxDefaultButton = messageBoxDefaultButton, messageBoxOptions = messageBoxOptions }
	///		}],
	///	InModalExecution = false,
	///	ModalViews: ["2","3","3"],
	///}
	/// 
	/// </summary>
	/// 

	public class AppState : ActionResult
	{
        public static Action<System.IO.TextWriter> AppStateDelegate;
		public override void ExecuteResult(ControllerContext context)
		{
			var response = context.HttpContext.Response;
			response.ContentType = "application/json";
			if (AppStateDelegate == null)
				throw new AppStateResultDelegateHasNotBeenSet();
			AppStateDelegate(response.Output);
		}
	}
}
