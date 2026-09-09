using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_RealBuilderPattern_Nhanvienbanhang
{
    internal class Program
    {
        public class DonHang
        {
            public string TenKhachHang { get; set; }
            public string NhanVienBanHang { get; set; }
            public List<string> DanhSachSanPham { get; set; } = new List<string>();
            public double ChietKhau { get; set; }
            public double PhiGiaoHang { get; set; }

            public void InChiTiet()
            {
                Console.WriteLine($"\n--- HÓA ĐƠN BÁN HÀNG ---");
                Console.WriteLine($"Khách hàng: {TenKhachHang}");
                Console.WriteLine($"NV bán hàng: {NhanVienBanHang}");
                Console.WriteLine($"Sản phẩm: {string.Join(", ", DanhSachSanPham)}");
                Console.WriteLine($"Chiết khấu: {ChietKhau}%");
                Console.WriteLine($"Phí giao hàng: {PhiGiaoHang:N0} VNĐ");
            }
        }
        public class DonHangBuilder
        {
            private DonHang _donHang = new DonHang();

            public DonHangBuilder SetKhachHang(string ten) { _donHang.TenKhachHang = ten; return this; }
            public DonHangBuilder SetNhanVien(string ten) { _donHang.NhanVienBanHang = ten; return this; }
            public DonHangBuilder AddSanPham(string sp) { _donHang.DanhSachSanPham.Add(sp); return this; }
            public DonHangBuilder SetChietKhau(double ck) { _donHang.ChietKhau = ck; return this; }
            public DonHangBuilder SetPhiShip(double ship) { _donHang.PhiGiaoHang = ship; return this; }

            public DonHang Build() => _donHang;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÁN HÀNG: BUILDER PATTERN ===");

            DonHang dh = new DonHangBuilder()
                .SetKhachHang("Nguyễn Văn Khách")
                .SetNhanVien("Thùy Lâm (Sales)")
                .AddSanPham("Laptop Dell XPS")
                .AddSanPham("Chuột Không Dây")
                .SetChietKhau(10)
                .SetPhiShip(30000)
                .Build();

            dh.InChiTiet();
            Console.ReadLine();
        }
    }
}
