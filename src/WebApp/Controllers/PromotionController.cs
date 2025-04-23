using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eShop.WebApp.Controllers
{
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public PromotionController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost("api/promotions")]
        public IActionResult CreateOrUpdatePromotion([FromBody] PromotionDto promotionDto)
        {
            var product = _catalogService.GetCatalogItem(promotionDto.ProductId).Result;
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            product.PromotionalDiscountPercentage = promotionDto.PromotionalDiscountPercentage;
            product.PromotionalDiscountDescription = promotionDto.PromotionalDiscountDescription;
            product.PromotionStartDate = promotionDto.PromotionStartDate;
            product.PromotionEndDate = promotionDto.PromotionEndDate;
            product.BadgeDesign = promotionDto.BadgeDesign;

            // Saving updated product details
            _catalogService.UpdateCatalogItem(product);

            return Ok(new { success = true, message = "Promotion updated successfully." });
        }

        [HttpGet("api/promotions")]
        public IActionResult GetPromotions()
        {
            var promotions = _catalogService.GetCatalogItems().Result
                .Where(p => p.PromotionStartDate <= DateTime.Now && p.PromotionEndDate >= DateTime.Now);
            return Ok(new { promotions });
        }
    }

    public class PromotionDto
    {
        public int ProductId { get; set; }
        public int? PromotionalDiscountPercentage { get; set; }
        public string PromotionalDiscountDescription { get; set; }
        public DateTime? PromotionStartDate { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public string BadgeDesign { get; set; }
    }
}
