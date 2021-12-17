﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinFormsApp2
{
    public partial class Update : Form
    {
        private SqlConnection sqlConnection;
        private string id;
        private List<string> columns;
        private List<Type> typeColumns;
        private TextBox[] textBox;
        private string nameTable;
        public Update(SqlConnection sqlConnection, string id, List<string> columns, List<Type> typeColumns, string nameTable)
        {
            InitializeComponent();
            this.sqlConnection = sqlConnection;
            this.id = id;
            this.columns = columns;
            this.typeColumns = typeColumns;
            this.nameTable = nameTable;

            int value = 20;
            int i = 0;
            Label[] label = new Label[columns.Count - 1];
            textBox = new TextBox[columns.Count - 1];
            foreach (var column in columns)
            {
                if (column != columns[0])
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

        private async void Update_Load(object sender, EventArgs e)
        {
            List<string> newColumns = new List<string>(columns);
            newColumns.RemoveAt(0);

            SqlDataReader? reader = null;
            SqlCommand getInfoComand = new SqlCommand("SELECT [" + String.Join("], [", newColumns) + "] FROM [" + nameTable + "] WHERE [" + columns[0] + "]=@Id", sqlConnection);

            try
            {
                if (typeColumns[0].Name == "Guid")
                    getInfoComand.Parameters.AddWithValue(columns[0], Guid.Parse(id));
                else
                    getInfoComand.Parameters.AddWithValue(columns[0], Convert.ChangeType(id, typeColumns[0]));
                reader = await getInfoComand.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    for (int i = 0; i < newColumns.Count; i++)
                        textBox[i].Text = Convert.ToString(reader[newColumns[i]]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            var newColumns = new List<string>(columns);
            var newTypeColumns = new List<Type>(typeColumns);
            newColumns.RemoveAt(0);
            newTypeColumns.RemoveAt(0);

            var setArray = new List<string>();
            foreach (var column in newColumns)
                setArray.Add("[" + column + "]=@" + column);
            
            SqlCommand updateComand = new SqlCommand("UPDATE [" + nameTable + "] SET " + String.Join(", ", setArray) + " WHERE [" + columns[0] + "]=@Id", sqlConnection);

            try
            {
                if (typeColumns[0].Name == "Guid")
                    updateComand.Parameters.AddWithValue(columns[0], Guid.Parse(id));
                else
                    updateComand.Parameters.AddWithValue(columns[0], Convert.ChangeType(id, typeColumns[0]));
                for (int i = 0; i < newColumns.Count; i++)
                    updateComand.Parameters.AddWithValue(newColumns[i], Convert.ChangeType(textBox[i].Text, newTypeColumns[i]));
                await updateComand.ExecuteNonQueryAsync();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
