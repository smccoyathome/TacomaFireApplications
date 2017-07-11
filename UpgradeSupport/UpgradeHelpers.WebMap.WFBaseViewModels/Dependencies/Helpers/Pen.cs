using Microsoft.Win32;
using System;

namespace UpgradeHelpers.Helpers
{
    public class Pen : IDisposable
    {
        private bool immutable;
        private Color color;

        public Color Color { get; set; }

        public int Width { get; set; }

        public Pen(Color color)
            : this(color, 1f)
        {
        }
        public Pen(Color color, float width)
        {
            this.color = color;
            IntPtr pen = IntPtr.Zero;
            int pen1 = SafeNativeMethods.Gdip.GdipCreatePen1(color.ToArgb(), width, 0, out pen);
            if (pen1 != 0)
                throw SafeNativeMethods.Gdip.StatusException(pen1);
            this.SetNativePen(pen);
            if (!this.color.IsSystemColor)
                return;
            SystemColorTracker.Add((ISystemColorTracker)this);
        }

        internal Pen(Color color, bool immutable)
            : this(color)
        {
            this.immutable = immutable;
        }

        public Pen(Brush _brush)
        {
            // TODO: Complete member initialization
            this._brush = _brush;
        }

        public Pen(object p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public Pen(Brush fillBrush, int p1)
        {
            // TODO: Complete member initialization
            this.fillBrush = fillBrush;
            this.p1 = p1;
        }

        private IntPtr nativePen;
        private Brush _brush;
        private object p;
        private Brush fillBrush;
        private int p1;
        internal void SetNativePen(IntPtr nativePen)
        {
            if (nativePen == IntPtr.Zero)
                throw new ArgumentNullException("nativePen");
            this.nativePen = nativePen;
        }

        internal class SystemColorTracker
        {
            private static int INITIAL_SIZE = 200;
            private static int WARNING_SIZE = 100000;
            private static float EXPAND_THRESHOLD = 0.75f;
            private static int EXPAND_FACTOR = 2;
            private static WeakReference[] list = new WeakReference[SystemColorTracker.INITIAL_SIZE];
            private static int count = 0;
            private static bool addedTracker;

            private SystemColorTracker()
            {
            }

            internal static void Add(ISystemColorTracker obj)
            {
                lock (typeof(SystemColorTracker))
                {
                    if (SystemColorTracker.list.Length == SystemColorTracker.count)
                        SystemColorTracker.GarbageCollectList();
                    if (!SystemColorTracker.addedTracker)
                    {
                        SystemColorTracker.addedTracker = true;
                        SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemColorTracker.OnUserPreferenceChanged);
                    }
                    int local_0 = SystemColorTracker.count;
                    ++SystemColorTracker.count;
                    if (SystemColorTracker.list[local_0] == null)
                        SystemColorTracker.list[local_0] = new WeakReference((object)obj);
                    else
                        SystemColorTracker.list[local_0].Target = (object)obj;
                }
            }

            private static void CleanOutBrokenLinks()
            {
                int index1 = SystemColorTracker.list.Length - 1;
                int index2 = 0;
                int length = SystemColorTracker.list.Length;
                while (true)
                {
                    while (index2 >= length || SystemColorTracker.list[index2].Target == null)
                    {
                        while (index1 >= 0 && SystemColorTracker.list[index1].Target == null)
                            --index1;
                        if (index2 >= index1)
                        {
                            SystemColorTracker.count = index2;
                            return;
                        }
                        WeakReference weakReference = SystemColorTracker.list[index2];
                        SystemColorTracker.list[index2] = SystemColorTracker.list[index1];
                        SystemColorTracker.list[index1] = weakReference;
                        ++index2;
                        --index1;
                    }
                    ++index2;
                }
            }

            private static void GarbageCollectList()
            {
                SystemColorTracker.CleanOutBrokenLinks();
                if ((double)SystemColorTracker.count / (double)SystemColorTracker.list.Length <= (double)SystemColorTracker.EXPAND_THRESHOLD)
                    return;
                WeakReference[] weakReferenceArray = new WeakReference[SystemColorTracker.list.Length * SystemColorTracker.EXPAND_FACTOR];
                SystemColorTracker.list.CopyTo((Array)weakReferenceArray, 0);
                SystemColorTracker.list = weakReferenceArray;
                int length = SystemColorTracker.list.Length;
                int num = SystemColorTracker.WARNING_SIZE;
            }

            private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
            {
                if (e.Category != UserPreferenceCategory.Color)
                    return;
                for (int index = 0; index < SystemColorTracker.count; ++index)
                {
                    ISystemColorTracker systemColorTracker = (ISystemColorTracker)SystemColorTracker.list[index].Target;
                    if (systemColorTracker != null)
                        systemColorTracker.OnSystemColorChanged();
                }
            }
        }

        internal interface ISystemColorTracker
        {
            void OnSystemColorChanged();
        }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}

        public DashStyle DashStyle { get; set; }
    }
}