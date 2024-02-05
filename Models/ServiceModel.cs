namespace APIsrl.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string ServiceDescription { get; set; }
        public string SpentMaterial { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double GrossProfit { get; set; }
        public double NetProfit { get; set; }
        public double TotalBudget { get; set; }
        public int ClientId { get; set; }
        public virtual ClientModel? Client { get; set; }


      
    }
}
