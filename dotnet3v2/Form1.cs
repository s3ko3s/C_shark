using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dotnet3v2
{
    public partial class Form1 : Form
    {
        private List<FurnaceControl> _furnaceControls = new List<FurnaceControl>();
        private int _furnaceCounter = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddFurnace_Click(object sender, EventArgs e)
        {
            string name = $"Печь {_furnaceCounter++}";
            FurnaceControl furnaceControl = new FurnaceControl(name);
            furnaceControl.Width = 480;   // фиксированная ширина плитки
            furnaceControl.Height = 150;   // фиксированная высота
            flowLayoutPanel.Controls.Add(furnaceControl);
            _furnaceControls.Add(furnaceControl);
        }
    }
}