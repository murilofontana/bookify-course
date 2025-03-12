using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(Guid id, Name name, Description description, Address address, Money price, Money cleaningFeeAmount, DateTime? lastBookedOnUtc, List<Amenity> amenities) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFeeAmount = cleaningFeeAmount;
        LastBookedOnUtc = lastBookedOnUtc;
        Amenities = amenities;
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public Money CleaningFeeAmount { get; private set; }

    public DateTime? LastBookedOnUtc { get; private set; }

    public List<Amenity> Amenities { get; private set; } = new List<Amenity>();
}
