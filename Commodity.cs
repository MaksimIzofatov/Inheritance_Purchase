using System;

namespace HomeWork_5
{
    class Commodity
    {
        /// <summary>
        /// Рандомайзер для создания даты
        /// </summary>
        private Random _r = new Random();

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        public double Cost { get; private set; }

        /// <summary>
        /// Дата изготовления товара
        /// </summary>
        public DateTime DateOfManufacture { get; private set; }

        /// <summary>
        /// Срок годности товара
        /// </summary>
        public int ExpirationDate { get; private set; }

        /// <summary>
        /// Конструктор для создания товара
        /// </summary>
        /// <param name="name"> Название товара </param>
        /// <param name="cost"> Стоимость товара </param>
        /// <param name="expirationDate"> Срок годности </param>
        public Commodity(string name, double cost, int expirationDate)
        {
            Name = name;
            Cost = cost;
            
            DateOfManufacture = new DateTime(_r.Next(2019,2022), _r.Next(1,13), _r.Next(1,32));
            if (DateOfManufacture.Month == 2 && DateOfManufacture.Day > 28)
                DateOfManufacture = DateOfManufacture.AddDays(DateOfManufacture.Day - 28);
                
            ExpirationDate = expirationDate;
        }

        /// <summary>
        /// Дата окончания срока годности товара
        /// </summary>
        /// <returns></returns>
        public DateTime GetExpirationDate() 
        {
            var date = DateOfManufacture.AddDays(ExpirationDate);
            return new DateTime(date.Year, date.Month, date.Day); 
        }

        /// <summary>
        /// Вывод информации о товаре
        /// </summary>
        /// <returns> Информация о товаре </returns>
        public override string ToString() => "Имя: " + Name + "; " + "Стоимость: " + Cost + " р.; " + 
                                                "Дата изготовления: " + DateOfManufacture + "; " + "Срок годности: " + ExpirationDate + " д.";
    }
}
