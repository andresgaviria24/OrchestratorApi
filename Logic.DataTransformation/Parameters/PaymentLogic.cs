using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repository.Collections;
using Entities.DTO.Parameters;
using Entities.Model.Parameters;
using Logic.DataTransformation.Parameters;

namespace Logic.DataTransformation
{
    public class PaymentLogic: IPaymentLogic
    {

        protected readonly IPaymentRepository repository;
        protected readonly IMapper mapper;


        public PaymentLogic(IPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddAsync(PaymentDTO paymentDto)
        {
   
            Payment payment = mapper.Map<Payment>(paymentDto);

            payment.Name = await SecurityManager.Encrypt(payment.Name);
            payment.LastName = await SecurityManager.Encrypt(payment.LastName);
            payment.Identification = await SecurityManager.Encrypt(payment.Identification);
            payment.CardNumber = await SecurityManager.Encrypt(payment.CardNumber);
            payment.CVV = await SecurityManager.Encrypt(payment.CVV);
            payment.ExpirationDate = await SecurityManager.Encrypt(payment.ExpirationDate);
            payment.Email = await SecurityManager.Encrypt(payment.Email);
            payment.CreationDate = System.DateTime.Now;

            await this.repository.AddAsync(payment);
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            List<Payment> payments = await this.repository.GetAllAsync();

            for(int i= 0; i< payments.Count; i++)
            {
                payments[i].Name = await SecurityManager.Decrypt(payments[i].Name);
                payments[i].LastName = await SecurityManager.Decrypt(payments[i].LastName);
                payments[i].Identification = await SecurityManager.Decrypt(payments[i].Identification);
                payments[i].CardNumber = await SecurityManager.Decrypt(payments[i].CardNumber);
                payments[i].CVV = await SecurityManager.Decrypt(payments[i].CVV);
                payments[i].ExpirationDate = await SecurityManager.Decrypt(payments[i].ExpirationDate);
                payments[i].Email = await SecurityManager.Decrypt(payments[i].Email);

            }

            return payments;
        }
    }
}
