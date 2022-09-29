using System;
namespace Entities.DTO.Parameters
{
    public class PaymentDTO
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Identification { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
