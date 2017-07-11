using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels.Extensions
{
    public static class DragControlsExtensionMethods
    {

        const string DRAGDROP_STARTCOMMAND = "dragdropstart";
        public static void BeginDrag(this Helpers.ControlViewModel control)
        {
            var container = Helpers.StaticContainer.Instance;
            var viewManager = container.Resolve<IViewManager>();
            var formID = viewManager.GetTopLevelObject(control);
            //A possible issue is if the control not currently attached to any form
            viewManager.ExecOnClient<int>(DRAGDROP_STARTCOMMAND, new { FormUID = formID.UniqueID, ControlUID = control.UniqueID, ControlName = control.Name }, false, true);
        }

        public static ControlViewModel GetSource(this DragEventArgs eventArgs)
        {
            return ((ControlViewModel)eventArgs.Data.GetData(null));

        }

        public static DragEventArgs createDragEventArgs(this Helpers.ControlViewModel control, object objectForId)
        {
            var data = new DragData(objectForId);

            return new DragEventArgs() { Data = data, Effect = Helpers.DragDropEffects.All };
        }


        internal class DragData : IDataObject
        {
            public object draggedControl;
            public DragData(object draggedControl)
            {
                this.draggedControl = draggedControl;
            }

            public object GetData(object p)
            {
                return draggedControl;
            }

            public bool GetDataPresent(object p)
            {
                if (draggedControl != null)
                {
                    return true;
                }
                return false;
            }
        }

    }
}