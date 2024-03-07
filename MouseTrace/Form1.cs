using System.Windows.Forms;

namespace MouseTrace
{
    public partial class Form1 : Form
    {
        Objects.Recording Recording;

        int position = 0;

        int circleSize = 3;
        Graphics paper;

        public Form1()
        {
            InitializeComponent();

            Recording = new Objects.Recording();

            for (int i = 0; i < Recording.GetScreens().Length; i++)
            {
                listBoxScreens.Items.Add("Screen " + (i + 1));
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Recording.start(listBoxScreens.SelectedIndex);

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            listBoxScreens.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Recording.stop();

            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            buttonView.Enabled = true;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            mudaPosicao(0);

            buttonAnterior.Enabled = true;
            buttonSeguinte.Enabled = true;
            buttonReset.Enabled = true;
            buttonSave.Enabled = true;
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            mudaPosicao(position - 1);
        }

        private void mudaPosicao(int _position)
        {
            if (_position < 0)
                _position = 0;

            this.position = _position;

            try
            {
                if (Recording.GetRecordingPosition(this.position) == null)
                {
                    mudaPosicao(0);
                    return;
                }
            }
            catch
            {
                mudaPosicao(0);
                return;
            }

            pictureBox1.Image = Recording.GetRecordingPosition(this.position).image;

            calculaPosicaoRato(this.position);

            textBox1.Text = (_position + 1) + "/" + Recording.GetCountRecordings();
        }

        private void calculaPosicaoRato(int posicao)
        {
            try
            {
                var _recording = Recording.GetRecordingPosition(posicao);

                // Capture screenshot
                Bitmap screenshot = _recording.image;

                // Calculate scale factors
                float scaleX = (float)screenshot.Width / _recording.screenBoundWidth;
                float scaleY = (float)screenshot.Height / _recording.screenBoundHeight;

                // Draw a yellow circle at the cursor position
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    int x = (int)((_recording.cursorX - _recording.screenBoundLeft) * scaleX);
                    int y = (int)((_recording.cursorY - _recording.screenBoundTop) * scaleY);

                    using (Pen pen = new Pen(Color.Yellow, 5))
                    {
                        g.DrawEllipse(pen, x - 10, y - 10, 15, 15);
                    }
                }

                pictureBox1.Image = screenshot;
                pictureBox1.Refresh();
            }

            catch
            { }
        }

        private void buttonSeguinte_Click(object sender, EventArgs e)
        {
            mudaPosicao(position + 1);
        }

        private void listBoxScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxScreens.SelectedIndex != -1)
            {
                buttonStart.Enabled = true;

                pictureBoxScreen.Image = Recording.GetScreenImageByPosition(listBoxScreens.SelectedIndex);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que quer fazer reset?", "Atenção!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Recording.reset();

                buttonSave.Enabled = false;
                buttonSeguinte.Enabled = false;
                buttonAnterior.Enabled = false;
                buttonView.Enabled = false;
                listBoxScreens.Enabled = true;
                buttonStart.Enabled = true;

                listBoxScreens.SelectedIndex = 0;

                pictureBox1.Image = null;
                textBox1.Text = "0/0";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormFullScreen form = new FormFullScreen(pictureBox1.Image);
            form.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                sfd.Title = "Choose location to save file";
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (Recording.SaveJsonFile(sfd.FileName))
                        MessageBox.Show("Success!");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdl = new OpenFileDialog())
            {
                ofdl.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                ofdl.Title = "Choose file to load";

                if (ofdl.ShowDialog() == DialogResult.OK)
                {
                    Recording.load(ofdl.FileName);

                    mudaPosicao(0);

                    buttonAnterior.Enabled = true;
                    buttonSeguinte.Enabled = true;
                    buttonReset.Enabled = true;
                    buttonSave.Enabled = true;
                }
            }
        }
    }
}