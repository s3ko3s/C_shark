using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet3v2.Models
{
    public class BlastFurnace
    {
        private int _temperature;
        private int _materialLevel;
        private CancellationTokenSource? _cts;
        private Task? _workTask;
        private readonly object _lock = new object();
        private static readonly Random _random = new Random(); // статический с lock при использовании

        public string Name { get; set; }

        public int MaxTemperature { get; set; } = 2000;
        public int OverheatThreshold { get; set; } = 1500;
        public double OverheatProbability { get; set; } = 0.3;
        public int WorkIntervalMs { get; set; } = 500;

        public int Temperature
        {
            get
            {
                lock (_lock) return _temperature;
            }
            private set
            {
                int newValue = Math.Clamp(value, 0, MaxTemperature);
                bool changed;
                lock (_lock)
                {
                    changed = _temperature != newValue;
                    _temperature = newValue;
                }
                if (changed) OnTemperatureChanged(newValue);
            }
        }

        public int MaterialLevel
        {
            get
            {
                lock (_lock) return _materialLevel;
            }
            private set
            {
                int newValue = Math.Max(value, 0);
                bool changed;
                lock (_lock)
                {
                    changed = _materialLevel != newValue;
                    _materialLevel = newValue;
                }
                if (changed) OnMaterialChanged(newValue);
            }
        }

        public bool IsRunning => _cts is { IsCancellationRequested: false };

        public event EventHandler<OverheatEventArgs>? Overheat;
        public event EventHandler? MaterialRanOut;
        public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;
        public event EventHandler<MaterialChangedEventArgs>? MaterialChanged;

        public BlastFurnace(string name, int initialTemperature = 500, int initialMaterial = 500)
        {
            Name = name;
            Temperature = initialTemperature;
            MaterialLevel = initialMaterial;
        }

        protected virtual void OnTemperatureChanged(int newTemp) =>
            TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(newTemp));

        protected virtual void OnMaterialChanged(int newMaterial) =>
            MaterialChanged?.Invoke(this, new MaterialChangedEventArgs(newMaterial));

        protected virtual void OnOverheat(int temperature) =>
            Overheat?.Invoke(this, new OverheatEventArgs(temperature));

        protected virtual void OnMaterialRanOut() =>
            MaterialRanOut?.Invoke(this, EventArgs.Empty);

        public void Start()
        {
            lock (_lock)
            {
                if (IsRunning) return;
                _cts = new CancellationTokenSource();
                _workTask = Task.Run(() => WorkLoopAsync(_cts.Token));
            }
        }

        public async Task StopAsync()
        {
            CancellationTokenSource? cts = null;
            Task? task = null;
            lock (_lock)
            {
                if (_cts == null) return;
                cts = _cts;
                task = _workTask;
                _cts = null;
                _workTask = null;
            }
            if (cts != null)
            {
                cts.Cancel();
                if (task != null)
                    try { await task; } catch (OperationCanceledException) { }
                cts.Dispose();
            }
        }

        // Неблокирующая остановка для UI (без ожидания задачи)
        public void Stop()
        {
            _ = StopAsync(); // огонь и забыл, не блокируем поток
        }

        private async Task WorkLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(WorkIntervalMs, token).ConfigureAwait(false);

                    int materialDecrease, tempIncrease;
                    lock (_random) // синхронизация доступа к Random
                    {
                        materialDecrease = _random.Next(10, 31);
                        tempIncrease = _random.Next(5, 21);
                    }

                    MaterialLevel -= materialDecrease;
                    Temperature += tempIncrease;

                    if (MaterialLevel <= 0)
                    {
                        OnMaterialRanOut();
                        break;
                    }

                    bool overheat;
                    lock (_random)
                    {
                        overheat = Temperature >= OverheatThreshold && _random.NextDouble() < OverheatProbability;
                    }
                    if (overheat)
                    {
                        OnOverheat(Temperature);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // нормальная отмена
            }
            catch (Exception ex)
            {
                // Логирование ошибки (можно вывести в консоль или событие)
                System.Diagnostics.Debug.WriteLine($"Ошибка в WorkLoopAsync: {ex.Message}");
                OnMaterialRanOut(); // аварийная остановка
            }
            finally
            {
                lock (_lock)
                {
                    _cts?.Dispose();
                    _cts = null;
                    _workTask = null;
                }
            }
        }

        public void AddMaterial(int amount)
        {
            if (amount <= 0) return;
            MaterialLevel += amount;
        }

        public void ReduceTemperature(int amount)
        {
            if (amount <= 0) return;
            Temperature -= amount;
        }
    }
}