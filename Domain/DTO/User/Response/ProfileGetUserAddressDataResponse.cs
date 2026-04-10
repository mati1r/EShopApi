namespace Core.DTO.User.Response;

public class ProfileGetUserAddressDataResponse
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? PhonePrefix { get; set; }
    public string? PhoneNumber { get; set; }
    public int? HouseNumber { get; set; }
    public int? ApartmentNumber { get; set; }
}
