namespace Control
{
    partial class FormAutoReg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_Auto = new System.Windows.Forms.Button();
            this.Button_Reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Auto
            // 
            this.Button_Auto.BackColor = System.Drawing.SystemColors.Highlight;
            this.Button_Auto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Auto.ForeColor = System.Drawing.Color.White;
            this.Button_Auto.Location = new System.Drawing.Point(12, 20);
            this.Button_Auto.Name = "Button_Auto";
            this.Button_Auto.Size = new System.Drawing.Size(134, 39);
            this.Button_Auto.TabIndex = 0;
            this.Button_Auto.Text = "Авторизация";
            this.Button_Auto.UseVisualStyleBackColor = false;
            this.Button_Auto.Click += new System.EventHandler(this.Button_Auto_Click);
            // 
            // Button_Reg
            // 
            this.Button_Reg.BackColor = System.Drawing.SystemColors.Highlight;
            this.Button_Reg.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button_Reg.ForeColor = System.Drawing.Color.White;
            this.Button_Reg.Location = new System.Drawing.Point(152, 20);
            this.Button_Reg.Name = "Button_Reg";
            this.Button_Reg.Size = new System.Drawing.Size(135, 39);
            this.Button_Reg.TabIndex = 1;
            this.Button_Reg.Text = "Регистрация";
            this.Button_Reg.UseVisualStyleBackColor = false;
            this.Button_Reg.Click += new System.EventHandler(this.Button_Reg_Click);
            // 
            // FormAutoReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 77);
            this.Controls.Add(this.Button_Reg);
            this.Controls.Add(this.Button_Auto);
            this.Name = "FormAutoReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAutoReg";
            this.Load += new System.EventHandler(this.FormAutoReg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Auto;
        private System.Windows.Forms.Button Button_Reg;
    }
}