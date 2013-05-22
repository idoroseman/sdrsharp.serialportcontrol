using System;
using System.Windows.Forms;
using System.Drawing;
namespace SDRSharp.SerialPortControl
{
    partial class SerialPortControlCollapsiblePanel
    {
        private Size ctrlSize = new Size(70, 15);

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PortSelectionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EnableBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortSelectionBox
            // 
            this.PortSelectionBox.FormattingEnabled = true;
            this.PortSelectionBox.Location = new System.Drawing.Point(73, 44);
            this.PortSelectionBox.Name = "PortSelectionBox";
            this.PortSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.PortSelectionBox.TabIndex = 4;
            this.PortSelectionBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            // 
            // EnableBox
            // 
            this.EnableBox.AutoSize = true;
            this.EnableBox.Enabled = false;
            this.EnableBox.Location = new System.Drawing.Point(15, 74);
            this.EnableBox.Name = "EnableBox";
            this.EnableBox.Size = new System.Drawing.Size(59, 17);
            this.EnableBox.TabIndex = 6;
            this.EnableBox.Text = "Enable";
            this.EnableBox.UseVisualStyleBackColor = true;
            this.EnableBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(172, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "RX";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "APT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Reciver";
            // 
            // SerialControlCollapsiblePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnableBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortSelectionBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SerialControlCollapsiblePanel";
            this.Size = new System.Drawing.Size(220, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox PortSelectionBox;
        private Label label1;
        private CheckBox EnableBox;
        private Label label3;
        private System.IO.Ports.SerialPort serialPort1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label2;





    }
}
