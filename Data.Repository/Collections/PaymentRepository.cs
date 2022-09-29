using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Model.Parameters;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;

namespace Data.Repository.Collections
{
    public class PaymentRepository: IPaymentRepository
    {
        public PaymentRepository()
        {
        }

        protected readonly IMongoDbContext context;
        private IMongoCollection<Payment> collection;

        public PaymentRepository(IMongoDBRepository context)
        {
            this.context = context.GetContext();
            collection = this.context.GetCollection<Payment>();
        }

        public async Task AddAsync(Payment entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}
