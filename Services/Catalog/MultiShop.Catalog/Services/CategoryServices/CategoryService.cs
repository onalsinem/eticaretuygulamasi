using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Security.Cryptography.X509Certificates;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            //MongoDB sunucusuna bağlantı kurmak için kullanılır.
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            //belirtilen isimdeki veritabanına erişim sağlar.
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            //Bu satırda, _categoryCollection değişkenine Category türündeki koleksiyon atanır.
            //Bu koleksiyon, veritabanında kategori verilerini saklamak için kullanılır
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            //AutoMapper kütüphanesini kullanarak CreateCategoryDto nesnesini Category türüne dönüştürüyor.
            //*AutoMapper, CreateCategoryDto içinde tanımlı olan verileri (Name, Description, vb.),
            //Category sınıfına ait ilgili alanlarla otomatik olarak eşleştirir ve Category türünden bir nesne oluşturur.
            var values = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(values);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefault();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
        {
            var values = await _categoryCollection.Find<Category>(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
        }

       
    }
}
