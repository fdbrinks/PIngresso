
using System.Text.Json.Serialization;

namespace PIngresso.Models
{
    public abstract class Entity
    {
        [JsonIgnore]
        public Guid Id { get;set;}
    }
}