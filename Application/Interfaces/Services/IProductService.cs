using Application.DTOs;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetAsync(int id);
        Task AddAsync(ProductDTO Dto);
        Task UpdateAsync(ProductDTO Dto);
        Task DeleteAsync(int id);
    }
}
