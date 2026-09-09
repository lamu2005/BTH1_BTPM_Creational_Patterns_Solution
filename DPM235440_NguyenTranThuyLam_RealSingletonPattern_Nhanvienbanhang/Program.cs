using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_RealSingletonPattern_Nhanvienbanhang
{
    internal class Program
    {
        public sealed class QuanLyCauHinhCuaHang
        {
            private static QuanLyCauHinhCuaHang _instance;
            private static readonly object _lock = new object();

            public string TenCuaHang { get; set; } = "Cửa Hàng Bán Lẻ An Giang";
            public string CaLamViecHienTai { get; set; } = "Ca Sáng";
            public double TyGiaUSD { get; set; } = 25400;

            private QuanLyCauHinhCuaHang() { }

            public static QuanLyCauHinhCuaHang Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new QuanLyCauHinhCuaHang();
                        }
                        return _instance;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÁN HÀNG: SINGLETON PATTERN ===");

            // Nhân viên Thu ngân 1 truy cập cấu hình
            var config1 = QuanLyCauHinhCuaHang.Instance;
            Console.WriteLine($"[Máy 1] Cửa hàng: {config1.TenCuaHang} | Ca: {config1.CaLamViecHienTai}");

            // Nhân viên Thu ngân 2 đổi ca làm việc
            var config2 = QuanLyCauHinhCuaHang.Instance;
            config2.CaLamViecHienTai = "Ca Chiều";

            // Kiểm tra máy 1 có tự cập nhật không
            Console.WriteLine($"[Máy 1 Check lại] Ca hiện tại: {config1.CaLamViecHienTai}");

            if (object.ReferenceEquals(config1, config2))
            {
                Console.WriteLine("=> Cả 2 máy thu ngân đều sử dụng chung 1 Bộ Cấu hình duy nhất!");
            }

            Console.ReadLine();
        }
    }
}
