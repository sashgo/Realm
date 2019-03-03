using Realms;

namespace Realm_.DataModels
{
    public class ItemDataModel : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}