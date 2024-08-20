using Microsoft.AspNetCore.Mvc;//ASP.NET Core MVC kütüphanesini projeye dahil eder.
 //Bu kütüphane, web uygulamaları oluşturmak için kullanılan birçok yararlı sınıf ve metot içerir.
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
//AppUserRepositories isimli bir alt klasörde bulunan sınıfları ve metodları projeye dahil eder.

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]//bu denetleyicinin URL rotasını belirler.
    [ApiController]//bu sınıfın bir API denetleyicisi olduğunu belirtir ve
                   //API'lere özgü bazı davranışları etkinleştirir.
    public class AppUsersController : ControllerBase
    //bu sınıfın ControllerBase sınıfından türetildiğini belirtir.
    //ControllerBase, temel denetleyici işlevlerini sağlar.
    {
        private readonly IAppUserRepository _appUserRepository;
        //Bu değişken, veri tabanıyla ilgili işlemleri gerçekleştirecek.

        public AppUsersController(IAppUserRepository appUserRepository)
        //Bu, sınıfın yapıcı metodudur. IAppUserRepository türünde bir nesne alır ve
        //bu nesneyi _appUserRepository değişkenine atar.
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet]//GET istekleri, genellikle veri almak için kullanılır.
        public async Task<IActionResult>GetAppUserByProductId(int id)//GetAppUserByProductId isimli bir metod tanımlar.
        //Bu metod, int türünde bir id parametresi alır ve bir Task<IActionResult> döner. async anahtar kelimesi, bu metodun asenkron olduğunu belirtir, yani uzun süren işlemleri beklemeden çalışabilir.
        {
            var value = await _appUserRepository.GetAppUserByProductId(id);
            //_appUserRepository üzerinden GetAppUserByProductId metodunu çağırır
            //ve sonucu value değişkenine atar.
            return Ok(value);//HTTP 200 OK durumuyla birlikte value değişkeninin değerini döner.
                             //Bu, başarılı bir yanıtı ifade eder.
        }
    }
}
//Özetle, bu denetleyici, api/appusers rotasına gelen GET isteklerini işler ve
//verilen ürün kimliğine (product ID) göre bir kullanıcı bilgisi döner.
//Bu işlevselliği sağlamak için bir depo (repository) sınıfından yararlanır.