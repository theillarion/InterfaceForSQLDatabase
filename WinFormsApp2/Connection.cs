using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Connection : Form
    {
        private SqlConnection sqlConnection;
        public Connection()
        {
            InitializeComponent();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(textBoxConnectionString.Text);
                await sqlConnection.OpenAsync();
                if (sqlConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("Failed to connect to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var interfaceDB = new InterfaceDB(sqlConnection);
                    interfaceDB.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
