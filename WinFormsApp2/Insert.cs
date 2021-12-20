using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Insert : Form
    {
        private SqlConnection sqlConnection;
        private List<string> columns;
        private List<Type> typeColumns;
        private TextBox[] textBox;
        private string nameTable;
        public Insert(SqlConnection sqlConnection, List<string> columns, List<Type> typeColumns, string nameTable)
        {
            InitializeComponent();
            this.sqlConnection = sqlConnection;
            this.columns = columns;
            this.typeColumns = typeColumns;
            this.nameTable = nameTable;

            int value = 30;
            int i = 0;
            Label[] label = new Label[columns.Count - 1];
            textBox = new TextBox[columns.Count - 1];
            foreach (var column in columns)
            {
                if (column != "Id")
                {
                    label[i] = new Label();
                    label[i].Location = new Point(20, value);
                    label[i].Text = column;
                    textBox[i] = new TextBox();
                    textBox[i].Name = "textBox" + column;
                    textBox[i].Location = new Point(140, value);
                    textBox[i].ScrollBars = ScrollBars.Horizontal;
                    textBox[i].Size = new Size(450, 30);
                    this.Controls.Add(label[i]);
                    this.Controls.Add(textBox[i]);
                    value += 40;
                    i++;
                }
            }
        }
        private async void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            List<string> newColumns = new List<string>(columns);
            List<Type> newTypeColumns = new List<Type>(typeColumns);
            List<TextBox> newTextBox = new List<TextBox>(textBox);
            newColumns.RemoveAt(0);
            newTypeColumns.RemoveAt(0);
            for (int i = 0; i < newColumns.Count; i++)
            {
                if (newTextBox[i].Text == "")
                {
                    newColumns.RemoveAt(i);
                    newTypeColumns.RemoveAt(i);
                    newTextBox.RemoveAt(i);
                    i--;
                }
            }
                
            SqlCommand insertComand = new SqlCommand("INSERT INTO [" + nameTable + "] (" + String.Join(", ", newColumns) + ")VALUES(@" + String.Join(", @", newColumns) + ")", sqlConnection);
            
            try
            {
                for (int i = 0; i < newColumns.Count; i++)
                        insertComand.Parameters.AddWithValue(newColumns[i], Convert.ChangeType(newTextBox[i].Text, newTypeColumns[i]));
                    
                await insertComand.ExecuteNonQueryAsync();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e) =>
            Close();

        private void toolStripMenuItemExit_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e) =>
            MessageBox.Show("Interface for working rith SQL database.\nMade by Abdullova Aigul for the university\n2021", "About the program", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
