namespace Bank
{
    partial class Form1
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dateTime = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.originCountry = new MetroFramework.Controls.MetroTextBox();
            this.exchangeRateValue = new MetroFramework.Drawing.Html.HtmlLabel();
            this.createBtn = new MetroFramework.Controls.MetroButton();
            this.getBtn = new MetroFramework.Controls.MetroButton();
            this.updateBtn = new MetroFramework.Controls.MetroButton();
            this.deleteBtn = new MetroFramework.Controls.MetroButton();
            this.destinationCountry = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.inputExchange = new MetroFramework.Controls.MetroTextBox();
            this.convertion = new MetroFramework.Controls.MetroTextBox();
            this.btnConvertion = new MetroFramework.Controls.MetroButton();
            this.countryCrud = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(300, 28);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(105, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Tipo de cambio";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(165, 114);
            this.dateTime.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(200, 30);
            this.dateTime.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(165, 76);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(29, 20);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Día";
            // 
            // originCountry
            // 
            // 
            // 
            // 
            this.originCountry.CustomButton.Image = null;
            this.originCountry.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.originCountry.CustomButton.Name = "";
            this.originCountry.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.originCountry.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.originCountry.CustomButton.TabIndex = 1;
            this.originCountry.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.originCountry.CustomButton.UseSelectable = true;
            this.originCountry.CustomButton.Visible = false;
            this.originCountry.Lines = new string[0];
            this.originCountry.Location = new System.Drawing.Point(17, 121);
            this.originCountry.MaxLength = 32767;
            this.originCountry.Name = "originCountry";
            this.originCountry.PasswordChar = '\0';
            this.originCountry.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.originCountry.SelectedText = "";
            this.originCountry.SelectionLength = 0;
            this.originCountry.SelectionStart = 0;
            this.originCountry.ShortcutsEnabled = true;
            this.originCountry.Size = new System.Drawing.Size(107, 23);
            this.originCountry.TabIndex = 3;
            this.originCountry.UseSelectable = true;
            this.originCountry.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.originCountry.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // exchangeRateValue
            // 
            this.exchangeRateValue.AutoScroll = true;
            this.exchangeRateValue.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.exchangeRateValue.AutoSize = false;
            this.exchangeRateValue.BackColor = System.Drawing.SystemColors.Window;
            this.exchangeRateValue.Location = new System.Drawing.Point(300, 337);
            this.exchangeRateValue.Name = "exchangeRateValue";
            this.exchangeRateValue.Size = new System.Drawing.Size(154, 43);
            this.exchangeRateValue.TabIndex = 4;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(49, 229);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 5;
            this.createBtn.Text = "Crear";
            this.createBtn.UseSelectable = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // getBtn
            // 
            this.getBtn.Location = new System.Drawing.Point(220, 229);
            this.getBtn.Name = "getBtn";
            this.getBtn.Size = new System.Drawing.Size(119, 23);
            this.getBtn.TabIndex = 6;
            this.getBtn.Text = "Consultar";
            this.getBtn.UseSelectable = true;
            this.getBtn.Click += new System.EventHandler(this.getBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(425, 229);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(134, 23);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Actualizar";
            this.updateBtn.UseSelectable = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(623, 229);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.Text = "Borrar";
            this.deleteBtn.UseSelectable = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // destinationCountry
            // 
            // 
            // 
            // 
            this.destinationCountry.CustomButton.Image = null;
            this.destinationCountry.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.destinationCountry.CustomButton.Name = "";
            this.destinationCountry.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.destinationCountry.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.destinationCountry.CustomButton.TabIndex = 1;
            this.destinationCountry.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.destinationCountry.CustomButton.UseSelectable = true;
            this.destinationCountry.CustomButton.Visible = false;
            this.destinationCountry.Lines = new string[0];
            this.destinationCountry.Location = new System.Drawing.Point(404, 121);
            this.destinationCountry.MaxLength = 32767;
            this.destinationCountry.Name = "destinationCountry";
            this.destinationCountry.PasswordChar = '\0';
            this.destinationCountry.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.destinationCountry.SelectedText = "";
            this.destinationCountry.SelectionLength = 0;
            this.destinationCountry.SelectionStart = 0;
            this.destinationCountry.ShortcutsEnabled = true;
            this.destinationCountry.Size = new System.Drawing.Size(144, 23);
            this.destinationCountry.TabIndex = 9;
            this.destinationCountry.UseSelectable = true;
            this.destinationCountry.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.destinationCountry.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(17, 76);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(76, 20);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "País origen";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(404, 76);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(81, 20);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "País destino";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(602, 76);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(39, 20);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Valor";
            // 
            // inputExchange
            // 
            // 
            // 
            // 
            this.inputExchange.CustomButton.Image = null;
            this.inputExchange.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.inputExchange.CustomButton.Name = "";
            this.inputExchange.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputExchange.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputExchange.CustomButton.TabIndex = 1;
            this.inputExchange.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputExchange.CustomButton.UseSelectable = true;
            this.inputExchange.CustomButton.Visible = false;
            this.inputExchange.Lines = new string[0];
            this.inputExchange.Location = new System.Drawing.Point(602, 120);
            this.inputExchange.MaxLength = 32767;
            this.inputExchange.Name = "inputExchange";
            this.inputExchange.PasswordChar = '\0';
            this.inputExchange.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputExchange.SelectedText = "";
            this.inputExchange.SelectionLength = 0;
            this.inputExchange.SelectionStart = 0;
            this.inputExchange.ShortcutsEnabled = true;
            this.inputExchange.Size = new System.Drawing.Size(131, 23);
            this.inputExchange.TabIndex = 13;
            this.inputExchange.UseSelectable = true;
            this.inputExchange.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputExchange.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // convertion
            // 
            // 
            // 
            // 
            this.convertion.CustomButton.Image = null;
            this.convertion.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.convertion.CustomButton.Name = "";
            this.convertion.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.convertion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.convertion.CustomButton.TabIndex = 1;
            this.convertion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.convertion.CustomButton.UseSelectable = true;
            this.convertion.CustomButton.Visible = false;
            this.convertion.Lines = new string[0];
            this.convertion.Location = new System.Drawing.Point(49, 347);
            this.convertion.MaxLength = 32767;
            this.convertion.Name = "convertion";
            this.convertion.PasswordChar = '\0';
            this.convertion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.convertion.SelectedText = "";
            this.convertion.SelectionLength = 0;
            this.convertion.SelectionStart = 0;
            this.convertion.ShortcutsEnabled = true;
            this.convertion.Size = new System.Drawing.Size(75, 23);
            this.convertion.TabIndex = 14;
            this.convertion.UseSelectable = true;
            this.convertion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.convertion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConvertion
            // 
            this.btnConvertion.Location = new System.Drawing.Point(58, 396);
            this.btnConvertion.Name = "btnConvertion";
            this.btnConvertion.Size = new System.Drawing.Size(191, 23);
            this.btnConvertion.TabIndex = 15;
            this.btnConvertion.Text = "conversion";
            this.btnConvertion.UseSelectable = true;
            this.btnConvertion.Click += new System.EventHandler(this.btnConvertion_Click);
            // 
            // countryCrud
            // 
            this.countryCrud.Location = new System.Drawing.Point(521, 386);
            this.countryCrud.Name = "countryCrud";
            this.countryCrud.Size = new System.Drawing.Size(212, 23);
            this.countryCrud.TabIndex = 16;
            this.countryCrud.Text = "Mantenimiento pais";
            this.countryCrud.UseSelectable = true;
            this.countryCrud.Click += new System.EventHandler(this.countryCrud_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countryCrud);
            this.Controls.Add(this.btnConvertion);
            this.Controls.Add(this.convertion);
            this.Controls.Add(this.inputExchange);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.destinationCountry);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.getBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.exchangeRateValue);
            this.Controls.Add(this.originCountry);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dateTime;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox originCountry;
        private MetroFramework.Drawing.Html.HtmlLabel exchangeRateValue;
        private MetroFramework.Controls.MetroButton createBtn;
        private MetroFramework.Controls.MetroButton getBtn;
        private MetroFramework.Controls.MetroButton updateBtn;
        private MetroFramework.Controls.MetroButton deleteBtn;
        private MetroFramework.Controls.MetroTextBox destinationCountry;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox inputExchange;
        private MetroFramework.Controls.MetroTextBox convertion;
        private MetroFramework.Controls.MetroButton btnConvertion;
        private MetroFramework.Controls.MetroButton countryCrud;
    }
}

