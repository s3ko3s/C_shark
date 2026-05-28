using System;
using System.Threading;
using System.Timers;

namespace dotnet3v2.Models
{
    public class Worker : ILoader, IDisposable
    {
        private readonly Random _random = new Random();
        private BlastFurnace? _furnace;
        private System.Timers.Timer? _periodicLoader;
        private CancellationTokenSource? _cts; // для отмены периодической загрузки

        public void AssignToFurnace(BlastFurnace furnace)
        {
            Unsubscribe();
            _furnace = furnace;
            if (_furnace != null)
            {
                _furnace.MaterialRanOut += OnMaterialRanOut;
                _furnace.Overheat += OnOverheat;
                StartPeriodicLoading();
            }
        }

        private void StartPeriodicLoading()
        {
            _cts = new CancellationTokenSource();
            _periodicLoader = new System.Timers.Timer(2000);
            _periodicLoader.Elapsed += (s, e) =>
            {
                if (_cts?.IsCancellationRequested == true) return;
                PeriodicLoad();
            };
            _periodicLoader.AutoReset = true;
            _periodicLoader.Start();
        }

        private void PeriodicLoad()
        {
            // Двойная проверка с блокировкой для безопасности
            var furnace = _furnace;
            if (furnace != null && furnace.MaterialLevel < 800)
            {
                LoadMaterial(furnace, 15);
            }
        }

        public void Unsubscribe()
        {
            // Отменяем таймер
            _cts?.Cancel();
            if (_periodicLoader != null)
            {
                _periodicLoader.Stop();
                _periodicLoader.Dispose();
                _periodicLoader = null;
            }
            _cts?.Dispose();
            _cts = null;

            // Отписываемся от событий печи
            if (_furnace != null)
            {
                _furnace.MaterialRanOut -= OnMaterialRanOut;
                _furnace.Overheat -= OnOverheat;
            }
            _furnace = null;
        }

        private void OnMaterialRanOut(object? sender, EventArgs e)
        {
            LoadMaterial(_furnace, 300);
        }

        private void OnOverheat(object? sender, OverheatEventArgs e)
        {
            int coolAmount;
            lock (_random) coolAmount = _random.Next(100, 301);
            _furnace?.ReduceTemperature(coolAmount);
        }

        public void LoadMaterial(BlastFurnace? furnace, int amount)
        {
            furnace?.AddMaterial(amount);
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}