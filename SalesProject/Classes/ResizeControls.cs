using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace SalesProject
{
    class ResizeControls
    {
        private Hashtable RatioTable = new Hashtable();
        private float WindowHeight;
        private float WindowWidth;
        private float HeightRatio;
        private float WidthRatio;
        private Control _Container = new Control();
        private static long m_FormWidth = 0;                          // Original form width.
        private static long m_FormHeight = 0;
        public Control Container
        {
            get
            {
                return _Container;
            }

            set
            {
                _Container = value;
                FullRatioTable();
            }
        }
        internal partial struct SizeRatio
        {
            public float TopRatio;
            public float LeftRatio;
            public float HeightRatio;
            public float WidthRatio;
        }
        private void FullRatioTable()
        {
            WindowHeight = _Container.Height;
            WindowWidth = _Container.Width;
            RatioTable = new Hashtable();
            AddChildrenToTable(_Container);
        }
        private void AddChildrenToTable(Control ChildContainer)
        {
            var R = new SizeRatio();
            foreach (Control C in ChildContainer.Controls)
            {
                R.TopRatio = C.Top / WindowHeight;
                R.LeftRatio = C.Left / WindowWidth;
                R.HeightRatio = C.Height / WindowHeight;
                R.WidthRatio = C.Width / WindowWidth;
                RatioTable[C.Name] = R;
                if (C.HasChildren)
                {
                    AddChildrenToTable(C);
                }
            }
        }
        public void ResizeControl()
        {
            HeightRatio = _Container.Height / WindowHeight;
            WidthRatio = _Container.Width / WindowWidth;
            WindowHeight = _Container.Height;
            WindowWidth = _Container.Width;
            ResizeChildren(_Container);
        }
        private void ResizeChildren(Control ChildContainer)
        {
            var R = new SizeRatio();
            foreach (Control C in ChildContainer.Controls)
            {
                R = (SizeRatio)RatioTable[C.Name];
                C.Top = (int)(WindowHeight * R.TopRatio);
                C.Left = (int)(WindowWidth * R.LeftRatio);
                C.Height = (int)(WindowHeight * R.HeightRatio);
                C.Width = (int)(WindowWidth * R.WidthRatio);
                if (C.HasChildren)
                {
                    ResizeChildren(C);
                }

                switch (true)
                {
                    case object _ when C is ListBox:
                        {
                            var L = new ListBox();
                            L = (ListBox)C;
                            L.IntegralHeight = false;
                            break;
                        }
                }

                ResizeControlFont(C, WidthRatio, HeightRatio);
            }
        }

        public static void SubResize(Form F, float percentW, float percentH)
        {
            long FormHeight;
            long FormWidth;
            float HeightChange;
            float WidthChange;
            FormHeight = (int)(Screen.PrimaryScreen.WorkingArea.Height * (percentH / 100f));
            FormWidth = (int)(Screen.PrimaryScreen.WorkingArea.Width * (percentW / 100f));
            F.Height = (int)FormHeight;
            F.Width = (int)FormWidth;
            HeightChange = F.ClientSize.Height / m_FormHeight;
            WidthChange = F.ClientSize.Width / m_FormWidth;
        }

        private void ResizeControlFont(Control Ctrl, float RatioW, float RatioH)
        {
            try
            {
                float FSize = Ctrl.Font.Size;
                FontStyle FStyle = Ctrl.Font.Style;
                string FNome = Ctrl.Font.Name;
                float NewSize = FSize;
                NewSize = (float)(FSize * Math.Sqrt(RatioW * RatioH));
                var NFont = new Font(FNome, NewSize, FStyle);
                Ctrl.Font = NFont;
            }
            catch (Exception)
            {

            }

        }
    }
}