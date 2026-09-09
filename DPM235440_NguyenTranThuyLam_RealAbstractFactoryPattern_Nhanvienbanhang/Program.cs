using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_RealAbstractFactoryPattern_Nhanvienbanhang
{
    internal class Program
    {
        public interface IHoaDon { string TaoHoaDon(); }
        public interface ITemGiaoHang { string TaoTem(); }

        // Kênh Online
        public class HoaDonDienTu : IHoaDon { public string TaoHoaDon() => "Hóa đơn điện tư (PDF gửi Email)"; }
        public class TemGiaoHangNhanh : ITemGiaoHang { public string TaoTem() => "Tem mã QR Giao Hàng Nhanh"; }

        // Kênh Cửa Hàng
        public class HoaDonInGiay : IHoaDon { public string TaoHoaDon() => "Hóa đơn in giấy thu ngân"; }
        public class TemGiaoTaiKho : ITemGiaoHang { public string TaoTem() => "Tem niêm phong túi mua hàng"; }

        // Abstract Factory
        public interface IBanHangFactory
        {
            IHoaDon CreateHoaDon();
            ITemGiaoHang CreateTemGiaoHang();
        }

        public class OnlineSalesFactory : IBanHangFactory
        {
            public IHoaDon CreateHoaDon() => new HoaDonDienTu();
            public ITemGiaoHang CreateTemGiaoHang() => new TemGiaoHangNhanh();
        }

        public class InStoreSalesFactory : IBanHangFactory
        {
            public IHoaDon CreateHoaDon() => new HoaDonInGiay();
            public ITemGiaoHang CreateTemGiaoHang() => new TemGiaoTaiKho();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÁN HÀNG: ABSTRACT FACTORY PATTERN ===");

            Console.WriteLine("\n-- Xử lý Đơn Hàng Online --");
            IBanHangFactory onlineFactory = new OnlineSalesFactory();
            Console.WriteLine(onlineFactory.CreateHoaDon().TaoHoaDon());
            Console.WriteLine(onlineFactory.CreateTemGiaoHang().TaoTem());

            Console.WriteLine("\n-- Xử lý Đơn Hàng Tại Cửa Hàng --");
            IBanHangFactory instoreFactory = new InStoreSalesFactory();
            Console.WriteLine(instoreFactory.CreateHoaDon().TaoHoaDon());
            Console.WriteLine(instoreFactory.CreateTemGiaoHang().TaoTem());

            Console.ReadLine();
        }
    }
}
