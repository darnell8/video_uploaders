namespace Sunny.UI.Demo
{
    partial class FPageMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPageMain));
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("uiImageButton1.Image")));
            this.uiImageButton1.Location = new System.Drawing.Point(91, 39);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(624, 357);
            this.uiImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.uiImageButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButton1.TabIndex = 0;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = null;
            this.uiImageButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiImageButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FPageMain
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiImageButton1);
            this.Name = "FPageMain";
            this.PageIndex = 1001;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "FPage1";
            this.Initialize += new System.EventHandler(this.FPage1_Initialize);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FPageMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FPageMain_DragEnter);
            this.DragLeave += new System.EventHandler(this.FPageMain_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIImageButton uiImageButton1;
    }
}