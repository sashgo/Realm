using Realms;

namespace Realm_.Models
{
    public class ItemModel : RealmObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}