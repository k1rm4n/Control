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
        private CreateDataGrid createData;

       
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboBoxState = ComboBox.Items[ComboBox.SelectedIndex].ToString();

            if (createData == null)
            {
                createData = new CreateDataGrid(comboBoxState);
                createData.CreateDataGridView(this);
                createData.DeletePresetOptionsPenalties(this);
                createData.DeletePresetOptionsEncouragement(this);
            }
            else
            {
                createData.NameTable = comboBoxState;
                createData.DeleteDGV(this);
                createData.CreateDataGridView(this);
            }

            if (comboBoxState == "Взыскания")
            {
                createData.AddPresetOptionsPenalties(this);
                createData.DeleteDGV(this);
            }
            else if (comboBoxState == "Поощирения")
            {
                createData.AddPresetOptionsEncouragement(this);
                createData.DeleteDGV(this);
            }
            else
            {
                createData.DeletePresetOptionsPenalties(this);
                createData.DeletePresetOptionsEncouragement(this);
            }
        }
    }
}
