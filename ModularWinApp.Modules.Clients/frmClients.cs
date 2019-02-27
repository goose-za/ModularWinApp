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
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
        }

        public DataSet SelectedClients
        {
            get;
            private set;
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            ClientsService _cs = new ClientsService();
            this.dgvClients.DataSource = _cs.GetClientsDataTable();

        }

        private void bthReturnSelectedClients_Click(object sender, EventArgs e)
        {
            if (this.SelectedClients != null)
                this.SelectedClients = null;

            this.SelectedClients = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(System.Int32));
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("DateOfBirth", typeof(System.DateTime));
            dt.Columns.Add("Fone", typeof(System.String));

            this.SelectedClients.Tables.Add(dt);

            foreach (var r in dgvClients.SelectedRows)
            {
                DataRow dr = this.SelectedClients.Tables[0].NewRow();

                dr["ID"] = int.Parse(((DataGridViewRow)r).Cells[0].Value.ToString());
                dr["Name"] = ((DataGridViewRow)r).Cells[1].Value.ToString();
                dr["DateOfBirth"] = ((DataGridViewRow)r).Cells[2].Value.ToString();
                dr["Fone"] = ((DataGridViewRow)r).Cells[3].Value.ToString();
                this.SelectedClients.Tables[0].Rows.Add(dr);
            }
            this.Close();
        }
    }
}
