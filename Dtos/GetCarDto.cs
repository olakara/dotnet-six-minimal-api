namespace DotNetSixMinimalApi.Dtos;

public class GetCarDto
{
    public int Id { get; set;}
    public string? Vin { get; set; }
    public string? RegistrationNumber { get; set; }
    public int ModelYear { get; set; }
    public string? OwnerName { get; set; }

}