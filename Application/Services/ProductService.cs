using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        readonly IMapper _mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {            
            this._mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var entities = await productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var entity = await productRepository.GetAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task AddAsync(ProductDTO Dto)
        {
            var product = _mapper.Map<Product>(Dto);
            await productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(ProductDTO Dto)
        {
            var product = _mapper.Map<Product>(Dto);
            await productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {            
            var product = await productRepository.GetAsync(id);
            if (product == null)
                throw new Exception();

            await productRepository.DeleteAsync(product);
        }
    }
}
