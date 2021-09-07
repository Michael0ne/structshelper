namespace StructsHelper
{
    partial class BuilderApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuilderApp));
            this.ssApp = new System.Windows.Forms.StatusStrip();
            this.tsAppState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStruc = new System.Windows.Forms.ListBox();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.ssApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssApp
            // 
            this.ssApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAppState,
            this.tsInfo});
            this.ssApp.Location = new System.Drawing.Point(0, 420);
            this.ssApp.Name = "ssApp";
            this.ssApp.Size = new System.Drawing.Size(784, 22);
            this.ssApp.SizingGrip = false;
            this.ssApp.TabIndex = 0;
            this.ssApp.Text = "statusStrip1";
            // 
            // tsAppState
            // 
            this.tsAppState.Name = "tsAppState";
            this.tsAppState.Size = new System.Drawing.Size(0, 17);
            // 
            // tsInfo
            // 
            this.tsInfo.Name = "tsInfo";
            this.tsInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // lbStruc
            // 
            this.lbStruc.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStruc.FormattingEnabled = true;
            this.lbStruc.ItemHeight = 16;
            this.lbStruc.Location = new System.Drawing.Point(12, 38);
            this.lbStruc.Name = "lbStruc";
            this.lbStruc.Size = new System.Drawing.Size(760, 356);
            this.lbStruc.TabIndex = 1;
            this.lbStruc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxStruc_ItemClick);
            // 
            // msMain
            // 
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(784, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // BuilderApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.lbStruc);
            this.Controls.Add(this.ssApp);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "BuilderApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuilderApp_KeyPress);
            this.Resize += new System.EventHandler(this.BuilderApp_ResizeWnd);
            this.ssApp.ResumeLayout(false);
            this.ssApp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssApp;
        private System.Windows.Forms.ToolStripStatusLabel tsAppState;
        private System.Windows.Forms.ListBox lbStruc;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripStatusLabel tsInfo;
    }
}

