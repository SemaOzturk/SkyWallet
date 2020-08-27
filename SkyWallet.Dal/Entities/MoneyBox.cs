namespace SkyWallet.Dal.Entities
{
    [BsonCollection("MoneyBox")]
    public class MoneyBox : Document
    {
        public double Remainder{ get; set; }
        public User User { get; set; }

    }
}