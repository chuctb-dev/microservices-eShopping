using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopping.SharedKernel.Entities
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }

    public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class EntityWithAuditBase<TId> : AuditEntityBase where TId : struct, IEquatable<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class AuditEntityBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}