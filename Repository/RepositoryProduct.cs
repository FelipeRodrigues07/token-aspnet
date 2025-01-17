﻿using api_app.Config;
using api_app.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_app.Repository
{
    public class RepositoryProduct : InterfaceProduct
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;  //pegar o contexto

        public RepositoryProduct()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }


        public async Task Add(ProductModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<ProductModel>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(ProductModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<ProductModel>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<ProductModel> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<ProductModel>().FindAsync(Id);
            }
        }

        public async Task<List<ProductModel>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<ProductModel>().ToListAsync();
            }
        }

        public async Task Update(ProductModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<ProductModel>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }
    }
}
