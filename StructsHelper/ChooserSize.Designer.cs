namespace StructsHelper
{
    partial class ChooserSize
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
            this.btOk = new System.Windows.Forms.Button();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.lHelp = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lClosestSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(47, 105);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 25);
            this.btOk.TabIndex = 2;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // cbTypes
            // 
            this.cbTypes.DropDownHeight = 105;
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.IntegralHeight = false;
            this.cbTypes.Location = new System.Drawing.Point(25, 49);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(120, 21);
            this.cbTypes.TabIndex = 0;
            // 
            // lHelp
            // 
            this.lHelp.AutoSize = true;
            this.lHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lHelp.Location = new System.Drawing.Point(12, 9);
            this.lHelp.Name = "lHelp";
            this.lHelp.Size = new System.Drawing.Size(0, 16);
            this.lHelp.TabIndex = 2;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(36, 76);
            this.tbSize.MaxLength = 12;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(100, 20);
            this.tbSize.TabIndex = 0;
            this.tbSize.TextChanged += new System.EventHandler(this.TbSize_TextChanged);
            this.tbSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSize_KeyPress);
            // 
            // lClosestSize
            // 
            this.lClosestSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lClosestSize.AutoSize = true;
            this.lClosestSize.Location = new System.Drawing.Point(142, 79);
            this.lClosestSize.Name = "lClosestSize";
            this.lClosestSize.Size = new System.Drawing.Size(0, 13);
            this.lClosestSize.TabIndex = 3;
            // 
            // ChooserSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(172, 142);
            this.Controls.Add(this.lClosestSize);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.lHelp);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooserSize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.Label lHelp;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lClosestSize;
    }
}