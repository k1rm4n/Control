using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    class CreateDataGrid
    {
        private string nameTable;

        public string NameTable { get { return nameTable; } set { nameTable = value; } }

        int firstCount = 0;

        public CreateDataGrid(string nameTable)
        {
            this.nameTable = nameTable;
        }

        private Dictionary<string, string> namesTable = new Dictionary<string, string>()
        {
            {"2219", "group_A"},
            {"2118", "group_B"},
            {"2119", "group_C"},
            {"1220", "group_D"},
            {"3121", "group_E"}
        };

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
        
        ComboBox listGroupPenalties = new ComboBox()
        {
            Location = new Point(718, 60)
        };


        DataGridView dataGridView = new DataGridView()
        {
            Location = new Point(10, 10),
            Width = 690,
            Height = 400,
            BackgroundColor = Color.Gray,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            Font = new Font("Arial", 12),
        };

        DataGridView tableJoin = new DataGridView()
        {
            Location = new Point(10, 10),
            Width = 690,
            Height = 400,
            BackgroundColor = Color.Gray,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            Font = new Font("Arial", 12)
        };

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

            form.Controls.Remove(tableJoin);
            form.Controls.Remove(listGroupPenalties);
            form.Controls.Remove(listGroupEncouragement);
        }

        public void DeleteDGV(Form form)
        {
            btnAdd.Click -= BtnAdd_Click;
            btnUpdate.Click -= BtnUpdate_Click;
            btnDelete.Click -= BtnDelete_Click;
            btnEdit.Click -= BtnEdit_Click;
            form.Controls.Remove(dataGridView);
            form.Controls.Remove(btnAdd);
            form.Controls.Remove(btnUpdate);
            form.Controls.Remove(btnDelete);
            form.Controls.Remove(btnEdit);
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
            dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
            LoadData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        ComboBox listGroupEncouragement = new ComboBox()
        {
            Location = new Point(718, 60)
        };

        public void AddPresetOptionsPenalties(Form form)
        {
            listGroupEncouragement.Items.Clear();
            form.Controls.Add(tableJoin);
            form.Controls.Add(listGroupPenalties);
            listGroupPenalties.SelectedIndexChanged += ListGroupPenalties_SelectedIndexChanged;
            
            listGroupPenalties.Items.AddRange(new string[] { "2219", "2118", "2119", "1220", "3121" });
        }

        public void AddPresetOptionsEncouragement(Form form)
        {
            listGroupPenalties.Items.Clear();
            form.Controls.Add(tableJoin);
            form.Controls.Add(listGroupEncouragement);
            listGroupEncouragement.SelectedIndexChanged += ListGroupEncouragement_SelectedIndexChanged; ;

            listGroupEncouragement.Items.AddRange(new string[] { "2219", "2118", "2119", "1220", "3121" });
        }

        private void ListGroupPenalties_SelectedIndexChanged(object sender, EventArgs e)
        {
            string listState = listGroupPenalties.Items[listGroupPenalties.SelectedIndex].ToString();

            Form form = new Form();

            if (listState == "2219")
            {
                nameElList = "group_A";
            }
            else if (listState == "2118")
            {
                nameElList = "group_B";
            }
            else if (listState == "2119")
            {
                nameElList = "group_C";
            }
            else if (listState == "1220")
            {
                nameElList = "group_D";
            }
            else if (listState == "3121")
            {
                nameElList = "group_E";
            }
            LoadData_JOIN_Penalties();

        }

        private void ListGroupEncouragement_SelectedIndexChanged(object sender, EventArgs e)
        {
            string listState = listGroupEncouragement.Items[listGroupEncouragement.SelectedIndex].ToString();

            Form form = new Form();

            if (listState == "2219")
            {
                nameElList = "group_A";
            }
            else if (listState == "2118")
            {
                nameElList = "group_B";
            }
            else if (listState == "2119")
            {
                nameElList = "group_C";
            }
            else if (listState == "1220")
            {
                nameElList = "group_D";
            }
            else if (listState == "3121")
            {
                nameElList = "group_E";
            }
            LoadData_JOIN_Encouragement();
        }

        string nameElList { get; set; }

        public void DeletePresetOptionsPenalties(Form form)
        {
            form.Controls.Remove(tableJoin);
            form.Controls.Remove(listGroupPenalties);
        }

        public void DeletePresetOptionsEncouragement(Form form)
        {
            form.Controls.Remove(tableJoin);
            form.Controls.Remove(listGroupEncouragement);
        }

        public void LoadData_JOIN_Penalties()
        {
            string query = $"SELECT {nameElList}.IDPenalties, {nameElList}.name, {nameElList}.lastname, {nameElList}.patronymic, {nameElList}.num_group, penalties.warn, penalties.rebuke, penalties.delprem FROM {nameElList} JOIN penalties ON penalties.id = {nameElList}.IDPenalties";

            db.Connection();

            db.OpenCon();

            DataTable dataTable = new DataTable();

            db.Adapter(query).Fill(dataTable);

            tableJoin.DataSource = dataTable;

            string[] arrayNames = new string[] { "Индекс взыскания", "Имя", "Фамилия", "Отчество", "Группа", "Замечаний", "Выговоров", "Лишений премий" };

            for (int i = 0; i < tableJoin.Columns.Count; i++)
            {
                tableJoin.Columns[i].HeaderText = arrayNames[i];
            }

            db.CloseCon();
        }

        public void LoadData_JOIN_Encouragement()
        {
            string query = $"SELECT {nameElList}.IDEncouragement, {nameElList}.name, {nameElList}.lastname, {nameElList}.patronymic, {nameElList}.num_group, encouragement.diplomas, encouragement.premium FROM {nameElList} JOIN encouragement ON encouragement.id = {nameElList}.IDEncouragement";
            
            db.Connection();

            db.OpenCon();

            DataTable dataTable = new DataTable();

            db.Adapter(query).Fill(dataTable);

            tableJoin.DataSource = dataTable;

            string[] arrayNames = new string[] { "Индекс взыскания", "Имя", "Фамилия", "Отчество", "Группа", "Грамоты", "Премия" };

            for (int i = 0; i < tableJoin.Columns.Count; i++)
            {
                tableJoin.Columns[i].HeaderText = arrayNames[i];
            }

            db.CloseCon();
        }

        public void LoadData()
        {
            string numGroup;
            bool success = namesTable.TryGetValue(nameTable, out numGroup);
            if (!success) return;

            string query = $"SELECT * FROM {numGroup}";

            db.Connection();

            db.OpenCon();

            DataTable dataTable = new DataTable();

            db.Adapter(query).Fill(dataTable);

            dataGridView.DataSource = dataTable;

            string[] arrayNames = new string[] { "Id", "Имя", "Фамилия", "Отчество", "Группа",  "Индекс взыскания", "Индекс поощирения"};

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = arrayNames[i];
            }

            db.CloseCon();
            
        }

        public void InsertData()
        {
            string numGroup;
            bool success = namesTable.TryGetValue(nameTable, out numGroup);
            if (!success) return;

            int lastIndexRow = dataGridView.Rows.Count - 2;
            db.Connection();

            string query = $"INSERT {numGroup}(name, lastname, patronymic, num_group, IDPenalties, IDEncouragement) VALUES(@name, @lastname, @patronimyc, @numgroup, @IDPenalties, @IDEncouragement)";

            MySqlCommand cmd = new MySqlCommand(query, db.Connection());

            cmd.Parameters.AddWithValue("@name", dataGridView.Rows[lastIndexRow].Cells["name"].Value);
            cmd.Parameters.AddWithValue("@lastname", dataGridView.Rows[lastIndexRow].Cells["lastname"].Value);
            cmd.Parameters.AddWithValue("@patronimyc", dataGridView.Rows[lastIndexRow].Cells["patronymic"].Value);
            cmd.Parameters.AddWithValue("@numgroup", dataGridView.Rows[lastIndexRow].Cells["num_group"].Value);
            cmd.Parameters.AddWithValue("@IDPenalties", dataGridView.Rows[lastIndexRow].Cells["IDPenalties"].Value);
            cmd.Parameters.AddWithValue("@IDEncouragement", dataGridView.Rows[lastIndexRow].Cells["IDEncouragement"].Value);
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
            string numGroup;
            bool success = namesTable.TryGetValue(nameTable, out numGroup);
            if (!success) return;

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {numGroup}", db.Connection());

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

            /*if (firstCount == 1)
            {
                dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
            }*/
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string numGroup;
            bool success = namesTable.TryGetValue(nameTable, out numGroup);
            if (!success) return;

            string id = dataGridView[0, e.RowIndex].Value.ToString();
            string value = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            string valueColumn = "";

            valueColumn = nameColumns[e.ColumnIndex].ToString();

            string query = $"UPDATE {numGroup} SET {valueColumn} = '{value}' WHERE id = {id}";

            MySqlCommand cmd = new MySqlCommand(query, db.Connection());

            db.OpenCon();

            cmd.ExecuteNonQuery();

            db.CloseCon();

            LoadData();
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
                string numGroup;
                bool success = namesTable.TryGetValue(nameTable, out numGroup);
                if (!success) return;

                string id = dataGridView[0, e.RowIndex].Value.ToString();

                MessageBox.Show($"Вы удалили индекс: {id}");

                string query = $"DELETE FROM {numGroup} WHERE id = { id }";

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
