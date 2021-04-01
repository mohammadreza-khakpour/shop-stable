using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.Infrastructure.Application;
using Shop.Persistence.EF;
using Shop.Persistence.EF.AccountingDocuments;
using Shop.Persistence.EF.ProductCategories;
using Shop.Persistence.EF.ProductEntries;
using Shop.Persistence.EF.Products;
using Shop.Persistence.EF.SalesCheckLists;
using Shop.Persistence.EF.SalesItems;
using Shop.Persistence.EF.Warehouses;
using Shop.Services.AccountingDocuments;
using Shop.Services.AccountingDocuments.Contracts;
using Shop.Services.ProductCategories;
using Shop.Services.ProductCategories.Contracts;
using Shop.Services.ProductEntries;
using Shop.Services.ProductEntries.Contracts;
using Shop.Services.Products;
using Shop.Services.Products.Contracts;
using Shop.Services.SalesCheckLists;
using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.SalesItems;
using Shop.Services.SalesItems.Contracts;
using Shop.Services.Warehouses;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProductService, ProductAppService>();
            services.AddSingleton<ProductCategoryService, ProductCategoryAppService>();
            services.AddSingleton<AccountingDocumentService, AccountingDocumentAppService>();
            services.AddSingleton<ProductEntryService, ProductEntryAppService>();
            services.AddSingleton<SalesCheckListService, SalesCheckListAppService>();
            services.AddSingleton<SalesItemService, SalesItemAppService>();
            services.AddSingleton<WarehouseService, WarehouseAppService>();

            services.AddSingleton<ProductRepository, EFProductRepository>();
            services.AddSingleton<ProductCategoryRepository, EFProductCategoryRepository>();
            services.AddSingleton<AccountingDocumentRepository, EFAccountingDocumentRepository>();
            services.AddSingleton<ProductEntryRepository, EFproductEntryRepository>();
            services.AddSingleton<SalesCheckListRepository, EFSalesCheckListRepository>();
            services.AddSingleton<SalesItemRepository, EFSalesItemRepository>();
            services.AddSingleton<WarehouseRepository, EFWarehouseRepository>();

            services.AddSingleton<EFDataContext>();

            services.AddSingleton<UnitOfWork, EFUnitOfWork>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
