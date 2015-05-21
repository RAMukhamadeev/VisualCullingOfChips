namespace ViewCulling
{
    partial class FormWaferMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaferMap));
            this.pbWaferMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaferMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWaferMap
            // 
            this.pbWaferMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWaferMap.Location = new System.Drawing.Point(12, 12);
            this.pbWaferMap.Name = "pbWaferMap";
            this.pbWaferMap.Size = new System.Drawing.Size(912, 649);
            this.pbWaferMap.TabIndex = 0;
            this.pbWaferMap.TabStop = false;
            // 
            // FormWaferMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(936, 673);
            this.Controls.Add(this.pbWaferMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWaferMap";
            this.Text = "FormWaferMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormWaferMap_Load);
            this.SizeChanged += new System.EventHandler(this.FormWaferMap_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbWaferMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWaferMap;
    }
}