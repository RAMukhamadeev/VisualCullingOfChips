using System;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormWaferMap : Form
    {
        private WaferMap _waferMap;
        public static FormWaferMap Instance { get; private set; }

        public FormWaferMap()
        {
            InitializeComponent();
            Instance = this;
        }

        public void RefreshWaferMapPicture()
        {
            pbWaferMap.Image = _waferMap.GetBmpWaferMap(pbWaferMap.Width, pbWaferMap.Height);
        }

        public void SetWaferMap(WaferMap waferMap)
        {
            _waferMap = waferMap;
            RefreshWaferMapPicture();
        }


        private void FormWaferMap_Load(object sender, EventArgs e)
        {

        }

        private void FormWaferMap_SizeChanged(object sender, EventArgs e)
        {
            if (_waferMap != null)
            {
                RefreshWaferMapPicture();
            }
        }
    }
}
