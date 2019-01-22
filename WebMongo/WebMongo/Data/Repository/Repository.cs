using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMongo.Models;

namespace WebMongo.Data
{
    public class Repository
    {
        MobileContext newDB = new MobileContext();
        // обращаемся к коллекции Phones
        private IMongoCollection<Phone> Phones
        {
            get { return newDB.database.GetCollection<Phone>("Phones"); }
        }
        // получаем все документы, используя критерии фальтрации
        public async Task<IEnumerable<Phone>> GetPhones(int? minPrice, int? maxPrice, string name)
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<Phone>();
            var filter = builder.Empty; // фильтр для выборки всех документов
                                        // фильтр по имени
            if (!String.IsNullOrWhiteSpace(name))
            {
                filter = filter & builder.Regex("Name", new BsonRegularExpression(name));
            }
            if (minPrice.HasValue)  // фильтр по минимальной цене
            {
                filter = filter & builder.Gte("Price", minPrice.Value);
            }
            if (maxPrice.HasValue)  // фильтр по максимальной цене
            {
                filter = filter & builder.Lte("Price", maxPrice.Value);
            }

            return await Phones.Find(filter).ToListAsync();
        }

        // получаем один документ по id
        public async Task<Phone> Read(string id)
        {
            return await Phones.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        // добавление документа
        public async Task Create(Phone p)
        {
            await Phones.InsertOneAsync(p);
        }
        // обновление документа
        public async Task Update(Phone p)
        {
            await Phones.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        // удаление документа
        public async Task Delete(string id)
        {
            await Phones.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
        // получение изображения
        public async Task<byte[]> GetImage(string id)
        {
            return await newDB.gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }
        // сохранение изображения
        public async Task StoreImage(string id, Stream imageStream, string imageName)
        {
            Phone p = await Read(id);
            if (p.HasImage())
            {
                // если ранее уже была прикреплена картинка, удаляем ее
                await newDB.gridFS.DeleteAsync(new ObjectId(p.ImageId));
            }
            // сохраняем изображение
            ObjectId imageId = await newDB.gridFS.UploadFromStreamAsync(imageName, imageStream);
            // обновляем данные по документу
            p.ImageId = imageId.ToString();
            var filter = Builders<Phone>.Filter.Eq("_id", new ObjectId(p.Id));
            var update = Builders<Phone>.Update.Set("ImageId", p.ImageId);
            await Phones.UpdateOneAsync(filter, update);
        }
    }
}
