using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Parameters;
using Entities.Model.Parameters;

namespace Logic.DataTransformation.Parameters
{
    public interface IPaymentLogic
    {
        Task AddAsync(PaymentDTO payment);
        Task<List<Payment>> GetAllAsync();
    }
}
