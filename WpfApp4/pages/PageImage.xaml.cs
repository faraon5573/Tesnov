using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4.pages
{
    /// <summary>
    /// Логика взаимодействия для PageImage.xaml
    /// </summary>
    public partial class PageImage : Page
    {
        List<users> users;
        List<users> lu1;
        PageChange pc = new PageChange();
        public PageImage()
        {
            InitializeComponent();
            users = BaseConnect.BaseModel.users.ToList();
            lbUsersList.ItemsSource = users;
            lu1 = users;
            DataContext = pc;
        }

        //public PageImage(users Ululu, object sender)
        //{
        //    InitializeComponent();
        //    try
        //    {
        //        System.Windows.Controls.Image IMG = sender as System.Windows.Controls.Image;
        //        int ind = Convert.ToInt32(IMG.Uid);
        //        users U = BaseConnect.BaseModel.users.FirstOrDefault(x => x.id == ind);
        //        usersimage UI = BaseConnect.BaseModel.usersimage.FirstOrDefault(x => x.id_user == ind);
        //        BitmapImage BI = new BitmapImage();
        //        if (UI.path != null)
        //        {
        //            BI = new BitmapImage(new Uri(UI.path, UriKind.Relative));
        //        }
        //        else
        //        {
        //            BI.BeginInit();
        //            BI.StreamSource = new MemoryStream(UI.image);
        //            BI.EndInit();
        //        }
        //        IMG.Source = BI;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка!");
        //    }
        //}
        private void Back(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }
        private void UserImage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image IMG = sender as System.Windows.Controls.Image;
            int ind = Convert.ToInt32(IMG.Uid);
            users U = BaseConnect.BaseModel.users.FirstOrDefault(x => x.id == ind);
            usersimage UI = BaseConnect.BaseModel.usersimage.FirstOrDefault(x => x.id_user == ind);
            BitmapImage BI = new BitmapImage();
            if (UI.path != null)
            {
                BI = new BitmapImage(new Uri(UI.path, UriKind.Relative));
            }
            else
            {
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(UI.image);
                BI.EndInit();
            }
            IMG.Source = BI;
        }
    }
}
