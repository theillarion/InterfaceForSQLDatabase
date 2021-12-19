using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class InterfaceDB : Form
    {
        private SqlConnection sqlConnection;
        private List<string> columns;
        private List<Type> typeColumns;
        private string nameTable;
        public InterfaceDB(SqlConnection sqlConnection, string nameTable)
        {
            InitializeComponent();
            this.sqlConnection = sqlConnection;
            this.nameTable = nameTable;
        }
            
        private async void Form1_Load(object sender, EventArgs e)
{           
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;

            await LoadColumnTableAsync();
            await LoadTableAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async Task LoadColumnTableAsync()
        {
            SqlDataReader sqlDataReader = null;  // "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Person'"
            SqlCommand getColumnComand = new("SELECT * FROM [" + nameTable + "]", sqlConnection);
            columns = new List<string>();
            typeColumns = new List<Type>();
            try
            {
                sqlDataReader = await getColumnComand.ExecuteReaderAsync();
                
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    columns.Add(sqlDataReader.GetName(i));
                    typeColumns.Add(sqlDataReader.GetFieldType(i));
                }
                        
                foreach (var column in columns)
                    listView1.Columns.Add(column);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                    sqlDataReader.Close();
            }
        }
        private async Task LoadTableAsync()
        {
            SqlDataReader? sqlDataReader = null;
            SqlCommand getTableComand = new("SELECT * FROM [" + nameTable + "]", sqlConnection);

            try
            {
                if (columns.Count > 0)
                {
                    sqlDataReader = await getTableComand.ExecuteReaderAsync();

                    while (await sqlDataReader.ReadAsync())
                    {
                        List<string> row = new List<string>();
                        foreach (var column in columns)
                            row.Add(Convert.ToString(sqlDataReader[column]));
                        listView1.Items.Add(new ListViewItem(row.ToArray()));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
            }
        }

        private void toolStripButtonInsert_Click(object sender, EventArgs e)
        {
            Insert insert = new(sqlConnection, columns, typeColumns, nameTable);
            insert.Show();
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Update update = new(sqlConnection, listView1.SelectedItems[0].SubItems[0].Text, columns, typeColumns, nameTable);
                update.Show();
            }
            else
                MessageBox.Show("Select the line to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row from the database.\nThis is an irreparable action!", "Deleting a line", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SqlCommand deleteComand = new SqlCommand("DELETE FROM [" + nameTable + "] WHERE [" + columns[0] + "]=@Id", sqlConnection);
                    try
                    {
                        deleteComand.Parameters.AddWithValue(columns[0], listView1.SelectedItems[0].SubItems[0].Text);
                        await deleteComand.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    listView1.Clear();
                    await LoadColumnTableAsync();
                    await LoadTableAsync();
                }
            }
            else
                MessageBox.Show("Select the line to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void toolStripButtonUpdateTable_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            await LoadColumnTableAsync();
            await LoadTableAsync();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e) =>
            MessageBox.Show("Interface for working rith SQL database.\n2021", "About the program", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}