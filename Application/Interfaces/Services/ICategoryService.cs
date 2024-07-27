using Application.DTOs;

namespace Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetAsync(int id);
        Task AddAsync(CategoryDTO Dto);
        Task UpdateAsync(CategoryDTO Dto);
        Task DeleteAsync(int id);
    }
}
