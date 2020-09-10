using System;
using System.Collections.Generic;

namespace QlySach
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SachMoi> ds = new List<SachMoi>();
            int kt, id = 0;

            do
            {
                SachMoi obj = new SachMoi();
                Console.WriteLine("Nhap thong tin cho sach thu {0}", id + 1);
                obj.nhap();
                ds.Add(obj);
                id++;

                Console.Write("Ban muon tiep tuc khong? (Nhan '0' de ket thuc)");
                kt = int.Parse(Console.ReadLine());

            } while (kt != 0);

            foreach (SachMoi item in ds)
            {
                item.xuat();
            }

            string qrtim;
            Console.Write("Nhap ma QRCode can tim: ");
            qrtim = Console.ReadLine();
            kt = -1;
            for (int i = 0; i < ds.Count; ++i)
            {
                //if (ds[i].QrCode.Contains(qrtim) == true) //QrCode có chứa qrtim?
                if (String.Compare(ds[i].QrCode, qrtim) == 0)
                {
                    kt = i;
                    break;
                }
            }
            if (kt < 0)
                Console.WriteLine("Khong tim thay");
            else
            {
                Console.WriteLine("Ket qua can tim: ");
                ds[kt].xuat();
            }
        }
    }
}
