using System.ComponentModel.DataAnnotations;

namespace Core.Models.EShop;

public class Address(
    string city,
    string street,
    int houseNumber,
    string postalCode,
    string phoneNumber,
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

    [Length(6, 6)]
    public string PostalCode { get; private set; } = postalCode;

    [Length(9,9)]
    public string PhoneNumber { get; private set; } = phoneNumber;

    public ICollection<User> Users { get; private set; } = [];
    public ICollection<History> Histories { get; private set; } = [];
}

