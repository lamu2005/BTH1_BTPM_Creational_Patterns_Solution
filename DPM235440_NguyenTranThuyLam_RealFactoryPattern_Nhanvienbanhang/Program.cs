using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_RealFactoryPattern_Nhanvienbanhang
{
    // Interface Nhân viên bán hàng
    public interface INhanVienBanHang
    {
        string TenVịTri { get; }
        double TinhHoaHong(double doanhSo);
    }

    // Nhân viên chính thức
    public class NhanVienChinhThuc : INhanVienBanHang
    {
        public string TenVịTri => "Nhân viên chính thức";
        public double TinhHoaHong(double doanhSo) => doanhSo * 0.05; // 5% hoa hồng
    }

    // Nhân viên thử việc
    public class NhanVienThuViec : INhanVienBanHang
    {
        public string TenVịTri => "Nhân viên thử việc";
        public double TinhHoaHong(double doanhSo) => doanhSo * 0.02; // 2% hoa hồng
    }

    // Creator Abstract Class
    public abstract class NhanVienFactory
    {
        public abstract INhanVienBanHang CreateNhanVien();

        public void InThongTinLuong(string hoTen, double doanhSo)
        {
            INhanVienBanHang nv = CreateNhanVien();
            double hoaHong = nv.TinhHoaHong(doanhSo);
            Console.WriteLine($"[QUẢN LÝ BÁN HÀNG] NV: {hoTen} | Vị trí: {nv.TenVịTri} | Doanh số: {doanhSo:N0} VNĐ | Hoa hồng: {hoaHong:N0} VNĐ");
        }
    }

    // Factories cụ thể
    public class ChinhThucFactory : NhanVienFactory
    {
        public override INhanVienBanHang CreateNhanVien() => new NhanVienChinhThuc();
    }

    public class ThuViecFactory : NhanVienFactory
    {
        public override INhanVienBanHang CreateNhanVien() => new NhanVienThuViec();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÁN HÀNG: FACTORY METHOD PATTERN ===");

            NhanVienFactory factory1 = new ChinhThucFactory();
            factory1.InThongTinLuong("Nguyễn Văn A", 100000000);

            NhanVienFactory factory2 = new ThuViecFactory();
            factory2.InThongTinLuong("Trần Thị B", 50000000);

            Console.ReadLine();
        }
    }
}
