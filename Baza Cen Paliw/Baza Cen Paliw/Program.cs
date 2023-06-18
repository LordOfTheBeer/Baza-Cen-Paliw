using System;
using System.Collections.Generic;

class FuelPriceManager
{
    private Dictionary<string, double> fuelPrices;

    public FuelPriceManager()
    {
        fuelPrices = new Dictionary<string, double>();
    }

    public void SetFuelPrice(string fuelType, double price)
    {
        fuelPrices[fuelType] = price;
    }

    public double GetFuelPrice(string fuelType)
    {
        if (fuelPrices.ContainsKey(fuelType))
        {
            return fuelPrices[fuelType];
        }
        else
        {
            throw new ArgumentException("Nieznany rodzaj paliwa");
        }
    }
}

class Program
{
    static void Main()
    {
        FuelPriceManager priceManager = new FuelPriceManager();

        // Dodawanie domyślnych cen paliw
        priceManager.SetFuelPrice("Benzyna", 6.22);
        priceManager.SetFuelPrice("Diesel", 6.01);
        priceManager.SetFuelPrice("LPG", 2.79);

        while (true)
        {
            Console.WriteLine("Aktualne ceny paliw:");
            Console.WriteLine("1. Benzyna: " + priceManager.GetFuelPrice("Benzyna") + " PLN");
            Console.WriteLine("2. Diesel: " + priceManager.GetFuelPrice("Diesel") + " PLN");
            Console.WriteLine("3. LPG: " + priceManager.GetFuelPrice("LPG") + " PLN");
            Console.WriteLine("4. Wyjdź z programu");

            Console.WriteLine("\nWybierz opcję (1-4):");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    UpdateFuelPrice(priceManager, "Benzyna");
                    break;
                case "2":
                    UpdateFuelPrice(priceManager, "Diesel");
                    break;
                case "3":
                    UpdateFuelPrice(priceManager, "LPG");
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                    break;
            }

            Console.Clear();
        }
    }

    static void UpdateFuelPrice(FuelPriceManager priceManager, string fuelType)
    {
        Console.WriteLine("Aktualna cena " + fuelType + ": " + priceManager.GetFuelPrice(fuelType) + " PLN");
        Console.WriteLine("Podaj nową cenę " + fuelType + ":");
        string input = Console.ReadLine();

        if (double.TryParse(input, out double newPrice))
        {
            priceManager.SetFuelPrice(fuelType, newPrice);
            Console.WriteLine("Cena " + fuelType + " została zaktualizowana.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowa cena. Wprowadź liczbę.");
        }

        Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }
}