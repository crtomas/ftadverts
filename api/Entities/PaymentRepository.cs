using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FTAdverts.Entities
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IPaymentContext _context;

        public PaymentRepository(IPaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments
                            .Find(_ => true)
                            .ToList();
        }

        public Payment GetPayment(string name)
        {
            FilterDefinition<Payment> filter = Builders<Payment>.Filter.Eq(m => m.Contact, name);

            return _context
                    .Payments
                    .Find(filter)
                    .FirstOrDefault();
        }
       
        public void Create(Payment Payment)
        {
            _context.Payments.InsertOneAsync(Payment);
        }

        public bool Update(Payment Payment)
        {
            ReplaceOneResult updateResult =
                _context
                        .Payments
                        .ReplaceOne(
                            filter: g => g.Id == Payment.Id,
                            replacement: Payment);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public bool Delete(string name)
        {
            FilterDefinition<Payment> filter = Builders<Payment>.Filter.Eq(m => m.Contact, name);

            DeleteResult deleteResult = _context
                                                .Payments
                                                .DeleteOne(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}