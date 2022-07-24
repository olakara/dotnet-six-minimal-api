namespace DotNetSixMinimalApi.Dtos;

public class CreateCarDto
{
    public string? Vin { get; set; }
    public string? RegistrationNumber { get; set; }
    public int ModelYear { get; set; }
    public string? OwnerName { get; set; }
}