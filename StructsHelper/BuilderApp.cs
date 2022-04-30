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
    public partial class BuilderApp : Form
    {
        //  App states enum & strings for toolstrip text.
        public enum eAppStates
        {
            STATE_AWAIT,
            STATE_READY,
            STATE_FAILED,
            STATE_ATTENTION,
            STATE_COPIED,
            STATE_TOTAL_NUMBER
        };

        private string[] sAppStates =
        {
            "Waiting",
            "Ready",
            "Failed",
            "Attention required",
            "Copied",
            "dummy"
        };

        //  Version info.
        private const int nVersion = 104;   //  Digits: 1 = major, 2 = minor, 3 = build.

        private string[] sAboutInfo =
        {
            "About program",
            "Structures builder helper\nVersion: " + nVersion / 100 + "." + nVersion % 100 + "\nDesigned to be used at home."
        };

        //  Table to hold current structure information.
        private struct StrucInfo
        {
            public int m_nSize;
            public int m_nCreatedWithType;
            public int m_nElementsCount;
        };

        private StrucInfo g_StrucInfo;

        //  Globals.
        public eAppStates g_nAppState;

        public Random g_Rand;

        private ToolTip g_Tooltip;

        //  Menu helpers.
        private enum eMenuIds
        {
            MENU_ACTIONS,
            MENU_EDIT,
            MENU_ABOUT
        }

        private enum eMenuActions_Ids
        {
            ACTION_CREATE,
            ACTION_CLEAR,
            ACTION_COPYTOCLIPBOARD,
            ACTION_ALWAYSONTOP,
            ACTION_TYPEDB
        };

        private enum eMenuEdit_Ids
        {
            EDIT_CHANGETYPE,
            EDIT_PACKINTOSINGLE,
            EDIT_COPYVAL
        }

        public BuilderApp()
        {
            InitializeComponent();

            Init();
        }

        private void UpdateAppState(eAppStates newState)
        {
            g_nAppState = newState;

            this.tsAppState.Text = sAppStates[(int)g_nAppState];
        }

        private void MenuStripClick_About(object sender, EventArgs e)
        {
            MessageBox.Show(sAboutInfo[1], sAboutInfo[0], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuStripClick_AlwaysOnTop(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void MenuStripClick_Create(object sender, EventArgs e)
        {
            lbStruc.Items.Clear();

            using (ChooserSize dialog = new ChooserSize(false))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    g_StrucInfo.m_nSize = dialog.g_nSelectedSize;
                    g_StrucInfo.m_nCreatedWithType = dialog.g_nSelectedTypeSize;
                    g_StrucInfo.m_nElementsCount = (g_StrucInfo.m_nSize / g_StrucInfo.m_nCreatedWithType);

                    int currOffset = 0;
                    string typeName = TypesDB.Instance.GetTypeNameById(dialog.g_nSelectedTypeIndex);
                    while (currOffset < g_StrucInfo.m_nSize)
                    {
                        lbStruc.Items.Add(typeName + "\tfield_" + currOffset.ToString("X"));

                        currOffset += g_StrucInfo.m_nCreatedWithType;
                    }

                    this.tsInfo.Text = "Size: " + g_StrucInfo.m_nSize + " (0x" + g_StrucInfo.m_nSize.ToString("X") + ") bytes, " + g_StrucInfo.m_nElementsCount + " elements.";

                    UpdateAppState(eAppStates.STATE_READY);

                    ((ToolStripMenuItem)this.msMain.Items[(int)eMenuIds.MENU_ACTIONS]).DropDownItems[(int)eMenuActions_Ids.ACTION_CLEAR].Enabled = true;
                    ((ToolStripMenuItem)this.msMain.Items[(int)eMenuIds.MENU_ACTIONS]).DropDownItems[(int)eMenuActions_Ids.ACTION_COPYTOCLIPBOARD].Enabled = true;
                }
            }
        }

        private void MenuStripClick_Clear(object sender, EventArgs e)
        {
            lbStruc.Items.Clear();

            this.tsInfo.Text = "";

            UpdateAppState(eAppStates.STATE_AWAIT);

            this.msMain.Items[(int)eMenuIds.MENU_EDIT].Enabled = false;

            ((ToolStripMenuItem)this.msMain.Items[(int)eMenuIds.MENU_ACTIONS]).DropDownItems[(int)eMenuActions_Ids.ACTION_CLEAR].Enabled = false;
            ((ToolStripMenuItem)this.msMain.Items[(int)eMenuIds.MENU_ACTIONS]).DropDownItems[(int)eMenuActions_Ids.ACTION_COPYTOCLIPBOARD].Enabled = false;
        }

        private void MenuStripClick_CopyToClipb(object sender, EventArgs e)
        {
            string buffer = "";

            foreach (var item in lbStruc.Items)
                buffer += item.ToString() + ";\n";

            Clipboard.SetText(buffer);

            UpdateAppState(eAppStates.STATE_COPIED);
        }

        private void MenuStripClick_ChangeType(object sender, EventArgs e)
        {
            if (lbStruc.SelectedIndex == -1)
                return;

            using (ChooserSize dialog = new ChooserSize(true))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int desired_type = dialog.g_nSelectedTypeSize;
                    string typeName = TypesDB.Instance.GetTypeNameById(dialog.g_nSelectedTypeIndex);

                    string field_text = (String)lbStruc.SelectedItem;
                    string field_type = field_text.Substring(0, field_text.IndexOf('\t'));
                    string field_offset = field_text.Substring(field_text.LastIndexOf('_') + 1);

                    string next_field_offet;
                    if (lbStruc.SelectedIndex + 1 >= g_StrucInfo.m_nElementsCount)
                        next_field_offet = "field_" + g_StrucInfo.m_nSize.ToString("X");
                    else
                        next_field_offet = lbStruc.Items[lbStruc.SelectedIndex + 1].ToString();
                    next_field_offet = next_field_offet.Substring(next_field_offet.LastIndexOf('_') + 1);

                    int field_size = int.Parse(next_field_offet, System.Globalization.NumberStyles.HexNumber) - int.Parse(field_offset, System.Globalization.NumberStyles.HexNumber);

                    //  Didn't change anything.
                    if (desired_type == field_size)
                        return;

                    //  New size is bigger than structure size. Grow struct size.
                    if (desired_type > field_size)
                        tsInfo.Text = "Structure has grown by " + desired_type + " bytes!";

                    lbStruc.Items[lbStruc.SelectedIndex] = typeName + "\tfield_" + field_offset;
                }

                dialog.Dispose();
            }
        }

        private void MenuStripClick_Pack(object sender, EventArgs e)
        {
            //  Don't do anything if created with type size 1 (char).
            if (g_StrucInfo.m_nCreatedWithType == 1)
                return;

            //  Convert selected field from whatever type it is into an array of smaller types (char).
            string selectedItemText = lbStruc.Items[lbStruc.SelectedIndex].ToString();
            string selectedItemType = selectedItemText.Substring(0, selectedItemText.IndexOf('_'));
            int selectedItemOffset = Convert.ToInt32(selectedItemText.Substring(selectedItemText.IndexOf('_') + 1), 16);

            int i = lbStruc.SelectedIndex;
            for (; i < lbStruc.SelectedIndex + 4; ++i, ++selectedItemOffset)
                lbStruc.Items[i] = "char\tfield_" + selectedItemOffset.ToString("X");

            for (; i < lbStruc.Items.Count; ++i, selectedItemOffset += g_StrucInfo.m_nCreatedWithType)
                lbStruc.Items[i] = selectedItemType + "_" + selectedItemOffset.ToString("X");

        }

        private void MenuStripClick_CopyVal(object sender, EventArgs e)
        {
            if (lbStruc.SelectedIndex == -1)
                return;

            Clipboard.SetText((String)lbStruc.SelectedItem);

            UpdateAppState(eAppStates.STATE_COPIED);
        }

        private void MenuStripClick_OpenTypeDB(object sender, EventArgs e)
        {
            using (TypesDBWnd dialog = new TypesDBWnd())
            {
                dialog.ShowDialog();
            }
        }

        private void ListBoxStruc_ItemClick(object sender, MouseEventArgs e)
        {
            if (lbStruc.SelectedIndex == -1)
                this.msMain.Items[(int)eMenuIds.MENU_EDIT].Enabled = false;
            else
            {
                this.msMain.Items[(int)eMenuIds.MENU_EDIT].Enabled = true;

                string field_text = (String)lbStruc.SelectedItem;
                string field_type = field_text.Substring(0, field_text.IndexOf('\t'));
                string field_offset = field_text.Substring(field_text.LastIndexOf('_') + 1);
                string next_field;
                if (lbStruc.SelectedIndex + 1 >= g_StrucInfo.m_nElementsCount)
                    next_field = "field_" + g_StrucInfo.m_nSize.ToString("X");
                else
                    next_field = lbStruc.Items[lbStruc.SelectedIndex + 1].ToString();
                string next_field_offset = next_field.Substring(next_field.LastIndexOf('_') + 1);

#if DEBUG
                tsInfo.Text = "offset: curr=" + field_offset + ", next=" + next_field_offset;
#endif

                int field_type_size = int.Parse(next_field_offset, System.Globalization.NumberStyles.HexNumber) - int.Parse(field_offset, System.Globalization.NumberStyles.HexNumber);

                g_Tooltip.SetToolTip(lbStruc, "Type: " + field_type + " (" + field_type_size + " bytes), Offset: 0x" + field_offset);
            }
        }

        private void BuilderApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape && lbStruc.SelectedIndex != -1)
            {
                lbStruc.ClearSelected();
                tsInfo.Text = "Size: " + g_StrucInfo.m_nSize + " (0x" + g_StrucInfo.m_nSize.ToString("X") + ") bytes, " + g_StrucInfo.m_nElementsCount + " elements.";
                msMain.Items[(int)eMenuIds.MENU_EDIT].Enabled = false;
            }
        }

        private void Init()
        {
            g_Rand = new Random();
            g_StrucInfo = new StrucInfo();

            this.Text = "Structures Helper";
            this.MaximizeBox = false;

            UpdateAppState(eAppStates.STATE_AWAIT);

            //  Menu items.
            ToolStripMenuItem tsmiActions = new ToolStripMenuItem("Actions");
            ToolStripMenuItem tsmiEdit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem tsmiAbout = new ToolStripMenuItem("About");

            tsmiActions.DropDownItems.Add("Create...");
            tsmiActions.DropDownItems.Add("Clear").Enabled = false;
            tsmiActions.DropDownItems.Add("Copy to clipboard").Enabled = false;
            tsmiActions.DropDownItems.Add("Always on top");
            tsmiActions.DropDownItems.Add("Types database");

            tsmiActions.DropDownItems[(int)eMenuActions_Ids.ACTION_CREATE].Click += MenuStripClick_Create;
            tsmiActions.DropDownItems[(int)eMenuActions_Ids.ACTION_CLEAR].Click += MenuStripClick_Clear;
            tsmiActions.DropDownItems[(int)eMenuActions_Ids.ACTION_COPYTOCLIPBOARD].Click += MenuStripClick_CopyToClipb;
            tsmiActions.DropDownItems[(int)eMenuActions_Ids.ACTION_ALWAYSONTOP].Click += MenuStripClick_AlwaysOnTop;
            tsmiActions.DropDownItems[(int)eMenuActions_Ids.ACTION_TYPEDB].Click += MenuStripClick_OpenTypeDB;

            tsmiEdit.DropDownItems.Add("Change type");
            tsmiEdit.DropDownItems.Add("Pack into single field array");
            tsmiEdit.DropDownItems.Add("Copy value to clipboard");

            tsmiEdit.DropDownItems[(int)eMenuEdit_Ids.EDIT_CHANGETYPE].Click += MenuStripClick_ChangeType;
            tsmiEdit.DropDownItems[(int)eMenuEdit_Ids.EDIT_PACKINTOSINGLE].Click += MenuStripClick_Pack;
            tsmiEdit.DropDownItems[(int)eMenuEdit_Ids.EDIT_COPYVAL].Click += MenuStripClick_CopyVal;

            tsmiAbout.Click += MenuStripClick_About;

            this.msMain.Items.Add(tsmiActions);
            this.msMain.Items.Add(tsmiEdit);
            this.msMain.Items.Add(tsmiAbout);

            if (g_nAppState != eAppStates.STATE_READY)
                this.msMain.Items[(int)eMenuIds.MENU_EDIT].Enabled = false;

            g_Tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
        }

        private void BuilderApp_ResizeWnd(object sender, EventArgs e)
        {
            lbStruc.Width = Width - 40;
            lbStruc.Height = Height - 110;
        }
    }
}
