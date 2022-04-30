
namespace StructsHelper
{
    partial class TypesDBWnd
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
            this.lbTypesList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTypeNew = new System.Windows.Forms.Button();
            this.btnTypeReset = new System.Windows.Forms.Button();
            this.btnTypeSave = new System.Windows.Forms.Button();
            this.tbTypeSize = new System.Windows.Forms.TextBox();
            this.tbTypeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTypesList
            // 
            this.lbTypesList.FormattingEnabled = true;
            this.lbTypesList.Location = new System.Drawing.Point(12, 12);
            this.lbTypesList.Name = "lbTypesList";
            this.lbTypesList.Size = new System.Drawing.Size(214, 108);
            this.lbTypesList.TabIndex = 0;
            this.lbTypesList.SelectedIndexChanged += new System.EventHandler(this.lbTypesList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTypeNew);
            this.groupBox1.Controls.Add(this.btnTypeReset);
            this.groupBox1.Controls.Add(this.btnTypeSave);
            this.groupBox1.Controls.Add(this.tbTypeSize);
            this.groupBox1.Controls.Add(this.tbTypeName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modify";
            // 
            // btnTypeNew
            // 
            this.btnTypeNew.Location = new System.Drawing.Point(147, 98);
            this.btnTypeNew.Name = "btnTypeNew";
            this.btnTypeNew.Size = new System.Drawing.Size(55, 23);
            this.btnTypeNew.TabIndex = 6;
            this.btnTypeNew.Text = "New...";
            this.btnTypeNew.UseVisualStyleBackColor = true;
            this.btnTypeNew.Click += new System.EventHandler(this.btnTypeNew_Click);
            // 
            // btnTypeReset
            // 
            this.btnTypeReset.Location = new System.Drawing.Point(50, 72);
            this.btnTypeReset.Name = "btnTypeReset";
            this.btnTypeReset.Size = new System.Drawing.Size(75, 23);
            this.btnTypeReset.TabIndex = 5;
            this.btnTypeReset.Text = "Reset";
            this.btnTypeReset.UseVisualStyleBackColor = true;
            // 
            // btnTypeSave
            // 
            this.btnTypeSave.Location = new System.Drawing.Point(127, 72);
            this.btnTypeSave.Name = "btnTypeSave";
            this.btnTypeSave.Size = new System.Drawing.Size(75, 23);
            this.btnTypeSave.TabIndex = 4;
            this.btnTypeSave.Text = "Save";
            this.btnTypeSave.UseVisualStyleBackColor = true;
            this.btnTypeSave.Click += new System.EventHandler(this.btnTypeSave_Click);
            // 
            // tbTypeSize
            // 
            this.tbTypeSize.Location = new System.Drawing.Point(50, 46);
            this.tbTypeSize.MaxLength = 4;
            this.tbTypeSize.Name = "tbTypeSize";
            this.tbTypeSize.Size = new System.Drawing.Size(152, 20);
            this.tbTypeSize.TabIndex = 3;
            // 
            // tbTypeName
            // 
            this.tbTypeName.Location = new System.Drawing.Point(50, 22);
            this.tbTypeName.MaxLength = 64;
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.Size = new System.Drawing.Size(152, 20);
            this.tbTypeName.TabIndex = 2;
            this.tbTypeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTypeName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // TypesDBWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 265);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTypesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypesDBWnd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Types";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TypesDBWnd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTypesList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTypeSize;
        private System.Windows.Forms.TextBox tbTypeName;
        private System.Windows.Forms.Button btnTypeSave;
        private System.Windows.Forms.Button btnTypeReset;
        private System.Windows.Forms.Button btnTypeNew;
    }
}