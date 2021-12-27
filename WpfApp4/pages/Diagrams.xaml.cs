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

namespace WpfApp4.pages
{
    /// <summary>
    /// Логика взаимодействия для Diagrams.xaml
    /// </summary>
    public partial class Diagrams : Page
    {
        public Diagrams()
        {
            InitializeComponent();


        }
        private void gridDiagram_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            double maxX = gridDiagram.ActualWidth;
            double maxY = gridDiagram.ActualHeight;
            gridDiagram.Children.Clear();//очишаем графическое поле
            gridDiagram.Children.Add(line(maxX / 20, maxY / 20, maxX / 20, maxY - maxY / 20));//помещаем созданный объект на grid
            gridDiagram.Children.Add(line(maxX / 20, maxY - maxY / 20, maxX - maxX / 20, maxY - maxY / 20));
            double count = 20, stepX = (maxX - maxX / 10) / count, stepY = (maxY - maxY / 10) / count;
            for (int i = 1; i < count; i++)
            {
                Line L = line(maxX / 20 + stepX * i, maxY - maxY / 20, maxX / 20 + stepX * i, maxY - maxY / 20 - stepY * i);
                L.Stroke = Brushes.Aqua;
                L.StrokeThickness = maxX / 100;
                gridDiagram.Children.Add(L);
                TextBlock TB = new TextBlock();
                TB.Margin = new Thickness(maxX / 25 + stepX * i, maxY - maxY / 15 - stepY * i, 0, 0);
                TB.Text = (maxY / 20 + stepY * i).ToString("F2");
                gridDiagram.Children.Add(TB);


                //gridDiagram.Children.Add(polygon(maxX / 20 * i, (maxY - maxY / 20) * i, maxX / 20 * i + maxX / 20, maxY / 20));

                ColorAnimation animation;
                animation = new ColorAnimation();
                L.Stroke = new SolidColorBrush(Colors.Transparent);
                animation.To = Colors.Aqua;
                animation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
                animation.RepeatBehavior = RepeatBehavior.Forever;
                animation.AutoReverse = true;
                L.Stroke.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            }

        }

        private Line line(double x1, double y1, double x2, double y2)
        {
            Line L = new Line();
            L.X1 = x1;
            L.Y1 = y1;
            L.X2 = x2;
            L.Y2 = y2;
            L.Stroke = Brushes.Black;
            return L;
        }

        private Polygon polygon(double x1, double y1, double x2, double y2)
        {
            Polygon P = new Polygon();
            P.Points.Add(new Point(x1, y1));
            P.Points.Add(new Point(x1, y2));
            P.Points.Add(new Point(x2, y2));
            P.Points.Add(new Point(x2, y1));
            P.Stroke = Brushes.Aqua;
            return P;
        }
    }
}
