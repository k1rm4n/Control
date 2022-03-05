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
        

        private Dictionary<string, CreateDataGrid> dictionaryData = new Dictionary<string, CreateDataGrid>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboBoxState = ComboBox.Items[ComboBox.SelectedIndex].ToString();
            
            if (comboBoxState == "2219")
            {
                CreateDataGrid createData;
                bool sucess = dictionaryData.TryGetValue("2219",out createData);
                if (!sucess)
                {
                    createData = new CreateDataGrid();
                    createData.NameTable = "group_A";
                    createData.CreateDataGridView(this);
                    
                    dictionaryData.Add("2219", createData);
                }

                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
