namespace PrimesCalculator
{
    partial class PrimesCalculatorForm
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
            this.first_txtBox = new System.Windows.Forms.TextBox();
            this.last_textBox = new System.Windows.Forms.TextBox();
            this.calculate_button = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.ListBox();
            this.enter_rang_label = new System.Windows.Forms.Label();
            this.first_label = new System.Windows.Forms.Label();
            this.last_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.outputFile_label = new System.Windows.Forms.Label();
            this.outputFile_textBox = new System.Windows.Forms.TextBox();
            this.primesCount_label = new System.Windows.Forms.Label();
            this.numbers_label = new System.Windows.Forms.Label();
            this.primesCounter_textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // first_txtBox
            // 
            this.first_txtBox.Location = new System.Drawing.Point(117, 76);
            this.first_txtBox.Name = "first_txtBox";
            this.first_txtBox.Size = new System.Drawing.Size(342, 38);
            this.first_txtBox.TabIndex = 0;
            this.first_txtBox.TextChanged += new System.EventHandler(this.first_txtBox_TextChanged);
            // 
            // last_textBox
            // 
            this.last_textBox.Location = new System.Drawing.Point(117, 150);
            this.last_textBox.Name = "last_textBox";
            this.last_textBox.Size = new System.Drawing.Size(342, 38);
            this.last_textBox.TabIndex = 1;
            this.last_textBox.TextChanged += new System.EventHandler(this.last_textBox_TextChanged);
            // 
            // calculate_button
            // 
            this.calculate_button.Location = new System.Drawing.Point(12, 213);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(214, 48);
            this.calculate_button.TabIndex = 2;
            this.calculate_button.Text = "Calculate";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // result
            // 
            this.result.FormattingEnabled = true;
            this.result.ItemHeight = 31;
            this.result.Location = new System.Drawing.Point(18, 288);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(447, 500);
            this.result.TabIndex = 3;
            this.result.SelectedIndexChanged += new System.EventHandler(this.result_SelectedIndexChanged);
            // 
            // enter_rang_label
            // 
            this.enter_rang_label.AutoSize = true;
            this.enter_rang_label.Location = new System.Drawing.Point(12, 25);
            this.enter_rang_label.Name = "enter_rang_label";
            this.enter_rang_label.Size = new System.Drawing.Size(447, 32);
            this.enter_rang_label.TabIndex = 4;
            this.enter_rang_label.Text = "Enter range for primes calculation:";
            // 
            // first_label
            // 
            this.first_label.AutoSize = true;
            this.first_label.Location = new System.Drawing.Point(18, 82);
            this.first_label.Name = "first_label";
            this.first_label.Size = new System.Drawing.Size(78, 32);
            this.first_label.TabIndex = 5;
            this.first_label.Text = "First:";
            // 
            // last_label
            // 
            this.last_label.AutoSize = true;
            this.last_label.Location = new System.Drawing.Point(19, 156);
            this.last_label.Name = "last_label";
            this.last_label.Size = new System.Drawing.Size(77, 32);
            this.last_label.TabIndex = 6;
            this.last_label.Text = "Last:";
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(278, 213);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(181, 48);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // outputFile_label
            // 
            this.outputFile_label.AutoSize = true;
            this.outputFile_label.Location = new System.Drawing.Point(6, 905);
            this.outputFile_label.Name = "outputFile_label";
            this.outputFile_label.Size = new System.Drawing.Size(154, 32);
            this.outputFile_label.TabIndex = 8;
            this.outputFile_label.Text = "Output file:";
            // 
            // outputFile_textBox
            // 
            this.outputFile_textBox.Location = new System.Drawing.Point(188, 899);
            this.outputFile_textBox.Name = "outputFile_textBox";
            this.outputFile_textBox.Size = new System.Drawing.Size(557, 38);
            this.outputFile_textBox.TabIndex = 9;
            // 
            // primesCount_label
            // 
            this.primesCount_label.AutoSize = true;
            this.primesCount_label.Location = new System.Drawing.Point(18, 824);
            this.primesCount_label.Name = "primesCount_label";
            this.primesCount_label.Size = new System.Drawing.Size(223, 32);
            this.primesCount_label.TabIndex = 10;
            this.primesCount_label.Text = "Was calculated :";
            // 
            // numbers_label
            // 
            this.numbers_label.AutoSize = true;
            this.numbers_label.Location = new System.Drawing.Point(473, 824);
            this.numbers_label.Name = "numbers_label";
            this.numbers_label.Size = new System.Drawing.Size(203, 32);
            this.numbers_label.TabIndex = 11;
            this.numbers_label.Text = "prime numbers";
            // 
            // primesCounter_textBox1
            // 
            this.primesCounter_textBox1.Location = new System.Drawing.Point(248, 817);
            this.primesCounter_textBox1.Name = "primesCounter_textBox1";
            this.primesCounter_textBox1.Size = new System.Drawing.Size(219, 38);
            this.primesCounter_textBox1.TabIndex = 12;
            // 
            // PrimesCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 1027);
            this.Controls.Add(this.primesCounter_textBox1);
            this.Controls.Add(this.numbers_label);
            this.Controls.Add(this.primesCount_label);
            this.Controls.Add(this.outputFile_textBox);
            this.Controls.Add(this.outputFile_label);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.last_label);
            this.Controls.Add(this.first_label);
            this.Controls.Add(this.enter_rang_label);
            this.Controls.Add(this.result);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.last_textBox);
            this.Controls.Add(this.first_txtBox);
            this.Name = "PrimesCalculatorForm";
            this.Text = "Primes Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox first_txtBox;
        private System.Windows.Forms.TextBox last_textBox;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.ListBox result;
        private System.Windows.Forms.Label enter_rang_label;
        private System.Windows.Forms.Label first_label;
        private System.Windows.Forms.Label last_label;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label outputFile_label;
        private System.Windows.Forms.TextBox outputFile_textBox;
        private System.Windows.Forms.Label primesCount_label;
        private System.Windows.Forms.Label numbers_label;
        private System.Windows.Forms.TextBox primesCounter_textBox1;
    }
}

