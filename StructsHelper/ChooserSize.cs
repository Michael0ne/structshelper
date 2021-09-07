using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StructsHelper
{
    public partial class ChooserSize : Form
    {
        public int g_nSelectedType { get; set; }
        public int g_nSelectedTypeId { get; set; }
        public int g_nSelectedSize { get; set; }

        private void RecalculateSize()
        {
            int number_actual = int.Parse(tbSize.Text);
            int selected_type = cbTypes.SelectedIndex == 2 ? 4 : cbTypes.SelectedIndex + 1;

#if DEBUG
            this.Text = number_actual + ";" + selected_type;
#endif

            if (number_actual > selected_type)
            {
                if (number_actual % selected_type != 0)
                {
                    int closest_size = number_actual - ((number_actual / selected_type) * selected_type);
                    lClosestSize.Text = "(" + (number_actual - closest_size) + ")";
                }
            }
        }

        public ChooserSize(bool bChangeSize)
        {
            InitializeComponent();

            g_nSelectedType = -1;
            g_nSelectedTypeId = -1;
            g_nSelectedSize = 0;

            if (bChangeSize)
            {
                cbTypes.TabIndex = 0;
                tbSize.TabIndex = 1;

                btOk.Text = "Apply";
                btOk.Top = 95;
                lHelp.Text = "Select appropriate type";

                tbSize.Hide();
            }
            else
            {
                cbTypes.TabIndex = 1;

                btOk.Text = "Create";
                btOk.Top = 105;
                lHelp.Text = "Select type and size";

                tbSize.Text = g_nSelectedSize.ToString();
            }

            cbTypes.SelectedIndex = 2;
            cbTypes.SelectedIndexChanged += Debug_HandleComboBoxIndexChange;
        }

        private void Debug_HandleComboBoxIndexChange(object sender, EventArgs e)
        {
#if DEBUG
            this.Text = cbTypes.SelectedIndex.ToString();
#endif
            if (tbSize.Visible)
                RecalculateSize();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            switch (cbTypes.SelectedIndex)
            {
                case 0:
                    this.g_nSelectedType = 1;
                    this.g_nSelectedTypeId = 1;
                    break;
                case 1:
                    this.g_nSelectedType = 2;
                    this.g_nSelectedTypeId = 2;
                    break;
                case 2:
                    this.g_nSelectedType = 4;
                    this.g_nSelectedTypeId = 4;
                    break;
                case 3:
                    this.g_nSelectedType = 4;
                    this.g_nSelectedTypeId = 5;
                    break;
            }

            if (!tbSize.Visible)
            {
                this.Close();
                return;
            }

            this.g_nSelectedSize = int.Parse(tbSize.Text);

            if (g_nSelectedSize % g_nSelectedType != 0)
            {
                int closest_size = g_nSelectedSize - ((g_nSelectedSize / g_nSelectedType) * g_nSelectedType);
                this.g_nSelectedSize -= closest_size;
            }

            this.Close();
        }

        private void tbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btOk_Click(sender, e);
                return;
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
                return;
            }
        }

        private void TbSize_TextChanged(object sender, EventArgs e)
        {
            if (tbSize.Text == null || tbSize.Text == "")
                return;

            lClosestSize.Text = null;

            RecalculateSize();
        }
    }
}
