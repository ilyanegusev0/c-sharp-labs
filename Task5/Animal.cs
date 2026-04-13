using System.Text.Json.Serialization;

namespace Task5
{
    [JsonDerivedType(typeof(Dog), typeDiscriminator: "dog")]
    [JsonDerivedType(typeof(Cat), typeDiscriminator: "cat")]
    internal abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }
    }
}
