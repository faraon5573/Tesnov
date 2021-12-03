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
using System.Windows.Shapes;

namespace WpfApp4.pages
{
    /// <summary>
    /// Логика взаимодействия для Gallery.xaml
    /// </summary>
    public partial class Gallery : Window
    {
        List<usersimage> LUI;
        BitmapImage BI;
        int CountUsersImages;//общее количество картинок
        int CurrentUserImage = 0;//текущая картинка
        public Gallery(int id)
        {
            InitializeComponent();
            Title = "Галерея пользователя: " + BaseConnect.BaseModel.users.FirstOrDefault(x => x.id == id).name;
            LUI = BaseConnect.BaseModel.usersimage.Where(x => x.id_user == id).ToList();
            CountUsersImages = LUI.Count;

            BI = new BitmapImage();
            if (CountUsersImages > 0)
            {
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(LUI[0].image);
                BI.EndInit();
            }
            else
            {
                BI = new BitmapImage(new Uri(@"/images/EmptyImage.jpg", UriKind.Relative));
            }

            ImgUserPic.Source = BI;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CountUsersImages > 0)
            {
                Button button = (Button)sender;
                switch (button.Uid)
                {
                    case "Left":
                        CurrentUserImage--;
                        if (CurrentUserImage < 0) CurrentUserImage = CountUsersImages - 1;
                        break;
                    case "Right":
                        CurrentUserImage++;
                        if (CurrentUserImage >= CountUsersImages) CurrentUserImage = 0;
                        break;
                    case "Avatar":
                        for (int i = 0; i < CountUsersImages; i++)
                        {
                            LUI[i].avatar = i == CurrentUserImage;
                        }
                        BaseConnect.BaseModel.SaveChanges();
                        MessageBox.Show("Аватар успешно изменен");
                        break;
                    default:
                        CurrentUserImage = 0;
                        break;
                }
                BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(LUI[CurrentUserImage].image);                
                BI.EndInit();
                ImgUserPic.Source = BI;
            }
        }
    }
}
