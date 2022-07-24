namespace DotNetSixMinimalApi.Models
{
    public class Car
    {
        public int Id { get; set;}
        public string? Vin { get; set; }
        public string? RegistrationNumber { get; set; }
        public int ModelYear { get; set; }
        public string? OwnerName { get; set; }
    }

}