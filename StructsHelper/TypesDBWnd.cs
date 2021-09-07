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
    public partial class TypesDBWnd : Form
    {
        public TypesDBWnd()
        {
            InitializeComponent();

            btnTypeSave.Enabled = false;
            btnTypeReset.Enabled = false;
            tbTypeName.Enabled = false;
            tbTypeSize.Enabled = false;
        }

        private void TypesDBWnd_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2);
            this.Top = (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2);

            //  Register builtin types.
            TypesDB.Instance.RegisterBuiltinType("char", 1);
            TypesDB.Instance.RegisterBuiltinType("bool", 1);
            TypesDB.Instance.RegisterBuiltinType("short", 2);
            TypesDB.Instance.RegisterBuiltinType("int", 4);

            //  Propagate list with types.
            lbTypesList.Items.Clear();
            foreach (TypesDB.TypeInfo ti in TypesDB.Instance.typeslist)
                lbTypesList.Items.Add(ti);
        }

        private void lbTypesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTypesList.SelectedIndex == -1)
                return;

            TypesDB.TypeInfo ti = ((TypesDB.TypeInfo)lbTypesList.Items[lbTypesList.SelectedIndex]);
            if (ti.IsBuiltin)
            {
                btnTypeSave.Enabled = false;
                btnTypeReset.Enabled = false;
                btnTypeNew.Enabled = true;
                tbTypeName.Enabled = false;
                tbTypeSize.Enabled = false;
            }
            else
            {
                btnTypeSave.Enabled = true;
                btnTypeReset.Enabled = true;
                btnTypeNew.Enabled = true;
                tbTypeName.Enabled = true;
                tbTypeSize.Enabled = true;
            }

            tbTypeName.Text = ti.TypeName;
            tbTypeSize.Text = ti.TypeSize.ToString();
        }

        private void btnTypeNew_Click(object sender, EventArgs e)
        {
            if (lbTypesList.SelectedIndex != -1)
                lbTypesList.SelectedIndex = -1;

            btnTypeSave.Enabled = true;
            btnTypeReset.Enabled = true;
            btnTypeNew.Enabled = false;
            tbTypeName.Enabled = true;
            tbTypeSize.Enabled = true;

            tbTypeName.Clear();
            tbTypeSize.Clear();

            tbTypeName.Focus();
        }

        private void btnTypeSave_Click(object sender, EventArgs e)
        {
            if (tbTypeName.Text.Length == 0 || tbTypeSize.Text.Length == 0)
            {
                MessageBox.Show("Both parameters must be filled in!");
                return;
            }

            TypesDB.TypeInfo ti = new TypesDB.TypeInfo(tbTypeName.Text, int.Parse(tbTypeSize.Text));
            TypesDB.Instance.RegisterType(ti);
            lbTypesList.Items.Add(ti);

            tbTypeName.Clear();
            tbTypeSize.Clear();
            tbTypeName.Focus();
        }

        private void tbTypeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                return;

            if (e.KeyChar < '0')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar > '9')
            {
                if (e.KeyChar < 'A')
                {
                    e.Handled = true;
                    return;
                }

                if (e.KeyChar > 'Z' && e.KeyChar < 'a' && e.KeyChar != '_')
                {
                    e.Handled = true;
                    return;
                }

                if (e.KeyChar > 'z')
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
