using dotnet3v2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dotnet3v2
{
    public partial class FurnaceControl : UserControl
    {
        private BlastFurnace _furnace = null!;
        private List<Worker> _workers = new List<Worker>();

        public BlastFurnace Furnace => _furnace;

        public FurnaceControl(string furnaceName)
        {
            InitializeComponent();
            BorderStyle = BorderStyle.FixedSingle;
            _furnace = new BlastFurnace(furnaceName, 500, 500);
            AddWorker();
            SubscribeToFurnaceEvents();
            UpdateUI();
        }

        private void AddWorker()
        {
            Worker worker = new Worker();
            worker.AssignToFurnace(_furnace);
            _workers.Add(worker);
            UpdateWorkersDisplay();
        }

        private void RemoveLastWorker()
        {
            if (_workers.Count <= 1) return;
            Worker last = _workers[_workers.Count - 1];
            last.Unsubscribe();
            _workers.Remove(last);
            UpdateWorkersDisplay();
        }

        private void UpdateWorkersDisplay() => lblWorkers.Text = $"Рабочих: {_workers.Count}";

        private void SubscribeToFurnaceEvents()
        {
            _furnace.TemperatureChanged += OnTemperatureChanged;
            _furnace.MaterialChanged += OnMaterialChanged;
        }

        private void UnsubscribeFromFurnaceEvents()
        {
            _furnace.TemperatureChanged -= OnTemperatureChanged;
            _furnace.MaterialChanged -= OnMaterialChanged;
        }

        private void InvokeIfRequired(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void OnTemperatureChanged(object? sender, TemperatureChangedEventArgs e) => InvokeIfRequired(UpdateUI);
        private void OnMaterialChanged(object? sender, MaterialChangedEventArgs e) => InvokeIfRequired(UpdateUI);

        private void UpdateUI()
        {
            lblTempValue.Text = $"{_furnace.Temperature}°C";
            tempProgress.Value = Math.Min(100, _furnace.Temperature * 100 / _furnace.MaxTemperature);
            lblTempValue.BackColor = (_furnace.Temperature >= _furnace.OverheatThreshold)
                ? System.Drawing.Color.Red
                : System.Drawing.SystemColors.Control;

            lblMaterialValue.Text = _furnace.MaterialLevel.ToString();
            materialProgress.Value = Math.Min(100, _furnace.MaterialLevel * 100 / 1000);

            lblName.Text = _furnace.Name;
            btnStart.Enabled = !_furnace.IsRunning;
            btnStop.Enabled = _furnace.IsRunning;

            UpdateWorkersDisplay();
        }

        private void btnStart_Click(object sender, EventArgs e) => _furnace.Start();
        private void btnStop_Click(object sender, EventArgs e) => _furnace.Stop();
        private void btnAddWorker_Click(object sender, EventArgs e) => AddWorker();
        private void btnRemoveWorker_Click(object sender, EventArgs e) => RemoveLastWorker();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UnsubscribeFromFurnaceEvents(); // отписываемся от событий печи
            _furnace.Stop();
            foreach (var w in _workers)
                w.Unsubscribe();
            _workers.Clear();
            Parent?.Controls.Remove(this);
            Dispose();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            UnsubscribeFromFurnaceEvents();
            _furnace.Stop();
            foreach (var w in _workers)
                w.Unsubscribe();
            base.OnHandleDestroyed(e);
        }
    }
}