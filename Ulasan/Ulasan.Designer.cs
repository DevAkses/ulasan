namespace Ulasan
{
    partial class Ulasan
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
            textBox1 = new TextBox();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            labelUsername1 = new Label();
            labelKomentar1 = new Label();
            labelKomentar2 = new Label();
            labelUsername2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(391, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(598, 102);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(391, 77);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(31, 19);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(428, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(31, 19);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(465, 77);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(31, 19);
            radioButton3.TabIndex = 4;
            radioButton3.TabStop = true;
            radioButton3.Text = "3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(502, 77);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(31, 19);
            radioButton4.TabIndex = 5;
            radioButton4.TabStop = true;
            radioButton4.Text = "4";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(538, 77);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(31, 19);
            radioButton5.TabIndex = 6;
            radioButton5.TabStop = true;
            radioButton5.Text = "5";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // labelUsername1
            // 
            labelUsername1.AutoSize = true;
            labelUsername1.Location = new Point(384, 176);
            labelUsername1.Name = "labelUsername1";
            labelUsername1.Size = new Size(91, 15);
            labelUsername1.TabIndex = 7;
            labelUsername1.Text = "labelUsername1";
            labelUsername1.Visible = false;
            // 
            // labelKomentar1
            // 
            labelKomentar1.AutoSize = true;
            labelKomentar1.Location = new Point(384, 205);
            labelKomentar1.Name = "labelKomentar1";
            labelKomentar1.Size = new Size(90, 15);
            labelKomentar1.TabIndex = 8;
            labelKomentar1.Text = "labelKomentar1";
            labelKomentar1.Visible = false;
            // 
            // labelKomentar2
            // 
            labelKomentar2.AutoSize = true;
            labelKomentar2.Location = new Point(384, 282);
            labelKomentar2.Name = "labelKomentar2";
            labelKomentar2.Size = new Size(90, 15);
            labelKomentar2.TabIndex = 10;
            labelKomentar2.Text = "labelKomentar2";
            labelKomentar2.Visible = false;
            // 
            // labelUsername2
            // 
            labelUsername2.AutoSize = true;
            labelUsername2.Location = new Point(384, 253);
            labelUsername2.Name = "labelUsername2";
            labelUsername2.Size = new Size(91, 15);
            labelUsername2.TabIndex = 9;
            labelUsername2.Text = "labelUsername2";
            labelUsername2.Visible = false;
            // 
            // Ulasan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelKomentar2);
            Controls.Add(labelUsername2);
            Controls.Add(labelKomentar1);
            Controls.Add(labelUsername1);
            Controls.Add(radioButton5);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Ulasan";
            Text = "Ulasan";
            Load += Ulasan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private Label labelUsername1;
        private Label labelKomentar1;
        private Label labelKomentar2;
        private Label labelUsername2;
    }
}