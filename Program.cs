using System;

public class BankAccount
{
    // TODO 1: Terapkan enkapsulasi. Buat atribut untuk saldo.
    private double balance;

    // TODO 2: Lengkapi konstruktor ini untuk menginisialisasi saldo.
    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    // TODO 3: Buat sebuah properti publik (getter) untuk mendapatkan saldo.
    public double Balance
    {
        get { return balance; }
    }

    // TODO 4: Lengkapi metode Deposit. Pastikan jumlahnya positif.
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    // TODO 5: Lengkapi metode Withdraw. Pastikan jumlahnya cukup dan jumlahnya positif.
    // Kembalikan nilai boolean (true) jika berhasil dan false jika gagal.
    public bool Withdraw(double amount)
    {
        if (amount > 0 && balance >= amount)
        {  balance -= amount;
            return true;
        }
        return false;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di ATM Sederhana!");

        BankAccount myAccount = new BankAccount(1000.0);
        Console.WriteLine($"Saldo awal: {myAccount.Balance}");

        myAccount.Deposit(500.0);
        myAccount.Withdraw(250.0);
        myAccount.Withdraw(1500.0); // Coba penarikan yang gagal
        myAccount.Deposit(-100.0); // Coba deposit yang gagal

        Console.WriteLine($"Saldo akhir: {myAccount.Balance}");
    }
}