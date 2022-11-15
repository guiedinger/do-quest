using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;

namespace Do.Quest.Infra.Data.Conventions
{
    internal class IgnoreValidationResultConvention : ConventionBase, IMemberMapConvention
    {
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberName == "ValidationResult")
                memberMap.SetShouldSerializeMethod(o => false);
        }
    }
}
