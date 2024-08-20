namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int ActiveCategoryCount();
        int ActiveEmployeeCount();
        int ApartmentCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        int AverageRoomCount();
        int CategoryCount();
        string CategoryNameByMaxProductCount();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        string EmployeeNameByMaxProductCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int PassiveCategoryCount();
        int ProductCount();
    }
}
