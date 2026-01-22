using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading; // Necesario para PeriodicTimer

namespace SteroidClicker;

public partial class MainWindow : Window
{
    private readonly ClickerEngine _engine = new();

    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);
    private const int VK_F6 = 0x75;

    public MainWindow()
    {
        InitializeComponent();
        _engine.OnLog += (msg) => Dispatcher.Invoke(() => TxtStatus.Text = msg);
        Task.Run(GlobalKeyListener);
    }

    private void BtnToggle_Click(object sender, RoutedEventArgs e) => ToggleEngine();

    private void ToggleEngine()
    {
        if (_engine.IsRunning)
        {
            _engine.Stop();
            UpdateUI(false);
        }
        else
        {
            // Verificamos qué pestaña está seleccionada de forma segura
            if (Tabs.SelectedItem is TabItem selectedTab)
            {
                string header = selectedTab.Header?.ToString() ?? "";

                if (header == "MODO TURBO")
                {
                    int mean = (int)SliderMean.Value;
                    int dev = (int)SliderDev.Value;
                    _ = _engine.Start(ClickMode.Turbo, mean, dev, false);
                }
                else // MODO FANTASMA
                {
                    int minSec = (int)SliderMinSec.Value;
                    int maxSec = (int)SliderMaxSec.Value;

                    if (minSec >= maxSec) maxSec = minSec + 1;

                    bool move = ChkMovement.IsChecked ?? false;

                    _ = _engine.Start(ClickMode.Human, minSec, maxSec, move);
                }
                UpdateUI(true);
            }
        }
    }

    private void UpdateUI(bool active)
    {
        if (active)
        {
            BtnToggle.Content = "DETENER (F6)";
            BtnToggle.BorderBrush = new SolidColorBrush(Colors.Red);
            BtnToggle.Foreground = new SolidColorBrush(Colors.Red);
            Tabs.IsEnabled = false;
        }
        else
        {
            BtnToggle.Content = "INICIAR (F6)";
            BtnToggle.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#00FF99")!;
            BtnToggle.Foreground = new SolidColorBrush(Colors.White);
            Tabs.IsEnabled = true;
        }
    }

    private async Task GlobalKeyListener()
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(15));
        while (await timer.WaitForNextTickAsync())
        {
            if ((GetAsyncKeyState(VK_F6) & 0x8000) != 0)
            {
                Dispatcher.Invoke(ToggleEngine);
                await Task.Delay(300);
            }
        }
    }
}