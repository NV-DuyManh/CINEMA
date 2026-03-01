using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input; // Cần thiết cho MouseButtonEventArgs

namespace Cinema
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        // Sự kiện click vào tiêu đề để quay về trang chào mừng
        private void TxtTieuDe_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new WelcomePage());
        }

        private void BtnPhim_Click(object sender, RoutedEventArgs e)
        {
            // Nếu bạn đã tạo trang PagePhim.xaml rồi thì hãy xóa 2 dấu gạch chéo ở dưới nhé:
            //MainFrame.Navigate(new PagePhim());
        }

        private void BtnSanPham_Click(object sender, RoutedEventArgs e)
        {
            // ĐÃ MỞ KHÓA: Xóa 2 dấu gạch chéo // để lệnh chính thức hoạt động
            MainFrame.Navigate(new qlsp());
        }

        private void BtnSuatChieu_Click(object sender, RoutedEventArgs e)
        {
            // Tương tự, nếu có trang QLSuatChieu.xaml rồi thì mới mở khóa dòng dưới:
            //MainFrame.Navigate(new QLSuatChieu());
        }

        private void BtnTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new QLTaiKhoan());
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}