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
        private List<string> nameTables;
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
                    MessageBox.Show("Database connection successful", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadNameTablesAsync();
                    comboBoxTables.Items.Clear();
                    comboBoxTables.Items.AddRange(nameTables.ToArray());
                    comboBoxTables.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadNameTablesAsync()
        {
            SqlDataReader? readerSql = null;
            SqlCommand getNameTablesComand = new SqlCommand("SELECT TABLE_NAME FROM information_schema.tables", sqlConnection);
            nameTables = new List<string>();
            try
            {
                readerSql = await getNameTablesComand.ExecuteReaderAsync();
                while (await readerSql.ReadAsync())
                    nameTables.Add(readerSql.GetString(0));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (readerSql != null && !readerSql.IsClosed)
                    readerSql.Close();
            }
        }

        private void buttonSetTable_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedIndex != -1)
            {
                var interfaceDB = new InterfaceDB(sqlConnection, comboBoxTables.GetItemText(comboBoxTables.SelectedItem));
                interfaceDB.Show();
            }
            else
            {
                MessageBox.Show("The table is ont selected or is not present on the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
