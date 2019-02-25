using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using ModularWinApp.Core.Interfaces;

namespace ModularWinApp
{
    [Export(typeof(IHost))]
    public partial class frmHost : Form, IHost
    {
        public frmHost()
        {
            InitializeComponent();
        }

        private void frmHost_Load(object sender, EventArgs e)
        {
            //Here, the exported menus will be attached to the main menu.
            foreach (var menu in Program._modHandler.MenuList)
            {
                this.menuStrip1.Items.Add(menu.Value.WinFormsMenu);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            if (Program._modHandler != null)
            {
                //call the ModuleHandler Dispose method
                Program._modHandler.Dispose();
                Program._modHandler = null;
            }
            Application.Exit();
        }
    }
}
