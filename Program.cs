using System;
using System.Collections.Generic;

class Menu
{
    private string nama;  
    private int harga;

    public Menu(string nama, int harga)
    {
        this.nama = nama;
        this.harga = harga;
    }

    // Encapsulation lewat property
    public string Nama { get { return nama; } }
    public int Harga { get { return harga; } }
}

class Pegawai
{
    protected string namaPegawai;

    public Pegawai(string nama)
    {
        namaPegawai = nama;
    }

    public virtual void InfoPeran()
    {
        Console.WriteLine($"{namaPegawai} adalah Pegawai.");
    }
}

class Kasir : Pegawai
{
    public Kasir(string nama) : base(nama) { }

    public override void InfoPeran()
    {
        Console.WriteLine($"{namaPegawai} adalah Kasir di Point Coffee.");
    }
}

class Pesanan
{
    private List<Menu> daftarMenu = new List<Menu>();

    public void Tambah(Menu m)
    {
        daftarMenu.Add(m);
    }

    public void Tambah(string nama, int harga)
    {
        daftarMenu.Add(new Menu(nama, harga));
    }

    public void Cetak()
    {
        Console.WriteLine("\n=== Pesanan Anda ===");
        int total = 0;
        foreach (var m in daftarMenu)
        {
            Console.WriteLine($"- {m.Nama} : Rp {m.Harga}");
            total += m.Harga;
        }
        Console.WriteLine($"Total Bayar : Rp {total}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Selamat Datang di Point Coffee Indomaret ===");

        Kasir kasir = new Kasir("Andi");
        kasir.InfoPeran();

        Pesanan pesanan = new Pesanan();

        Menu americano = new Menu("Americano", 15000);
        Menu latte = new Menu("Caffe Latte", 20000);
        Menu cappuccino = new Menu("Cappuccino", 18000);
        Menu moccachino = new Menu("Moccachino", 22000);

        bool lanjut = true;
        while (lanjut)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Americano (Rp 15.000)");
            Console.WriteLine("2. Caffe Latte (Rp 20.000)");
            Console.WriteLine("3. Cappuccino (Rp 18.000)");
            Console.WriteLine("4. Moccachino (Rp 22.000)");
            Console.WriteLine("0. Selesai");

            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    pesanan.Tambah(americano);
                    break;
                case "2":
                    pesanan.Tambah(latte);
                    break;
                case "3":
                    pesanan.Tambah(cappuccino);
                    break;
                case "4":
                    pesanan.Tambah(moccachino);
                    break;
                case "0":
                    lanjut = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }
        }

        pesanan.Cetak();
        Console.WriteLine("\nTerima kasih sudah memesan di Point Coffee Indomaret!");
    }
}
