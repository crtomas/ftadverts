using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTAdverts.Entities
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPayment(string name);
        void  Create(Payment payment);
        bool Update(Payment payment);
        bool Delete(string name);
    }
}