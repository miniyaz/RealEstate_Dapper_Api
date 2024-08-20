namespace RealEstate_Dapper_Api.Dtos.TemperatureDtos
{
    public class CreateTemperatureDto
    {
        public string TemperatureName { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public bool Status { get; set; }
    }
}
