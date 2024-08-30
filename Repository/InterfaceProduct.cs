using api_app.Entities;

namespace api_app.Repository
{
    public interface InterfaceProduct
    {
        Task Add(ProductModel Objeto);
        Task Update(ProductModel Objeto);
        Task Delete(ProductModel Objeto);
        Task<ProductModel> GetEntityById(int Id);
        Task<List<ProductModel>> List();
    }
}
