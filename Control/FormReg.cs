using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Control
{
    public partial class FormReg : Form
    {
        DBconnect db = new DBconnect();

        public FormReg()
        {
            InitializeComponent();
            passTB.PasswordChar = '*';
        }

        private void InsertDataUser_Click(object sender, EventArgs e)
        {
            db.Connection();
            
            string query = $"INSERT users(login, pass) VALUES('{loginTB.Text}', '{passTB.Text}')";

            MySqlCommand cmd = new MySqlCommand(query, db.Connection());
            db.OpenCon();
            cmd.ExecuteNonQuery();
            db.CloseCon();

            loginTB.Text = "";
            passTB.Text = "";

            FormAuto auto = new FormAuto();
            Hide();
            auto.Show();
        }

        private void loginTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void passTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
