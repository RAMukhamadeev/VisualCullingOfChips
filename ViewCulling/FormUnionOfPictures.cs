using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewCulling
{
    public partial class FormUnionOfPictures : Form
    {
        public FormUnionOfPictures()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            pbUnitedImage.Image = image;
        }

        private void FormUnionOfPictures_Load(object sender, EventArgs e)
        {

        }
    }
}
