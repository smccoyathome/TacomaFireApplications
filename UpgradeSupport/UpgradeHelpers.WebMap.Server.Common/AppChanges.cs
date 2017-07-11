using System;
using System.Web;
using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Returns the current Application State Changes 
	/// that were detected
	/// after performing an action on the client.
	/// The following is an example. All properties are optional
	/// { 
	///  SessionTimeout: false, 
	///  SW: [ ["1#Array1#2", "0#Array1#2" ], ["2#Array1#2", "1#Array1#2] ] ]
	///  MD: [ { UniqueID: 'textBox1#2', Text: "New TextBox Text" }, { UniqueID: 'check1#panel1#2', Checked : false } , { UniqueID: '4', Text : "New form2 caption" }]
	///  VD : { NewViews: ["4" ], CurrentFocusedControl: "check1#panel1#2" }
	///  RM: [ "0#Array1#2" ]
	///  }
	/// 
	/// </summary>
	public class AppChanges : JsonResult
	{
		public static CalculateAppChanges AppChangesDelegate = null;

		/**
		 * A delegate that can be used to insert additional information along with the current Application State Changes
		 */
		public PiggyBackResult PiggyBackResult { get; set; }

		public override void ExecuteResult(ControllerContext context)
		{
			// verify we have a contrex
			if (context == null)
				throw new ArgumentNullException("context");

			// get the current http context response
			HttpResponseBase response = context.HttpContext.Response;
			// set content type of response
			response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
			// set content encoding of response
			if (ContentEncoding != null)
				response.ContentEncoding = ContentEncoding;
			if (AppChangesDelegate == null)
				throw new AppChangesResultDelegateHasNotBeenSet();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(response.OutputStream))
                AppChangesDelegate(sw, PiggyBackResult);
            response.Output.Flush();
			response.Output.Close();
		}
	}
}