using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Cinema
{
    public partial class WelcomePage : Page
    {
    
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBRapPhim.mdf;Integrated Security=True;Connect Timeout=30";

        public WelcomePage()
        {
            InitializeComponent();
            this.Loaded += WelcomePage_Loaded;
        }

        private void WelcomePage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadThongKeTuDatabase();
        }

        private void LoadThongKeTuDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string queryPhim = "SELECT COUNT(*) FROM phim WHERE trang_thai = 'DangChieu'";
                    using (SqlCommand cmd = new SqlCommand(queryPhim, conn))
                    {
                        int phimCount = Convert.ToInt32(cmd.ExecuteScalar());
                        TxtPhimCount.Text = phimCount.ToString("D2"); 
                    }

                    string queryLichChieu = "SELECT COUNT(*) FROM lichchieu WHERE ngay_chieu = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(queryLichChieu, conn))
                    {
                        int lichChieuCount = Convert.ToInt32(cmd.ExecuteScalar());
                        TxtLichChieuCount.Text = lichChieuCount.ToString("D2");
                    }

                    string querySanPham = "SELECT COUNT(*) FROM sanpham WHERE trang_thai = 'DangBan'";
                    using (SqlCommand cmd = new SqlCommand(querySanPham, conn))
                    {
                        int sanPhamCount = Convert.ToInt32(cmd.ExecuteScalar());
                        TxtSanPhamCount.Text = sanPhamCount.ToString("D2");
                    }

                    string queryPhong = "SELECT COUNT(*) FROM phongchieu WHERE tinh_trang = 'HoatDong'";
                    using (SqlCommand cmd = new SqlCommand(queryPhong, conn))
                    {
                        int phongCount = Convert.ToInt32(cmd.ExecuteScalar());
                        TxtPhongCount.Text = phongCount.ToString("D2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message, "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
