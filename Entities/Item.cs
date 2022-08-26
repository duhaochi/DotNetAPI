
using System;


namespace Catalogs.Entities
{
    public record Item
    {
                            // instead of set here we use init, meaning the var Id can only be set during initialization and can not be changed again once initialized
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price {get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public string TestElem { get; init; }
    }
}