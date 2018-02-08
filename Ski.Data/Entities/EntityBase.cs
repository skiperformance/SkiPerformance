using SQLite;

namespace Ski.Data.Entities
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}