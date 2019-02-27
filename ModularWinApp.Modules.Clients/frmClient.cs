using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularWinApp.Modules.Clients
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClientsService _cs = new ClientsService();
            if (this.txtId.Text == "")
            {
                int newID = _cs.Insert(this.txtName.Text, dtpDateOfBirth.Value, this.txtPhone.Text);
                this.txtId.Text = newID.ToString();
            }
        }
    }
}
