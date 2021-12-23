using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.pages;
namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            frmMain.Navigate(new login());
            LoadPages.MainFrame = frmMain;
            BaseConnect.BaseModel= new Entities1();



            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = new TimeSpan(0, 0, 1);
            doubleAnimation.From = 100;
            doubleAnimation.To = 200;
            doubleAnimation.AutoReverse = true;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            Banner.BeginAnimation(WidthProperty, doubleAnimation);
            Logo.BeginAnimation(WidthProperty, doubleAnimation);

            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
            doubleAnimation1.Duration = new TimeSpan(0, 0, 1);
            doubleAnimation1.From = -10;
            doubleAnimation1.To = 0;
            doubleAnimation1.AutoReverse = true;
            doubleAnimation1.RepeatBehavior = RepeatBehavior.Forever;
            Text.BeginAnimation(WidthProperty, doubleAnimation1);










            //DoubleAnimation doubleAnimation = new DoubleAnimation();
            //doubleAnimation.Duration = new TimeSpan(0, 0, 0,0,1);
            //doubleAnimation.From = 10;
            //doubleAnimation.To = 200;
            //doubleAnimation.AutoReverse = true;
            //doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //Banner.BeginAnimation(WidthProperty, doubleAnimation);
            //Logo.BeginAnimation(WidthProperty, doubleAnimation);
            //Text.BeginAnimation(WidthProperty, doubleAnimation);

            //DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            //doubleAnimation2.Duration = new TimeSpan(0, 0, 0, 0, 1);
            //doubleAnimation2.From = 400;
            //doubleAnimation2.To = 1600;
            //doubleAnimation2.AutoReverse = true;
            //doubleAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            //frmMain.BeginAnimation(WidthProperty, doubleAnimation2);
            //ThicknessAnimation thicknessAnimation = new ThicknessAnimation();//анимация границы
            //thicknessAnimation.From = new Thickness(0);// начальное значение анимации
            //thicknessAnimation.To = new Thickness(100); ;// конечное значение анимации
            //thicknessAnimation.Duration = TimeSpan.FromMilliseconds(1);//длительность анимации
            //thicknessAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //thicknessAnimation.AutoReverse = true;
            //frmMain.BeginAnimation(MarginProperty, thicknessAnimation);
            //DoubleAnimation btnHeightAnim = new DoubleAnimation();//анимация границы
            //btnHeightAnim.From = 400;// начальное значение анимации
            //btnHeightAnim.To = 1600; ;// конечное значение анимации
            //btnHeightAnim.Duration = TimeSpan.FromMilliseconds(1);//длительность анимации
            //btnHeightAnim.RepeatBehavior = RepeatBehavior.Forever;
            //btnHeightAnim.AutoReverse = true;
            //frmMain.BeginAnimation(HeightProperty, btnHeightAnim);
            //DoubleAnimation btnSizeAnim = new DoubleAnimation();//анимация границы
            //btnSizeAnim.From = 400;// начальное значение анимации
            //btnSizeAnim.To = 1600; ;// конечное значение анимации
            //btnSizeAnim.Duration = TimeSpan.FromMilliseconds(10);//длительность анимации
            //btnSizeAnim.RepeatBehavior = RepeatBehavior.Forever;
            //btnSizeAnim.AutoReverse = true;
            //frmMain.BeginAnimation(FontSizeProperty, btnSizeAnim);



        }

        private void frmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
