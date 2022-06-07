using System;

namespace HomeWork_5
{
    abstract class AbstractPurchase : IComparable<AbstractPurchase>
    {
        /// <summary>
        /// Товар
        /// </summary>
        public Commodity Commodity { get; private set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public int Amount { get; private set; }
        
        /// <summary>
        /// Конструктор для создания покупки
        /// </summary>
        /// <param name="commodity"> Товар </param>
        /// <param name="amount"> Количество </param>
        public AbstractPurchase(Commodity commodity, int amount)
        {
            Commodity = commodity;
            Amount = amount;
        }

        /// <summary>
        /// Абстрактный метод для сложения одинаковых покупок
        /// </summary>
        /// <param name="purchase"> Покупка </param>
        /// <returns> Новая покупка </returns>
        public abstract AbstractPurchase Sum(AbstractPurchase purchase);

        /// <summary>
        /// Метод для сортировки покупок
        /// </summary>
        /// <param name="purchase"> Покупка </param>
        /// <returns> Имя покупки</returns>
        public int CompareTo(AbstractPurchase purchase)
        {
            if (purchase is null)
                throw new Exception("Такого объекта не существует");
            return purchase.Commodity.Name.CompareTo(Commodity.Name);

        }

        /// <summary>
        /// Абстрактный метод для вычисления стоимости покупки
        /// </summary>
        /// <returns> Стоимость </returns>
        public abstract double GetCost();

        /// <summary>
        /// Метод для вывода информации о покупке
        /// </summary>
        /// <returns> Информация </returns>
        public override string ToString() => $"{Commodity}; Кол-во: {Amount} шт.; Общая стоимость: {GetCost():f2}";
    }
}
