using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FTAdverts.Entities
{
    public class PaymentContext : IPaymentContext
    {
        private readonly IMongoDatabase _db;
        private readonly string _paymentsCollection;
        public PaymentContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
            _paymentsCollection = options.Value.PaymentsCollection;
        }
        public IMongoCollection<Payment> Payments => _db.GetCollection<Payment>(_paymentsCollection);
    }
}