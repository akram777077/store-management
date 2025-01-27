using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class ProductDetailRepository : GenericRepository<ProductDetail>, IProductDetailRepository
{
    private readonly DbSet<ProductDetail> _productDetails;

    public ProductDetailRepository(AppDbContext context) : base(context)
    {
        _productDetails = context.ProductDetails;
    }

    // Implement your functions here
}