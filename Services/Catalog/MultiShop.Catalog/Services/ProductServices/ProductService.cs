﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            //adres
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            //database adı
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            //tablo collection adı
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<GetByIdProductDto> GetGetByIdProductAsync(string id)
        {
            var values = _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefault();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> ResultProductAsync()
        {
            var values= await _productCollection.Find<Product>(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
    }
}
