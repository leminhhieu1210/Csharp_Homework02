using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace QlySach
{
    class Sach
    {
        private string maSach, tenSach, tenTG;
        private int soLuong;

        //Alt + Enter --> Encapsulate fields (and use property)
        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TenTG { get => tenTG; set => tenTG = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        
        public Sach()
        {
            tenSach = maSach = tenTG = "";
            SoLuong = 0;
        }

        //Alt + Enter --> Generate Constructor
        public Sach(string maSach, string tenSach, string tenTG, int soLuong)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tenTG = tenTG;
            this.soLuong = soLuong;
        }

        public void nhap()
        {
            Console.Write("Ma sach: "); maSach = Console.ReadLine();
            Console.Write("Ten sach: "); tenSach = Console.ReadLine();
            Console.Write("Ten tac gia: "); tenTG = Console.ReadLine();
            Console.Write("So luong: "); soLuong = int.Parse(Console.ReadLine());
        }

        public void xuat()
        {
            Console.Write(maSach + "\t" + tenSach + "\t" + tenTG + "\t" + soLuong.ToString());
        }
    }
}
