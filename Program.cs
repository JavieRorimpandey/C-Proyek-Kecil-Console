using System;
using System.Collections.Generic;

namespace UmkmPizza
{
    public class ItemMenu
    {
        private string nama;
        private double harga;

        public ItemMenu(string nama, double harga)
        {
            this.nama = nama;
            this.harga = harga;
        }

        public string Nama { get { return nama; } }
        public double Harga { get { return harga; } }

        public virtual double HitungHarga()
        {
            return harga;
        }

        public virtual void TampilkanInfo()
        {
            Console.WriteLine($"Item: {nama}, Harga Dasar: {harga:C}");
        }
    }

    public class Pizza : ItemMenu
    {
        private string ukuran; 
        private List<string> topping = new List<string>();

        public Pizza(string nama, double harga, string ukuran) : base(nama, harga)
        {
            this.ukuran = ukuran;
        }

        public override double HitungHarga()
        {
            double pengali = ukuran.ToLower() == "sedang" ? 1.2 : ukuran.ToLower() == "besar" ? 1.5 : 1.0;
            double biayaTopping = topping.Count * 5000;
            return base.HitungHarga() * pengali + biayaTopping;
        }

        public override void TampilkanInfo()
        {
            Console.WriteLine($"Item: {Nama}, Harga Dasar: {Harga:C}");
            Console.WriteLine($"Ukuran: {ukuran}, Topping: {(topping.Count > 0 ? string.Join(", ", topping) : "Tidak ada")}");
        }

        public void TambahTopping(string topping)
        {
            this.topping.Add(topping);
        }

    }
}