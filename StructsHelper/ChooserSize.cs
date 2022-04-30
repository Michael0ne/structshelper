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
        public int g_nSelectedTypeSize { get; set; }
        public int g_nSelectedSize { get; set; }
        public int g_nSelectedTypeIndex { get; set; }

        private char LastPressedKey = (char)0;

        private void RecalculateSize()
        {
            //  Is hexidecimal?
            if (tbSize.TextLength == 2 && tbSize.Text[0] == '0' && tbSize.Text[1] == 'x')
                return;

            int number_actual = -1;
            if (tbSize.TextLength > 2 && tbSize.Text[0] == '0' && tbSize.Text[1] == 'x')
                number_actual = Convert.ToInt32(tbSize.Text, 16);
            else
                number_actual = Convert.ToInt32(tbSize.Text);

            int selected_type = TypesDB.Instance.GetSizeByTypeId(cbTypes.SelectedIndex);

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

            g_nSelectedTypeSize = -1;
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

            cbTypes.SelectedIndexChanged += Debug_HandleComboBoxIndexChange;

            //  Fill all possible types from TypesDB.
            foreach (TypesDB.TypeInfo type in TypesDB.Instance.typeslist)
            {
                cbTypes.Items.Add(type.ToString());
            }

            cbTypes.SelectedIndex = 0;
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
            bool isHexadecimal = false;

            if (tbSize.Text.Length == 2 && tbSize.Text[0] == '0' && tbSize.Text[1] == 'x')
                return;

            if (tbSize.Text.Length > 2 && tbSize.Text[0] == '0' && tbSize.Text[1] == 'x')
                isHexadecimal = true;

            this.g_nSelectedTypeSize = TypesDB.Instance.GetSizeByTypeId(cbTypes.SelectedIndex);
            this.g_nSelectedTypeIndex = cbTypes.SelectedIndex;

            if (!tbSize.Visible)
            {
                this.Close();
                return;
            }

            this.g_nSelectedSize = Convert.ToInt32(tbSize.Text, isHexadecimal ? 16 : 10);

            if (g_nSelectedSize % g_nSelectedTypeSize != 0)
            {
                int closest_size = g_nSelectedSize - ((g_nSelectedSize / g_nSelectedTypeSize) * g_nSelectedTypeSize);
                this.g_nSelectedSize -= closest_size;
            }

            if (g_nSelectedSize < g_nSelectedTypeSize)
            {
                MessageBox.Show("Structure size cannot be less than the size of the type it's made of!");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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

            LastPressedKey = e.KeyChar;
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
