namespace Dealership_Program
{
    partial class Car_Details
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
            this.tb_MSRP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Year = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Trim = new System.Windows.Forms.TextBox();
            this.tb_Model = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Maker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_CarID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add_car_save = new System.Windows.Forms.Button();
            this.btn_add_car_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_color = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_MSRP
            // 
            this.tb_MSRP.Location = new System.Drawing.Point(47, 169);
            this.tb_MSRP.Name = "tb_MSRP";
            this.tb_MSRP.Size = new System.Drawing.Size(240, 20);
            this.tb_MSRP.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "MSRP";
            // 
            // tb_Year
            // 
            this.tb_Year.Location = new System.Drawing.Point(47, 38);
            this.tb_Year.Name = "tb_Year";
            this.tb_Year.Size = new System.Drawing.Size(240, 20);
            this.tb_Year.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Trim";
            // 
            // tb_Trim
            // 
            this.tb_Trim.Location = new System.Drawing.Point(47, 116);
            this.tb_Trim.Name = "tb_Trim";
            this.tb_Trim.Size = new System.Drawing.Size(240, 20);
            this.tb_Trim.TabIndex = 18;
            // 
            // tb_Model
            // 
            this.tb_Model.Location = new System.Drawing.Point(47, 90);
            this.tb_Model.Name = "tb_Model";
            this.tb_Model.Size = new System.Drawing.Size(240, 20);
            this.tb_Model.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Model";
            // 
            // tb_Maker
            // 
            this.tb_Maker.Location = new System.Drawing.Point(47, 64);
            this.tb_Maker.Name = "tb_Maker";
            this.tb_Maker.Size = new System.Drawing.Size(240, 20);
            this.tb_Maker.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Maker";
            // 
            // tb_CarID
            // 
            this.tb_CarID.Location = new System.Drawing.Point(47, 12);
            this.tb_CarID.Name = "tb_CarID";
            this.tb_CarID.Size = new System.Drawing.Size(240, 20);
            this.tb_CarID.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Car ID";
            // 
            // btn_add_car_save
            // 
            this.btn_add_car_save.Location = new System.Drawing.Point(12, 196);
            this.btn_add_car_save.Name = "btn_add_car_save";
            this.btn_add_car_save.Size = new System.Drawing.Size(75, 23);
            this.btn_add_car_save.TabIndex = 21;
            this.btn_add_car_save.Text = "Save";
            this.btn_add_car_save.UseVisualStyleBackColor = true;
            this.btn_add_car_save.Click += new System.EventHandler(this.btn_add_car_save_Click);
            // 
            // btn_add_car_clear
            // 
            this.btn_add_car_clear.Location = new System.Drawing.Point(93, 196);
            this.btn_add_car_clear.Name = "btn_add_car_clear";
            this.btn_add_car_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_add_car_clear.TabIndex = 22;
            this.btn_add_car_clear.Text = "Clear";
            this.btn_add_car_clear.UseVisualStyleBackColor = true;
            this.btn_add_car_clear.Click += new System.EventHandler(this.btn_add_car_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Color";
            // 
            // tb_color
            // 
            this.tb_color.Location = new System.Drawing.Point(47, 143);
            this.tb_color.Name = "tb_color";
            this.tb_color.Size = new System.Drawing.Size(240, 20);
            this.tb_color.TabIndex = 19;
            // 
            // Car_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 271);
            this.Controls.Add(this.tb_color);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add_car_clear);
            this.Controls.Add(this.btn_add_car_save);
            this.Controls.Add(this.tb_MSRP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_Year);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Trim);
            this.Controls.Add(this.tb_Model);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_Maker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_CarID);
            this.Controls.Add(this.label3);
            this.Name = "Car_Details";
            this.Text = "Car Details";
            this.Load += new System.EventHandler(this.Car_Details_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_MSRP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Year;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Trim;
        private System.Windows.Forms.TextBox tb_Model;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Maker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_CarID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_add_car_save;
        private System.Windows.Forms.Button btn_add_car_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_color;
    }
}