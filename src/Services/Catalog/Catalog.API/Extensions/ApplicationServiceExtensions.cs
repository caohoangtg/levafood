using Catalog.Application.Features.Products.Commands;
using Catalog.Application.Mappings;
using Catalog.Infrastructure.Contracts.IRepositories;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Application Service Registration
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            //services.AddValidatorsFromAssembly(typeof(GetProductQueryHandler).Assembly);
            services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);

            //Infrastructure Service Registration
            services.AddDbContext<CatalogContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("CatalogConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IModifierGroupRepository, ModifierGroupRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
