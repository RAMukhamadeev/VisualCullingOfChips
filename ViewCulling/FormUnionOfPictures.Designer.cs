namespace ViewCulling
{
    partial class FormUnionOfPictures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnionOfPictures));
            this.pbUnitedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnitedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUnitedImage
            // 
            this.pbUnitedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUnitedImage.Location = new System.Drawing.Point(13, 13);
            this.pbUnitedImage.Name = "pbUnitedImage";
            this.pbUnitedImage.Size = new System.Drawing.Size(1445, 736);
            this.pbUnitedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUnitedImage.TabIndex = 0;
            this.pbUnitedImage.TabStop = false;
            // 
            // FormUnionOfPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1470, 761);
            this.Controls.Add(this.pbUnitedImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUnionOfPictures";
            this.Text = "FormUnionOfPictures";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormUnionOfPictures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUnitedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUnitedImage;
    }
}