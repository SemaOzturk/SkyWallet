namespace SkyWallet.Dal.Entities
{
    [BsonCollection("QrCode")]
    public class QrCode : Document
    {
        public double Price { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Pending,
        Ok
    }
}