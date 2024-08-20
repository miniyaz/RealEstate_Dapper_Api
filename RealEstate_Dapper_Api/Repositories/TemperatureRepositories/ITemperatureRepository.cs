using RealEstate_Dapper_Api.Dtos.TemperatureDtos;

namespace RealEstate_Dapper_Api.Repositories.TemperatureRepositories
{
    public interface ITemperatureRepository
    {
        Task<List<ResultTemperatureDto>> GetAllTemperatureAsync();
        //void CreateTemperature(CreateTemperatureDto createTemperatureDto);
        Task CreateTemperature(CreateTemperatureDto createTemperatureDto);
        Task DeleteTemperature(Guid id);
        Task UpdateTemperature(UpdateTemperatureDto updateTemperatureDto);

        int ActiveTemperatureCount();//aktif sıcaklık sayısı
        int PassiveTemperatureCount();//pasif sıcaklık sayısı
        int AverageTemperatureCount();//ortalama sıcaklık
        int HighTemperature();//en yüksek sıcaklık
        int LowTemperature();//en düşük sıcaklık
        int NewTemperature();//ilk sıcaklık
        int LastTemperature();//son sıcaklık
        string TemperatureNameMax();//en fazla sıcaklık adı
        string TemperatureNameMin();// en az sıcaklık adı
        int TemperatureDifference();// sıcaklık farkı ilk ve son arasındaki
    }
}
