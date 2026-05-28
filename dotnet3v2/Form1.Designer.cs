using System;
using System.Drawing;
using System.Windows.Forms;

namespace dotnet3v2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel;
        private Button btnAddFurnace;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            btnAddFurnace = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = true;        // перенос плиток в несколько рядов
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.TabIndex = 0;
            // 
            // btnAddFurnace
            // 
            btnAddFurnace.Dock = DockStyle.Top;
            btnAddFurnace.Height = 35;
            btnAddFurnace.Text = "Добавить печь";
            btnAddFurnace.UseVisualStyleBackColor = true;
            btnAddFurnace.Click += btnAddFurnace_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(808, 527);
            Controls.Add(btnAddFurnace);
            Controls.Add(flowLayoutPanel);
            Name = "Form1";
            Text = "Доменная печь - симуляция";
            ResumeLayout(false);
        }
    }
}