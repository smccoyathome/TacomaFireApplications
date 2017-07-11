using System;
namespace UpgradeHelpers.DB
{
    /// <summary>
    /// Delegate ValidatingEventHandler, used to process event ValidatingEventHandler.
    /// </summary>
    /// <param name="sender">Object sender.</param>
    /// <param name="e">ValidatingEventArgs to process.</param>
    public delegate void ValidatingEventHandler(object sender, ValidatingEventArgs e);

    /// <summary>
    /// Class ValidatingEventArgs, used to process event ValidatingEventHandler parameters.
    /// </summary>
    public class ValidatingEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor ValidatingEventArgs, recive Action and Save.
        /// </summary>
        public ValidatingEventArgs(int Action, int Save)
        {
            this.Action = Action;
            this.Save = Save;
        }

        private int _Action;
        /// <summary>
        /// Integer Property Action.
        /// </summary>
        public int Action
        {
            get
            {
                return _Action;
            }
            set
            {
                _Action = value;
            }
        }

        private int _Save;
        /// <summary>
        /// Integer Property Save.
        /// </summary>
        public int Save
        {
            get
            {
                return _Save;
            }
            set
            {
                _Save = value;
            }
        }
    }

        
    
}