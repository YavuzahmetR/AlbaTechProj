namespace Interface
{
    interface IDaire
    {
        double Yaricap { get; set; }
        double AlanHesapla();
    }
    class Double : IDaire
    {
        public double Yaricap { get; set; }
        private double PI = 3.14;
        public double AlanHesapla() => PI * Yaricap * Yaricap;
    }
    class Kure : IDaire
    {
        public double Yaricap { get; set; }

        public double AlanHesapla()
        {
            return 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}