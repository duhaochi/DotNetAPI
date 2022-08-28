namespace Catalog.Repositories{

    public class MongoDbItemsRepository : IItemsRepository{

        public MongoDbItemsRepository(){
            
        }

        Item GetItem(Guid id){
            throw new NotImplementedException();
        }
        IEnumerable<Item> GetItems(){
            throw new NotImplementedException();

        }
        void CreateItem(Item item){
            throw new NotImplementedException();

        }
        void UpdateItem(Item item){
            throw new NotImplementedException();

        }

        void DeleteItem(Guid id){
            throw new NotImplementedException();

        }
    }
}