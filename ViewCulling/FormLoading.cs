using System;
using System.Drawing;
using System.Windows.Forms;

namespace ViewCulling
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(10) + 1;

            string path = String.Format("assets\\loading{0}.gif", num);
            Image image = new Bitmap(path);

            pbLoading.Image = image;
        }
    }
}
