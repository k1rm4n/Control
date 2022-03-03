using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Control
{
    public partial class Form1 : Form
    {
        CreateDataGrid createData = new CreateDataGrid();
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboBoxState = ComboBox.Items[ComboBox.SelectedIndex].ToString();
            
            if (comboBoxState == "2219")
            {
                createData.NameTable = "group_A";
                createData.CreateDataGridView(this);
            }
            else if (comboBoxState == "2118")
            {
                createData.NameTable = "group_B";
                createData.CreateDataGridView(this);
            }
            else if (comboBoxState == "2119")
            {
                createData.NameTable = "group_C";
                createData.CreateDataGridView(this);
            }
            else if (comboBoxState == "1220")
            {
                createData.NameTable = "group_D";
                createData.CreateDataGridView(this);
            }
            else if (comboBoxState == "3121")
            {
                createData.NameTable = "group_E";
                createData.CreateDataGridView(this);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
