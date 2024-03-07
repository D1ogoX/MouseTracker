using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseTrace
{
    public partial class FormFullScreen : Form
    {
        public FormFullScreen(Image img)
        {
            InitializeComponent();

            pictureBox1.Image = img;
        }

        private void FormFullScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
