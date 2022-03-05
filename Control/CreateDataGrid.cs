using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    class CreateDataGrid
    {
        private string nameTable;
        public string NameTable { get { return nameTable; } set { nameTable = value; } }

        int secondCount = 0;
        int firstCount = 0;

        ArrayList nameColumns;

        DBconnect db = new DBconnect();

        Button btnAdd = new Button()
        {
            Location = new Point(740, 90),
            Text = "Add"
        };

        Button btnUpdate = new Button()
        {
            Location = new Point(740, 60),
            Text = "Update"
        };

        Button btnDelete = new Button()
        {
            Location = new Point(740, 120),
            Text = "Delete"
        };

        Button btnEdit = new Button()
        {
            Location = new Point(740, 150),
            Text = "Edit"
        };


        DataGridView dataGridView = new DataGridView()
        {
            Location = new Point(10, 10),
            Width = 690,
            Height = 400,
            BackgroundColor = Color.Azure,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            Font = new Font("Arial", 12),
        };

        public DataGridView GetDGV { get { return dataGridView; } set { dataGridView = value; } }
        public void CreateDataGridView(Form form)
        {
            form.Controls.Add(dataGridView);
            LoadData();
            form.Controls.Add(btnAdd);
            form.Controls.Add(btnUpdate);
            form.Controls.Add(btnDelete);
            form.Controls.Add(btnEdit);
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click; 
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView.CellClick -= DataGridView_CellClick;
            LoadData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        public void LoadData()
        {
            string query = $"SELECT * FROM {NameTable}";

            db.Connection();

            db.OpenCon();

            DataTable dataTable = new DataTable();

            db.Adapter(query).Fill(dataTable);

            dataGridView.DataSource = dataTable;

            string[] arrayNames = new string[] { "Id", "Имя", "Фамилия", "Отчество", "Группа" };

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = arrayNames[i];
            }

            db.CloseCon();
            
        }

        public void InsertData()
        {
            int lastIndexRow = dataGridView.Rows.Count - 2;
            db.Connection();

            string query = $"INSERT {NameTable}(name, lastname, patronymic, num_group) VALUES(@name, @lastname, @patronimyc, @numgroup)";

            MySqlCommand cmd = new MySqlCommand(query, db.Connection());

            cmd.Parameters.AddWithValue("@name", dataGridView.Rows[lastIndexRow].Cells["name"].Value);
            cmd.Parameters.AddWithValue("@lastname", dataGridView.Rows[lastIndexRow].Cells["lastname"].Value);
            cmd.Parameters.AddWithValue("@patronimyc", dataGridView.Rows[lastIndexRow].Cells["patronymic"].Value);
            cmd.Parameters.AddWithValue("@numgroup", dataGridView.Rows[lastIndexRow].Cells["num_group"].Value);

            try
            {
                db.OpenCon();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseCon();
            }
        }

        public void EditData()
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {NameTable}", db.Connection());

            db.OpenCon();

            MySqlDataReader reader = cmd.ExecuteReader();


            nameColumns = new ArrayList();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    nameColumns.Add(reader.GetName(i));
                }
            }

            db.CloseCon();
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            dataGridView.RowsAdded += DataGridView_RowsAdded;

        }

        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (firstCount < 1)
            {
                firstCount++;
            }

            if (firstCount == 1)
            {
                dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
            }
            /*else if (firstCount >= 1)
            {
                firstCount = 0;
            }*/
            /*secondCount = dataGridView.Rows.Count + firstCount;*/
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*try
            {
                if (secondCount > dataGridView.Rows.Count)
                {
                    dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
                    secondCount = dataGridView.Rows.Count + firstCount;
                    firstCount = 0;
                }
                else
                {*/
            string id = dataGridView[0, e.RowIndex].Value.ToString();
            string value = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            string valueColumn = "";

            valueColumn = nameColumns[e.ColumnIndex].ToString();

            string query = $"UPDATE {NameTable} SET {valueColumn} = '{value}' WHERE id = {id}";

            MySqlCommand cmd = new MySqlCommand(query, db.Connection());

            db.OpenCon();

            cmd.ExecuteNonQuery();

            db.CloseCon();

            LoadData();
                
            /*    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        }

        public void DeleteData()
        {
            dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
            dataGridView.CellClick += DataGridView_CellClick;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView[0, e.RowIndex].Value.ToString();

                MessageBox.Show($"Вы удалили индекс: {id}");

                string query = $"DELETE FROM {NameTable} WHERE id = { id }";

                MySqlCommand cmd = new MySqlCommand(query, db.Connection());

                db.OpenCon();

                cmd.ExecuteNonQuery();

                db.CloseCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
