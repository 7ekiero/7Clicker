using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace SteroidClicker;

public enum ClickMode
{
    Turbo,
    Human
}

public class ClickerEngine
{
    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    private bool _isRunning = false;
    private readonly Random _rnd = new();

    public event Action<string>? OnLog;
    public bool IsRunning => _isRunning;

    public void Stop()
    {
        _isRunning = false;
        OnLog?.Invoke("Motor detenido.");
    }

    public async Task Start(ClickMode mode, int param1, int param2, bool enableMovement = false)
    {
        if (_isRunning) return;
        _isRunning = true;

        string modeName = mode == ClickMode.Turbo ? "TURBO" : "FANTASMA";
        OnLog?.Invoke($"Iniciado {modeName}...");

        await Task.Run(() =>
        {
            while (_isRunning)
            {
                if (mode == ClickMode.Turbo)
                {
                    PerformClick();
                    double delay = GetGaussianRandom(param1, param2);
                    Thread.Sleep(Math.Max(10, (int)delay));
                }
                else // MODO HUMANO
                {
                    PerformClick();

                    if (_rnd.Next(0, 100) < 10)
                    {
                        Thread.Sleep(_rnd.Next(80, 150));
                        PerformClick();
                    }

                    int totalWaitMs = _rnd.Next(param1 * 1000, param2 * 1000);

                    if (_rnd.Next(0, 100) < 5) totalWaitMs += _rnd.Next(2000, 5000);

                    if (enableMovement)
                        PerformHumanWait(totalWaitMs);
                    else
                        Thread.Sleep(totalWaitMs);
                }
            }
        });
    }

    private void PerformHumanWait(int totalWaitMs)
    {
        int elapsed = 0;
        int slice = 100;

        while (elapsed < totalWaitMs && _isRunning)
        {
            if (_rnd.Next(0, 100) < 20)
            {
                int dx = _rnd.Next(-3, 4);
                int dy = _rnd.Next(-3, 4);
                mouse_event(MOUSEEVENTF_MOVE, dx, dy, 0, 0);
            }
            Thread.Sleep(slice);
            elapsed += slice;
        }
    }

    private void PerformClick()
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        Thread.Sleep(_rnd.Next(40, 90));
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }

    private double GetGaussianRandom(double mean, double stdDev)
    {
        double u1 = 1.0 - _rnd.NextDouble();
        double u2 = 1.0 - _rnd.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * randStdNormal;
    }
}