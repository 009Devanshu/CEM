
namespace CEM
{
    partial class OtherDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.textBoxAttendance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioyes = new System.Windows.Forms.RadioButton();
            this.radiono = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Attendace";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April ",
            "May ",
            "June ",
            "July ",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonth.Location = new System.Drawing.Point(293, 86);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(154, 25);
            this.comboBoxMonth.TabIndex = 3;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.comboBoxYear.Location = new System.Drawing.Point(293, 150);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(154, 25);
            this.comboBoxYear.TabIndex = 4;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // textBoxAttendance
            // 
            this.textBoxAttendance.Location = new System.Drawing.Point(293, 214);
            this.textBoxAttendance.Name = "textBoxAttendance";
            this.textBoxAttendance.Size = new System.Drawing.Size(129, 25);
            this.textBoxAttendance.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 38);
            this.label4.TabIndex = 6;
            this.label4.Text = "TDS of the basis of\r\nattendance\r\n";
            // 
            // radioyes
            // 
            this.radioyes.AutoSize = true;
            this.radioyes.Location = new System.Drawing.Point(293, 298);
            this.radioyes.Name = "radioyes";
            this.radioyes.Size = new System.Drawing.Size(50, 23);
            this.radioyes.TabIndex = 7;
            this.radioyes.TabStop = true;
            this.radioyes.Text = "Yes";
            this.radioyes.UseVisualStyleBackColor = true;
            // 
            // radiono
            // 
            this.radiono.AutoSize = true;
            this.radiono.Location = new System.Drawing.Point(410, 295);
            this.radiono.Name = "radiono";
            this.radiono.Size = new System.Drawing.Size(48, 23);
            this.radiono.TabIndex = 8;
            this.radiono.TabStop = true;
            this.radiono.Text = "No";
            this.radiono.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "SUBMIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtherDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 517);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radiono);
            this.Controls.Add(this.radioyes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAttendance);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OtherDetails";
            this.Text = "OtherDetails";
            this.Load += new System.EventHandler(this.OtherDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.TextBox textBoxAttendance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioyes;
        private System.Windows.Forms.RadioButton radiono;
        private System.Windows.Forms.Button button1;
    }
}