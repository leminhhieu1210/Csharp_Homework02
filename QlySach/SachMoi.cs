using System;
using System.Collections.Generic;
using System.Text;

namespace QlySach
{
    class SachMoi:Sach
    {
        private string qrCode;

        public SachMoi():base()
        {
            QrCode = "";
        }

        public SachMoi(string maSach, string tenSach, string tenTG, int soLuong, string qrcode) : base(maSach, tenSach, tenTG, soLuong)
        {
            this.QrCode = qrcode;
        }

        public string QrCode { get => qrCode; set => qrCode = value; }

        public new void nhap()
        {
            base.nhap();
            Console.Write("QR Code: "); qrCode = Console.ReadLine();
        }

        public new void xuat()
        {
            base.xuat();
            Console.WriteLine(" " + qrCode);
        }
    }
}
