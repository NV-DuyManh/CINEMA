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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Cinema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Lưu ý: Đảm bảo chuỗi kết nối này đúng với file .mdf thực tế của bạn
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBRapPhim.mdf;Integrated Security=True;Connect Timeout=30";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Password.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(1) FROM nguoidung WHERE tai_khoan = @taikhoan AND mat_khau = @matkhau";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@taikhoan", taiKhoan);
                        cmd.Parameters.AddWithValue("@matkhau", matKhau);
                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result == 1)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            Menu formMenu = new Menu();
                            formMenu.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                            txtMatKhau.Clear();
                            txtTaiKhoan.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Cơ sở dữ liệu: \n" + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Sự kiện khi nhấn vào dòng chữ Quên mật khẩu
        private void txtQuenMatKhau_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ Admin để được cấp lại mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}