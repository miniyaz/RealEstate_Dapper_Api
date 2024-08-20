﻿namespace RealEstate_Dapper_UI.Dtos.TemperaturesDtos
{
    public class ResultTemperatureDto
    {
        public Guid TemperatureID { get; set; }  // uniqueidentifier türü için Guid kullanılır !!!!
        public string TemperatureName { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public bool Status { get; set; }
    }
}