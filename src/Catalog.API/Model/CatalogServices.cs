using eShop.Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CatalogServices(
    CatalogContext context,
    [FromServices] ICatalogAI catalogAI,
    IOptions<CatalogOptions> options,
    ILogger<CatalogServices> logger,
    [FromServices] ICatalogIntegrationEventService eventService)
{
    public CatalogContext Context { get; } = context;
    public ICatalogAI CatalogAI { get; } = catalogAI;
    public IOptions<CatalogOptions> Options { get; } = options;
    public ILogger<CatalogServices> Logger { get; } = logger;
    public ICatalogIntegrationEventService EventService { get; } = eventService;

    public async Task<IEnumerable<Product>> GetPromotionalProductsAsync()
    {
        Logger.LogInformation("Fetching promotional products.");
        var promotionalProducts = await Context.Products
            .Where(p => p.IsPromotional)
            .ToListAsync();
        return promotionalProducts;
    }

    public async Task UpdatePromotionalProductAsync(int productId, Product updatedProduct)
    {
        Logger.LogInformation($"Updating promotional product with ID: {productId}.");

        var product = await Context.Products
            .FirstOrDefaultAsync(p => p.Id == productId && p.IsPromotional);
        
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;
            // Add other properties as needed

            await Context.SaveChangesAsync();
            Logger.LogInformation($"Product with ID: {productId} updated successfully.");
        }
        else
        {
            Logger.LogWarning($"Product with ID: {productId} not found or is not promotional.");
        }
    }
};