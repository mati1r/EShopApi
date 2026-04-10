using System.ComponentModel.DataAnnotations;

namespace Core.Models.EShop;

public class Address(
    string city,
    string street,
    int houseNumber,
    string postalCode,
    string phoneNumber,
    string phonePrefix,
    int? apartmentNumber = null,
    int id = default
)
{
    public int Id { get; private set; } = id;

    [MaxLength(100)]
    public string City { get; private set; } = city;

    [MaxLength(100)]
    public string Street { get; private set; } = street;

    [Range(1, 9999)]
    public int HouseNumber { get; private set; } = houseNumber;

    [Range(1, 9999)]
    public int? ApartmentNumber { get; private set; } = apartmentNumber;

    [Length(4, 12)]
    public string PostalCode { get; private set; } = postalCode;

    [Length(1, 3)]
    public string PhonePrefix { get; private set; } = phonePrefix;

    [Length(6,15)]
    public string PhoneNumber { get; private set; } = phoneNumber;

    public ICollection<User> Users { get; private set; } = [];
    public ICollection<History> Histories { get; private set; } = [];

    public void Update(string city, string street, string postalCode, string phonePrefix, string phoneNumber, int houseNumber, int? apartmentNumber)
    {
        City = city;
        Street = street;
        PostalCode = postalCode;
        PhonePrefix = phonePrefix;
        PhoneNumber = phoneNumber;
        HouseNumber = houseNumber;
        ApartmentNumber = apartmentNumber;
    }
}

