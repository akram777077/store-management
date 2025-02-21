using Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;
using ServiceLayer.ServiceImplementations;

namespace ServiceLayer;

public static class ModuleDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IDealTypeService, DealTypeService>();
        services.AddScoped<IDiscountRuleService, DiscountRuleService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IInvoiceItemService, InvoiceItemService>();
        services.AddScoped<IPaymentMethodService, PaymentMethodService>();
        services.AddScoped<IPricingService, PricingService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();
        services.AddScoped<ISaleService, SaleService>();
        services.AddScoped<ISaleTypeService, SaleTypeService>();
        services.AddScoped<IUnitTypeService, UnitTypeService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IInventoryDetailService, InventoryDetailService>();
        services.AddScoped<IUserService, UserService>();

        // Register generic service
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        return services;
    }
}