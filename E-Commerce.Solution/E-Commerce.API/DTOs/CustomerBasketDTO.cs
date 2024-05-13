using E_Commerce.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.DTOs
{
    public class CustomerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}
