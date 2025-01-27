using Infrastracture.Base;
using Infrastracture.Interfaces;
using Infrastracture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastracture
{
    public static class ModuleDependencies
    {
        public static IServiceCollection AddInfrastractureDependencies(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDealTypeRepository, DealTypeRepository>();
            services.AddScoped<IDiscountRuleRepository, DiscountRuleRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleTypeRepository, SaleTypeRepository>();
            services.AddScoped<IUnitTypeRepository, UnitTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IInventoryDetailRepository, InventoryDetailRepository>();
            // Register generic repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}