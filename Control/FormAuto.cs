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
    public partial class FormAuto : Form
    {
        DBconnect db = new DBconnect();

        public FormAuto()
        {
            InitializeComponent();
            passTB.PasswordChar = '*';
        }

        private void Button_CheckData_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE login=@login and pass=@pass", db.Connection());
            db.OpenCon();
            cmd.Parameters.AddWithValue("@login", loginTB.Text);
            cmd.Parameters.AddWithValue("@pass", passTB.Text);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows == true)
            {
                Form1 form = new Form1();
                form.Show();
                Hide();
                MessageBox.Show("Авторизация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Логин или пароль не вереный!\nПроверить корректность введенных параметров!");
            }

            db.CloseCon();
        }

        private void FormAuto_Load(object sender, EventArgs e)
        {

        }
    }
}
