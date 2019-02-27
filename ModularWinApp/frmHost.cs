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
    /// <summary>
    /// <para>
    /// The Host is the main form; in this case, 
    /// it is an MDI parent. 
    /// </para>
    /// <para>
    /// In this form, there 
    /// is a MainMenu where the modules will insert 
    /// the menus. The module can decide whether 
    /// the form it presents is an MDI child or not.
    /// </para>
    /// </summary>
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
