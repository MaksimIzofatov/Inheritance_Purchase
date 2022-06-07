using System;

namespace HomeWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPurchase[] purchases = new AbstractPurchase[]
            {
                new DiscountPurchase(new Commodity("Молоко", 1.20, 7), 10, 5),
                new DiscountPurchase(new Commodity("Сахар", 1.80, 180), 5, 10),
                new DiscountPurchase(new Commodity("Хлеб", 1.40, 10), 3, 7),
                new TransportExpensesPurchase(new Commodity("Телевизор", 950, 10000), 2, 100),
                new TransportExpensesPurchase(new Commodity("Ноутбук", 1300, 5000), 3, 50),
                new TransportExpensesPurchase(new Commodity("Шины", 100, 1500), 4, 10),
                new TransportExpensesPurchase(new Commodity("Шины", 100, 10), 4, 10),
            };

            Console.WriteLine("Массив продуктов:");
            foreach(var purchase in purchases)
                Console.WriteLine(purchase);

            Console.WriteLine("\nМассив продуктов отсортированный по убыванию по имени");
            try
            {
                Array.Sort(purchases);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            // вывод отсортированного масиива
            foreach(var purchase in purchases)
                Console.WriteLine(purchase);

            Console.WriteLine("\nОбщее количество товара: \"шины\"");
            for (int i = 0; i < purchases.Length; i++)
            {
                if(purchases[i].Commodity.Name.ToLower() == "шины")
                {
                    Console.WriteLine(purchases[i].Sum(purchases[i + 1]));
                    break;
                }
            }

            Console.WriteLine("\nДо окончания срока годности осталось меньше 7 дней: ");

            foreach (var pur in purchases)
            {
                if (pur.Commodity.GetExpirationDate() - DateTime.Now < TimeSpan.FromDays(7))
                    Console.WriteLine(pur);
            }
        }
    }
}
