namespace MouseTrace
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStart = new Button();
            buttonStop = new Button();
            buttonView = new Button();
            pictureBox1 = new PictureBox();
            buttonAnterior = new Button();
            buttonSeguinte = new Button();
            listBoxScreens = new ListBox();
            pictureBoxScreen = new PictureBox();
            textBox1 = new TextBox();
            buttonReset = new Button();
            buttonSave = new Button();
            linkLabel1 = new LinkLabel();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScreen).BeginInit();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Enabled = false;
            buttonStart.Location = new Point(13, 96);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new Point(13, 125);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonView
            // 
            buttonView.Enabled = false;
            buttonView.Location = new Point(173, 141);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(75, 23);
            buttonView.TabIndex = 2;
            buttonView.Text = "View";
            buttonView.UseVisualStyleBackColor = true;
            buttonView.Click += buttonView_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 170);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // buttonAnterior
            // 
            buttonAnterior.Enabled = false;
            buttonAnterior.Location = new Point(12, 342);
            buttonAnterior.Name = "buttonAnterior";
            buttonAnterior.Size = new Size(75, 23);
            buttonAnterior.TabIndex = 4;
            buttonAnterior.Text = "Anterior";
            buttonAnterior.UseVisualStyleBackColor = true;
            buttonAnterior.Click += buttonAnterior_Click;
            // 
            // buttonSeguinte
            // 
            buttonSeguinte.Enabled = false;
            buttonSeguinte.Location = new Point(173, 342);
            buttonSeguinte.Name = "buttonSeguinte";
            buttonSeguinte.Size = new Size(75, 23);
            buttonSeguinte.TabIndex = 5;
            buttonSeguinte.Text = "Seguinte";
            buttonSeguinte.UseVisualStyleBackColor = true;
            buttonSeguinte.Click += buttonSeguinte_Click;
            // 
            // listBoxScreens
            // 
            listBoxScreens.FormattingEnabled = true;
            listBoxScreens.ItemHeight = 15;
            listBoxScreens.Location = new Point(12, 12);
            listBoxScreens.Name = "listBoxScreens";
            listBoxScreens.Size = new Size(124, 64);
            listBoxScreens.TabIndex = 6;
            listBoxScreens.SelectedIndexChanged += listBoxScreens_SelectedIndexChanged;
            // 
            // pictureBoxScreen
            // 
            pictureBoxScreen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxScreen.Location = new Point(151, 12);
            pictureBoxScreen.Name = "pictureBoxScreen";
            pictureBoxScreen.Size = new Size(97, 64);
            pictureBoxScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxScreen.TabIndex = 7;
            pictureBoxScreen.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(93, 343);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(74, 23);
            textBox1.TabIndex = 8;
            textBox1.Text = "0/0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.Red;
            buttonReset.Enabled = false;
            buttonReset.Location = new Point(13, 401);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(235, 23);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonSave
            // 
            buttonSave.Enabled = false;
            buttonSave.Location = new Point(12, 372);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(235, 23);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(186, 321);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(61, 15);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "FullScreen";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(173, 112);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 12;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 436);
            Controls.Add(buttonLoad);
            Controls.Add(linkLabel1);
            Controls.Add(buttonSave);
            Controls.Add(buttonReset);
            Controls.Add(textBox1);
            Controls.Add(pictureBoxScreen);
            Controls.Add(listBoxScreens);
            Controls.Add(buttonSeguinte);
            Controls.Add(buttonAnterior);
            Controls.Add(pictureBox1);
            Controls.Add(buttonView);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScreen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private Button buttonStop;
        private Button buttonView;
        private PictureBox pictureBox1;
        private Button buttonAnterior;
        private Button buttonSeguinte;
        private ListBox listBoxScreens;
        private PictureBox pictureBoxScreen;
        private TextBox textBox1;
        private Button buttonReset;
        private Button buttonSave;
        private LinkLabel linkLabel1;
        private Button buttonLoad;
    }
}