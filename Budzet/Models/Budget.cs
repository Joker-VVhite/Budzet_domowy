namespace Budzet.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        // Ogólny budżet
        public decimal TotalAmount { get; set; }

        // Metoda do obliczania ogólnego budżetu na podstawie transakcji
        public void CalculateTotalAmount(IEnumerable<Transaction> transactions)
        {
            decimal totalAmount = 0;
            foreach (var transaction in transactions)
            {
                if (transaction.Type == "wpłata")
                {
                    totalAmount += transaction.Amount;
                }
                else if (transaction.Type == "wypłata")
                {
                    totalAmount -= transaction.Amount;
                }
            }
            TotalAmount = totalAmount;
        }
    }
}
