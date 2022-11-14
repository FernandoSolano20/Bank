namespace Bank
{
    partial class Form2
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
            this.country = new MetroFramework.Controls.MetroTextBox();
            this.create = new MetroFramework.Controls.MetroButton();
            this.get = new MetroFramework.Controls.MetroButton();
            this.delete = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.value = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // country
            // 
            // 
            // 
            // 
            this.country.CustomButton.Image = null;
            this.country.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.country.CustomButton.Name = "";
            this.country.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.country.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.country.CustomButton.TabIndex = 1;
            this.country.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.country.CustomButton.UseSelectable = true;
            this.country.CustomButton.Visible = false;
            this.country.Lines = new string[0];
            this.country.Location = new System.Drawing.Point(328, 164);
            this.country.MaxLength = 32767;
            this.country.Name = "country";
            this.country.PasswordChar = '\0';
            this.country.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.country.SelectedText = "";
            this.country.SelectionLength = 0;
            this.country.SelectionStart = 0;
            this.country.ShortcutsEnabled = true;
            this.country.Size = new System.Drawing.Size(75, 23);
            this.country.TabIndex = 0;
            this.country.UseSelectable = true;
            this.country.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.country.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(144, 223);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 1;
            this.create.Text = "Crear";
            this.create.UseSelectable = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // get
            // 
            this.get.Location = new System.Drawing.Point(328, 222);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(75, 23);
            this.get.TabIndex = 2;
            this.get.Text = "Consultar";
            this.get.UseSelectable = true;
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(496, 223);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "Borrar";
            this.delete.UseSelectable = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(347, 109);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(32, 20);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Pais";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Location = new System.Drawing.Point(316, 314);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(0, 0);
            this.value.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.value);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.get);
            this.Controls.Add(this.create);
            this.Controls.Add(this.country);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox country;
        private MetroFramework.Controls.MetroButton create;
        private MetroFramework.Controls.MetroButton get;
        private MetroFramework.Controls.MetroButton delete;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel value;
    }
}