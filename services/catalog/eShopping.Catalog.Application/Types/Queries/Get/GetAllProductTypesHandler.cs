using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Types.Queries.Get
{
    public class GetAllProductTypesHandler(IProductTypeRepository productTypeRepository) : IQueryHandler<GetAllProductTypesQuery, Result<List<ProductTypeDto>>>
    {
        public async Task<Result<List<ProductTypeDto>>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await productTypeRepository.GetAllTypes();
            var typeDtos = CatalogMapper.Mapper.Map<List<ProductTypeDto>>(types);
            return new Result<List<ProductTypeDto>>(typeDtos);
        }
    }
}