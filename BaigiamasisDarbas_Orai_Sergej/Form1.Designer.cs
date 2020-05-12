namespace BaigiamasisDarbas_Orai_Sergej
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
            this.lbl_cityName = new System.Windows.Forms.Label();
            this.lbl_country = new System.Windows.Forms.Label();
            this.lbl_Temp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_Days = new System.Windows.Forms.Label();
            this.lbl_Conditions = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_daysTemp = new System.Windows.Forms.Label();
            this.lbl_WindSpeed = new System.Windows.Forms.Label();
            this.lbl_Forcast = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_cityName
            // 
            this.lbl_cityName.AutoSize = true;
            this.lbl_cityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cityName.ForeColor = System.Drawing.Color.Red;
            this.lbl_cityName.Location = new System.Drawing.Point(56, 46);
            this.lbl_cityName.Name = "lbl_cityName";
            this.lbl_cityName.Size = new System.Drawing.Size(375, 58);
            this.lbl_cityName.TabIndex = 0;
            this.lbl_cityName.Text = "Šiauliai, Lietuva";
            // 
            // lbl_country
            // 
            this.lbl_country.AutoSize = true;
            this.lbl_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_country.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_country.Location = new System.Drawing.Point(56, 104);
            this.lbl_country.Name = "lbl_country";
            this.lbl_country.Size = new System.Drawing.Size(57, 39);
            this.lbl_country.TabIndex = 1;
            this.lbl_country.Text = "LT";
            // 
            // lbl_Temp
            // 
            this.lbl_Temp.AutoSize = true;
            this.lbl_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Temp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Temp.Location = new System.Drawing.Point(211, 201);
            this.lbl_Temp.Name = "lbl_Temp";
            this.lbl_Temp.Size = new System.Drawing.Size(111, 104);
            this.lbl_Temp.TabIndex = 3;
            this.lbl_Temp.Text = "C";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BaigiamasisDarbas_Orai_Sergej.Properties.Resources.iconfinder_weather_16_26828351;
            this.pictureBox1.Location = new System.Drawing.Point(66, 177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BaigiamasisDarbas_Orai_Sergej.Properties.Resources.iconfinder_weather_16_26828351;
            this.pictureBox2.Location = new System.Drawing.Point(597, 117);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_Days
            // 
            this.lbl_Days.AutoSize = true;
            this.lbl_Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Days.ForeColor = System.Drawing.Color.White;
            this.lbl_Days.Location = new System.Drawing.Point(758, 127);
            this.lbl_Days.Name = "lbl_Days";
            this.lbl_Days.Size = new System.Drawing.Size(88, 31);
            this.lbl_Days.TabIndex = 5;
            this.lbl_Days.Text = "DAYS";
            // 
            // lbl_Conditions
            // 
            this.lbl_Conditions.AutoSize = true;
            this.lbl_Conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Conditions.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Conditions.Location = new System.Drawing.Point(731, 167);
            this.lbl_Conditions.Name = "lbl_Conditions";
            this.lbl_Conditions.Size = new System.Drawing.Size(143, 31);
            this.lbl_Conditions.TabIndex = 6;
            this.lbl_Conditions.Text = "Conditions";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.PaleGreen;
            this.lbl_description.Location = new System.Drawing.Point(733, 209);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(151, 31);
            this.lbl_description.TabIndex = 7;
            this.lbl_description.Text = "Description";
            // 
            // lbl_daysTemp
            // 
            this.lbl_daysTemp.AutoSize = true;
            this.lbl_daysTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daysTemp.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_daysTemp.Location = new System.Drawing.Point(933, 185);
            this.lbl_daysTemp.Name = "lbl_daysTemp";
            this.lbl_daysTemp.Size = new System.Drawing.Size(44, 31);
            this.lbl_daysTemp.TabIndex = 10;
            this.lbl_daysTemp.Text = "26";
            // 
            // lbl_WindSpeed
            // 
            this.lbl_WindSpeed.AutoSize = true;
            this.lbl_WindSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WindSpeed.ForeColor = System.Drawing.Color.Gray;
            this.lbl_WindSpeed.Location = new System.Drawing.Point(909, 127);
            this.lbl_WindSpeed.Name = "lbl_WindSpeed";
            this.lbl_WindSpeed.Size = new System.Drawing.Size(103, 31);
            this.lbl_WindSpeed.TabIndex = 8;
            this.lbl_WindSpeed.Text = "25km/h";
            // 
            // lbl_Forcast
            // 
            this.lbl_Forcast.AutoSize = true;
            this.lbl_Forcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Forcast.ForeColor = System.Drawing.Color.Red;
            this.lbl_Forcast.Location = new System.Drawing.Point(710, 46);
            this.lbl_Forcast.Name = "lbl_Forcast";
            this.lbl_Forcast.Size = new System.Drawing.Size(193, 58);
            this.lbl_Forcast.TabIndex = 11;
            this.lbl_Forcast.Text = "Forcast";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 667);
            this.Controls.Add(this.lbl_Forcast);
            this.Controls.Add(this.lbl_daysTemp);
            this.Controls.Add(this.lbl_WindSpeed);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_Conditions);
            this.Controls.Add(this.lbl_Days);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_Temp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_country);
            this.Controls.Add(this.lbl_cityName);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cityName;
        private System.Windows.Forms.Label lbl_country;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Temp;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_Days;
        private System.Windows.Forms.Label lbl_Conditions;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_daysTemp;
        private System.Windows.Forms.Label lbl_WindSpeed;
        private System.Windows.Forms.Label lbl_Forcast;
    }
}

