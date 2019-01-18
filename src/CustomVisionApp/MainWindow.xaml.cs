using CustomVisionApp.Helpers;
using CustomVisionApp.Main;
using CustomVisionApp.StreetFighter;
using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CustomVisionApp
{
    public partial class MainWindow : System.Windows.Window
    {
        private const string START = "Start";
        private const string STOP = "Stop";

        private int _countEvent;
        private LocalCustomVisionClient _customVisison;
        private MyCamera _camera;

        public MainWindow()
        {
            InitializeComponent();
            _customVisison = new LocalCustomVisionClient();
        }

        private void BStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (bStartStop.CommandParameter.Equals(START))
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void Start()
        {
            _countEvent = 0;

            _camera = new MyCamera();
            _camera.OnNewImage += OnNewImage;

            Task.Factory.StartNew(() => _camera.StartCameraAsync(500));

            bStartStop.Content = STOP;
            bStartStop.CommandParameter = STOP;
            bStartStop.Background = Brushes.PaleVioletRed;
        }

        private void Stop()
        {
            _camera.Dispose();

            TheImage.Source = null;
            Output.Text = string.Empty;

            bStartStop.Content = START;
            bStartStop.CommandParameter = START;
            bStartStop.Background = Brushes.DarkSeaGreen;
        }

        private void OnNewImage(object sender, Mat frame)
        {
            var bytes = frame.ToBytes(".png");

            ChangeUI(() =>
            {
                TheImage.Source = ImageHelper.ToImage(bytes);

                var attack = _customVisison.AnalyzeAsync(bytes).Result;
                WriteOutput(attack);
                ExecuteWhen.SameValueThreeTimes(attack, () => SpecialAttacks.Execute(attack));
            });
        }

        private void ChangeUI(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        private void WriteOutput(string attack)
        {
            Output.Text += $"> {++_countEvent} - {attack}";
            Output.Text += Environment.NewLine;
            Output.ScrollToEnd();
        }
    }
}
