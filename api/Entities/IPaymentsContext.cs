using MongoDB.Driver;

namespace FTAdverts.Entities
{
    public interface IPaymentContext
    {
        IMongoCollection<Payment> Payments { get; }
    }
}