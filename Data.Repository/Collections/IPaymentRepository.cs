using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Model.Parameters;

namespace Data.Repository.Collections
{
    public interface IPaymentRepository
    {
       Task AddAsync(Payment entity);
       Task<List<Payment>> GetAllAsync();
    }
}
