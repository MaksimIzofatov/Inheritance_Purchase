using System;

namespace HomeWork_5
{
    class DiscountPurchase : AbstractPurchase
    {
        /// <summary>
        /// Процент скидки
        /// </summary>
        public double Discount { get; private set; }

        /// <summary>
        /// Конструктор для создания покупки
        /// </summary>
        /// <param name="commodity"> Товар </param>
        /// <param name="amount"> Количество </param>
        /// <param name="discount"> Процент скидки </param>
        public DiscountPurchase(Commodity commodity, int amount, double discount):base(commodity, amount)
        {
            Discount = discount;
        }

        /// <summary>
        /// Метод для получения стоимости покупки
        /// </summary>
        /// <returns> Стоимость покупки</returns>
        public override double GetCost() => (Commodity.Cost - Commodity.Cost * Discount/100) * Amount;

        /// <summary>
        /// Метод для сложения двух покупок с одинаковыми названиями
        /// </summary>
        /// <param name="purchase"> Покупка </param>
        /// <returns> Покупка с одщим количеством </returns>
        public override AbstractPurchase Sum(AbstractPurchase purchase)
        {
            if (Commodity.Name.ToLower().Equals(purchase.Commodity.Name.ToLower()))
                return new DiscountPurchase(Commodity, Amount + purchase.Amount, Discount);
            else
                throw new Exception("Нельзя сложить покупки с разными товарами!");
        }
    }
}
