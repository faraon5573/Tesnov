using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для PageUserList.xaml
    /// </summary>
    public partial class PageUserList : Page
    {
        List<users> users;
        List<users> lu1;
        PageChange pc = new PageChange();
        public PageUserList()
        {
            InitializeComponent();
            users = BaseConnect.BaseModel.users.ToList();
            lbUsersList.ItemsSource = users;
            lbGenderFilter.ItemsSource = BaseConnect.BaseModel.genders.ToList();
            lbGenderFilter.SelectedValuePath = "id";
            lbGenderFilter.DisplayMemberPath = "gender";
            lu1 = users;
            DataContext = pc;
        }
        private void lbTraits_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int index = Convert.ToInt32(lb.Uid);
            lb.ItemsSource = BaseConnect.BaseModel.users_to_traits.Where(x => x.id_user == index).ToList();
            lb.DisplayMemberPath = "traits.trait";
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lbUsersList.ItemsSource = users;
            lu1 = users;
            lbGenderFilter.SelectedIndex = -1;
            txtNameFilter.Text = "";
            txtOT.Text = "";
            txtDO.Text = "";
            txtPageCount.Text = "";
            txtCurrentPage.Text = "";
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            try
            {
                int OT = Convert.ToInt32(txtOT.Text) - 1;
                int DO = Convert.ToInt32(txtDO.Text);
                lu1 = users.Skip(OT).Take(DO - OT).ToList();
            }
            catch
            {
                //ничего не надо делать, если этот фильтр не применен
            }
            if (lbGenderFilter.SelectedValue != null)
            {
                lu1 = lu1.Where(x => x.gender == (int)lbGenderFilter.SelectedValue).ToList();

            }

            if (txtNameFilter.Text != "")
            {
                lu1 = lu1.Where(x => x.name.Contains(txtNameFilter.Text)).ToList();
            }

            lbUsersList.ItemsSource = lu1;
            pc.Countlist = lu1.Count;
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;        
            switch (tb.Uid)
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            lbUsersList.ItemsSource = lu1.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
            txtCurrentPage.Text = "Текущая страница: " + (pc.CurrentPage).ToString();
        }
        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text);
            }
            catch
            {
                pc.CountPage = lu1.Count;
            }
            pc.Countlist = users.Count;
            lbUsersList.ItemsSource = lu1.Skip(0).Take(pc.CountPage).ToList();
        }
        private void UserImage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image IMG = sender as System.Windows.Controls.Image;
            int ind = Convert.ToInt32(IMG.Uid);
            users U = BaseConnect.BaseModel.users.FirstOrDefault(x => x.id == ind);
            usersimage UI = BaseConnect.BaseModel.usersimage.FirstOrDefault(x => x.id_user == ind);
            BitmapImage BI = new BitmapImage();
            if (UI != null)
            {
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
            }
            else
            {
                switch (U.gender)
                {
                    case 1:
                        BI = new BitmapImage(new Uri(@"/images/male.jpg", UriKind.Relative));
                        break;
                    case 2:
                        BI = new BitmapImage(new Uri(@"/images/female.jpg", UriKind.Relative));
                        break;
                    default:
                        BI = new BitmapImage(new Uri(@"/images/other.jpg", UriKind.Relative));
                        break;
                }
            }
            IMG.Source = BI;
        }
        private void BtmAddImage_Click(object sender, RoutedEventArgs e)
        {
            Button BTN = (Button)sender;
            int ind = Convert.ToInt32(BTN.Uid);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".jpg";
            openFileDialog.Filter = "Изображения |*.jpg;*.png";
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                System.Drawing.Image UserImage = System.Drawing.Image.FromFile(openFileDialog.FileName);
                ImageConverter IC = new ImageConverter();
                byte[] ByteArr = (byte[])IC.ConvertTo(UserImage, typeof(byte[]));
                usersimage UI = new usersimage() { id_user = ind, image = ByteArr};
                BaseConnect.BaseModel.usersimage.Add(UI);
                BaseConnect.BaseModel.SaveChanges();
                MessageBox.Show("Картинка пользователя добавлена в базу");
            }
            else
            {
                MessageBox.Show("Операция выбора изображения отменена");
            }
        }
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            RadioButton RB = (RadioButton)sender;
            switch (RB.Uid)
            {
                case "name":
                    lu1 = lu1.OrderBy(x => x.name).ToList();
                    break;
                case "DR":
                    lu1 = lu1.OrderBy(x => x.dr).ToList();
                    break;
            }
            if (RBReverse.IsChecked == true) lu1.Reverse();
            lbUsersList.ItemsSource = lu1;
        }
        private void BtmProsmImage_Click(object sender, RoutedEventArgs e)
        {
            Button BTN = (Button)sender;
            int ind = Convert.ToInt32(BTN.Uid);
            users Ululu = BaseConnect.BaseModel.users.FirstOrDefault(x => x.id == ind);
            LoadPages.MainFrame.Navigate(new PageImage());
        }
    }
}
