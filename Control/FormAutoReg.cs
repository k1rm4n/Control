using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public partial class FormAutoReg : Form
    {
        public FormAutoReg()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, EventArgs e)
        {
            FormReg reg = new FormReg();
            reg.Show();
            Hide();
        }

        private void Button_Auto_Click(object sender, EventArgs e)
        {
            FormAuto auto = new FormAuto();
            auto.Show();
            Hide();
        }

        private void FormAutoReg_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            form.Hide();
        }
    }
}
