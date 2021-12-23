using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp4.pages
{
    /// <summary>
    /// Логика взаимодействия для Animations.xaml
    /// </summary>
    public partial class Animations : Page
    {
        private bool userIsDraggingSlider = false;
        public Animations()
        {
            InitializeComponent();

            MediaGif.Play();
            MediaVideo.Play();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = new TimeSpan(0, 0, 1);
            doubleAnimation.From = 100;
            doubleAnimation.To = 500;
            doubleAnimation.AutoReverse = true;//туда и обратно
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;//количество повторов
            btnAnims1.BeginAnimation(WidthProperty, doubleAnimation);

            ColorAnimation colorAnimation = new ColorAnimation();//анимация цвета
            colorAnimation.From = Color.FromRgb(0, 0, 0);
            colorAnimation.To = Color.FromRgb(0, 255, 0);
            colorAnimation.Duration = TimeSpan.FromSeconds(1);
            colorAnimation.AutoReverse = true;
            colorAnimation.RepeatBehavior = RepeatBehavior.Forever;
            btnAnims2.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));//задний план по умолчанию
            btnAnims2.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();//анимация границы
            thicknessAnimation.From = new Thickness(0);// начальное значение анимации
            thicknessAnimation.To = new Thickness(100); ;// конечное значение анимации
            thicknessAnimation.Duration = TimeSpan.FromMilliseconds(1000);//длительность анимации
            thicknessAnimation.RepeatBehavior = RepeatBehavior.Forever;
            thicknessAnimation.AutoReverse = true;
            btnAnims3.BeginAnimation(MarginProperty, thicknessAnimation);
            DoubleAnimation btnHeightAnim = new DoubleAnimation();//анимация границы
            btnHeightAnim.From = 30;// начальное значение анимации
            btnHeightAnim.To = 100; ;// конечное значение анимации
            btnHeightAnim.Duration = TimeSpan.FromMilliseconds(1000);//длительность анимации
            btnHeightAnim.RepeatBehavior = RepeatBehavior.Forever;
            btnHeightAnim.AutoReverse = true;
            btnAnims3.BeginAnimation(HeightProperty, btnHeightAnim);
            DoubleAnimation btnSizeAnim = new DoubleAnimation();//анимация границы
            btnSizeAnim.From = 10;// начальное значение анимации
            btnSizeAnim.To = 50; ;// конечное значение анимации
            btnSizeAnim.Duration = TimeSpan.FromMilliseconds(1000);//длительность анимации
            btnSizeAnim.RepeatBehavior = RepeatBehavior.Forever;
            btnSizeAnim.AutoReverse = true;
            btnAnims3.BeginAnimation(FontSizeProperty, btnSizeAnim);


        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((MediaVideo.Source != null) && (MediaVideo.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = MediaVideo.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = MediaVideo.Position.TotalSeconds;
            }
        }

        private void btnAnims_Click1(object sender, RoutedEventArgs e)
        {
        }

        private void btnAnims_Click2(object sender, RoutedEventArgs e)
        {
        }

        private void btnAnims_Click3(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaGif.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            MediaGif.Pause();
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaGif.Stop();
        }
        private void MediaGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaGif.Position = TimeSpan.FromMilliseconds(1);
        }

        private void btnPlay_Click1(object sender, RoutedEventArgs e)
        {
            MediaVideo.Play();
        }

        private void btnPause_Click1(object sender, RoutedEventArgs e)
        {
            MediaVideo.Pause();
        }
        private void MediaVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaGif.Position = TimeSpan.FromMilliseconds(1);
        }

        private void btnStop_Click1(object sender, RoutedEventArgs e)
        {
            MediaVideo.Stop();

        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            MediaVideo.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void slVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaVideo.Volume=slVolume.Value;
        }
    }
}
