using System;

namespace HomeWork_5
{
    class TransportExpensesPurchase : AbstractPurchase
    {
        /// <summary>
        /// Стоимость доставки покупки
        /// </summary>
        public double TransportExpenses { get; private set; }

        /// <summary>
        /// Конструктор для создания покупки 
        /// </summary>
        /// <param name="commodity"> Товар </param>
        /// <param name="amount"> Количество </param>
        /// <param name="expenses"> Стоимость доставки </param>
        public TransportExpensesPurchase(Commodity commodity, int amount, double expenses) : base(commodity, amount)
        {
            TransportExpenses = expenses;
        }

        /// <summary>
        /// Метод для получения стоимости покупки
        /// </summary>
        /// <returns> Стоимость покупки </returns>
        public override double GetCost() => (Commodity.Cost + TransportExpenses) * Amount;

        /// <summary>
        /// Метод для сложения двух покупок с одинаковыми именами
        /// </summary>
        /// <param name="purchase"> Покупка </param>
        /// <returns> Покупка с одщим количеством  </returns>
        public override AbstractPurchase Sum(AbstractPurchase purchase)
        {
            if (Commodity.Name.ToLower().Equals(purchase.Commodity.Name.ToLower()))
                return new TransportExpensesPurchase(Commodity, Amount + purchase.Amount, TransportExpenses);
            else
                throw new Exception("Нельзя сложить покупки с разными товарами!");
        }
    }
}
