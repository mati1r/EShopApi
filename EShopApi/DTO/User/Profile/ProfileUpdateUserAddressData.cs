using System.ComponentModel.DataAnnotations;

namespace Application.DTO.User.Profile;

public class ProfileUpdateUserAddressData : IValidatableObject
{
    [MaxLength(100)]
    public string City { get; set; }

    [MaxLength(100)]
    public string Street { get; set; }

    [Length(4, 12)]
    public string PostalCode { get; set; }

    [Length(1, 3)]
    public string PhonePrefix { get; set; }

    [Length(6, 15)]
    public string PhoneNumber { get; set; }

    [Range(1, int.MaxValue)]
    public int HouseNumber { get; set; }

    [Range(1, int.MaxValue)]
    public int? ApartmentNumber { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(PhoneNumber) && !PhoneNumber.All(char.IsDigit))
        {
            yield return new ValidationResult(
                "Incorrect phone number - only digits are allowed.",
                [nameof(PhoneNumber)]
            );
        }

        if (!string.IsNullOrEmpty(PhonePrefix) && !PhonePrefix.All(char.IsDigit))
        {
            yield return new ValidationResult(
                "Incorrect phone prefix - only digits are allowed.",
                [nameof(PhonePrefix)]
            );
        }
    }
}
