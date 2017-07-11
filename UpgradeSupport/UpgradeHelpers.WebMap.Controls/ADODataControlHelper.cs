using System;
using System.ComponentModel;
using System.Web.Mvc;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.DB.ADO.Events;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.Controls
{
	public class ADODataControlHelper : UserControlBaseViewModel
    {
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Recordset = ctx.Resolve<ADORecordSetHelper>();
			Text = "";
		}

        #region Data Members
       

		private String _connectionString;

		/// <summary>
		/// Gets or Sets the LockType Value
		/// </summary>
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.DB.LockTypeEnum LockType { get; set; }

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// Conection String used to connect to the data source
		/// </summary>
		public virtual String ConnectionString
		{
			get
			{
				return _connectionString;
			}
			set
			{
				_connectionString = value;
				SyncRecordset();
			}
		}

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// Database name to connect at the corresponding db connection
		/// </summary>
		public virtual String DatabaseName { get; set; }

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// The Factory Name being used for connecting to the database. 
		/// </summary>
		public virtual String FactoryName { get; set; }

		

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// Password to be used for connecting to the database
		/// </summary>
		public virtual String Password { get; set; }

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// The data source (ADORecordSetHelper) used to connect to the database
		/// </summary>
		public virtual ADORecordSetHelper Recordset { get; set; }


		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual String RecordSource {get;set;}

		[StateManagement(StateManagementValues.ServerOnly)]
		/// <summary>
		/// User name to be used for connecting to the database
		/// </summary>
		public virtual String UserName { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Method used to syncronize the database when an important property for this control is changed, and
		/// a syncronization is needed when a connection proerty is changed.
		/// </summary>
		private void SyncRecordset()
		{
			if (Recordset != null)
			{
				if (string.IsNullOrEmpty(Recordset.ConnectionString) && !string.IsNullOrEmpty(ConnectionString))
				{
					Recordset.ConnectionString = ConnectionString;
				}
				if (!string.IsNullOrEmpty(RecordSource))
				{
                    // Close and reopen the recordset to solve synchronization issues
                    if (Recordset.Opened)
                    {
                        // Check whether or not the connection was opened
                        bool reopenConnection = Recordset.ActiveConnection.State == System.Data.ConnectionState.Open;
                        Recordset.Close();
                        // Open the connection if it was closed in: Recordset.Close();
                        if (reopenConnection)
                        {
                            try
                            {
                                Recordset.ActiveConnection.Open();
                            }
                            catch (Exception ex)
                            {
                                String message = string.Format(
                                    "Problem while trying to reopen the active connection when synchronizing the recorset. Error details {0}",
                                    ex.Message);
                                System.Diagnostics.Trace.TraceError(message);
                            }
                        }
                    }
                    Recordset.Source = RecordSource;
                    Recordset.Open();
				}
			}
		}
		/// <summary>
		/// Syncronize the database manually
		/// </summary>
		public override void Refresh()
		{
			SyncRecordset();
		}

		#endregion

		#region Events

		/// <summary>
		/// Delegate to perform the Move operation after a Move event is executed in the data source. Normally, it executes
		/// the Bind method for Bindings property to syncronize the bindings with the data source.
		/// </summary>
		/// <param name="sender">Record set being moved</param>
		/// <param name="e">Move event args</param>
		public void Recordset_MoveComplete(Object sender, MoveCompleteEventArgs e)
		{
			//TODO: how to get View containing this ADODC
			foreach (IViewModel v in ViewManager.LoadedViews)
			{
				var dataBindingsPi = v.GetType().GetProperty("DataBindings");
				if (dataBindingsPi != null)
				{
					var dataBindings = dataBindingsPi.GetValue(v, null);
					var bindMi = dataBindings.GetType().GetMethod("Bind");
					bindMi.Invoke(dataBindings, new[] { v, sender });
				}
			}
		}
		#endregion

		[Handler()]
		internal void b_first_Click(Object eventSender, EventArgs eventArgs)
		{
			if (Recordset.RecordCount > 0)
			{
				Recordset.MoveComplete += Recordset_MoveComplete;
				Recordset.MoveFirst();
			}
		}

		[Handler()]
		internal void b_prev_Click(Object eventSender, EventArgs eventArgs)
		{
			if (Recordset.CanMovePrevious)
			{
				Recordset.MoveComplete += Recordset_MoveComplete;
				Recordset.MovePrevious();
			}
		}

		[Handler()]
		internal void b_next_Click(Object eventSender, EventArgs eventArgs)
		{
			if (Recordset.CanMoveNext)
			{
				Recordset.MoveComplete += Recordset_MoveComplete;
				Recordset.MoveNext();
			}
		}

		[Handler()]
		internal void b_last_Click(Object eventSender, EventArgs eventArgs)
		{
			if (Recordset.RecordCount > 0)
			{
				Recordset.MoveComplete += Recordset_MoveComplete;
				Recordset.MoveLast();
			}
		}
	}

	public class ADODataControlHelperController : Controller
	{
		/// <summary>
		/// Handles the Click event for first button for ADODC control
		/// </summary>
		/// <param name="usercontrol"></param>
		/// <returns>The ActionResult</returns>
		public ActionResult b_first_Click(ADODataControlHelper usercontrol)
		{
			usercontrol.b_first_Click(null, null);
			return new AppChanges();
		}

		/// <summary>
		/// Handles the Click event for previous button for ADODC control
		/// </summary>
		/// <returns>The ActionResult</returns>
		public ActionResult b_prev_Click(ADODataControlHelper usercontrol)
		{
			usercontrol.b_prev_Click(null, null);
			return new AppChanges();
		}

		/// <summary>
		/// Handles the Click event for next button for ADODC control
		/// </summary>
		/// <returns>The ActionResult</returns>
		public ActionResult b_next_Click(ADODataControlHelper usercontrol)
		{
			usercontrol.b_next_Click(null, null);
			return new AppChanges();
		}

		/// <summary>
		/// Handles the Click event for last button for ADODC control
		/// </summary>
		/// <returns>The ActionResult</returns>
		public ActionResult b_last_Click(ADODataControlHelper usercontrol)
		{
			usercontrol.b_last_Click(null, null);
			return new AppChanges();
		}
	}
}
