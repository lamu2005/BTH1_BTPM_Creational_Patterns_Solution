using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_RealPrototypePattern_Nhanvienbanhang
{
    internal class Program
    {
        public abstract class ComboKhuyenMaiPrototype
        {
            public string TenCombo { get; set; }
            public double GiaBan { get; set; }
            public List<string> DanhSachMon { get; set; } = new List<string>();

            public abstract ComboKhuyenMaiPrototype Clone();

            public void InThongTin()
            {
                Console.WriteLine($"Combo: {TenCombo} | Giá: {GiaBan:N0} VNĐ | Món: {string.Join(", ", DanhSachMon)}");
            }
        }

        public class ComboTet : ComboKhuyenMaiPrototype
        {
            public override ComboKhuyenMaiPrototype Clone()
            {
                ComboTet clone = (ComboTet)this.MemberwiseClone();
                clone.DanhSachMon = new List<string>(this.DanhSachMon); // Deep copy list
                return clone;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÁN HÀNG: PROTOTYPE PATTERN ===");

            // Combo Gốc
            ComboTet comboMau = new ComboTet
            {
                TenCombo = "Combo Tết Sum Vầy",
                GiaBan = 500000,
                DanhSachMon = new List<string> { "Bánh Chưng", "Mứt Tết", "Trà Oolong" }
            };

            Console.WriteLine("-- Combo Mẫu --");
            comboMau.InThongTin();

            // Nhân viên Bán hàng nhân bản và tùy chỉnh cho khách
            ComboTet comboKhachA = (ComboTet)comboMau.Clone();
            comboKhachA.TenCombo = "Combo Tết Sum Vầy (Thêm Rượu)";
            comboKhachA.DanhSachMon.Add("Rượu Vang");
            comboKhachA.GiaBan = 750000;

            Console.WriteLine("\n-- Combo Nhân Bản Cho Khách A --");
            comboKhachA.InThongTin();

            Console.ReadLine();
        }
    }
}
