namespace RTS_GUI
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
            this.loadTestData = new System.Windows.Forms.Button();
            this.runTest = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadTestData
            // 
            this.loadTestData.Location = new System.Drawing.Point(22, 34);
            this.loadTestData.Name = "loadTestData";
            this.loadTestData.Size = new System.Drawing.Size(97, 39);
            this.loadTestData.TabIndex = 0;
            this.loadTestData.Text = "Load Test Data";
            this.loadTestData.UseVisualStyleBackColor = true;
            this.loadTestData.Click += new System.EventHandler(this.loadTestData_Click);
            // 
            // runTest
            // 
            this.runTest.Location = new System.Drawing.Point(22, 103);
            this.runTest.Name = "runTest";
            this.runTest.Size = new System.Drawing.Size(97, 39);
            this.runTest.TabIndex = 1;
            this.runTest.Text = "Run Test";
            this.runTest.UseVisualStyleBackColor = true;
            this.runTest.Click += new System.EventHandler(this.runTest_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(194, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(367, 186);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(22, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Warning:  Screen resolution needs to be (or around) 1366 x 768.  Screen cannot be" +
    " locked during test run.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.runTest);
            this.Controls.Add(this.loadTestData);
            this.Name = "Form1";
            this.Text = "RTS_TestTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadTestData;
        private System.Windows.Forms.Button runTest;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

