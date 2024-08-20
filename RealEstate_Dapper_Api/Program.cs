using RealEstate_Dapper_Api.Containers;//projedeki Containers sýnýflarýna eriþimi saðlar.
using RealEstate_Dapper_Api.Hubs;//projedeki SignalR hub'larýna eriþimi saðlar.

var builder = WebApplication.CreateBuilder(args);//yeni bir web uygulamasý oluþturur ve yapýlandýrma nesnesini (builder) döner.
//Bu nesne, uygulamayý yapýlandýrmak için kullanýlýr.

// Add services to the container.

builder.Services.ContainerDependencies();//ContainerDependencies yöntemi çaðrýlarak gerekli baðýmlýlýklar
//DI (Dependency Injection) konteynerine eklenir.

builder.Services.AddCors(opt =>//CORS (Cross-Origin Resource Sharing) politikasý ekler
{//Bu yapýlandýrma, farklý kaynaklardan (domain) gelen HTTP isteklerinin kabul edilip edilmeyeceðini kontrol eder.
    opt.AddPolicy("CorsPolicy", builder =>//CorsPolicy" adýnda bir CORS politikasý tanýmlar.
    {
        builder.AllowAnyHeader()//Herhangi bir baþlýða izin verir. Farklý kaynaklardan gelen istekler herhangi bir baþlýk ile gelebilir.
               .AllowAnyMethod()//Bu satýr, tüm HTTP metodlarýna (GET, POST, PUT, DELETE vb.) izin verir.
               .SetIsOriginAllowed((host) => true)// gelen isteðin kaynaðý ne olursa olsun bu da her kaynaða izin verildiði anlamýna gelir.
               .AllowCredentials();//Kimlik bilgilerini içeren isteklerin yapýlmasýna izin verir.
                //Bu, çerezler (cookies), HTTP kimlik doðrulama bilgileri veya SSL sertifikalarý gibi bilgilerin gönderilmesine izin verir.
    });
});
builder.Services.AddHttpClient();//HTTP istekleri yapabilirsiniz.
builder.Services.AddSignalR();//SignalR hizmetini ekler, bu da gerçek zamanlý web iþlevselliði saðlar.


builder.Services.AddControllers();//MVC (Model-View-Controller) kontrollerini hizmete ekler. Bu, API kontrollerinin çalýþabilmesi için gereklidir.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<SignalRHub>();//Bu metot, SignalRHub sýnýfýnýn bir singleton olarak servis koleksiyonuna eklenmesini saðlar.
//Singleton: Singleton, belirli bir servis için uygulama ömrü boyunca tek bir örneðin (instance) oluþturulacaðý anlamýna gelir.
//Yani, uygulama çalýþtýðý sürece SignalRHub sýnýfýnýn yalnýzca bir örneði olacak ve her yerde bu tek örnek kullanýlacak.

builder.Services.AddEndpointsApiExplorer();//API uç noktalarýný keþfetmek için kullanýlýr.
builder.Services.AddSwaggerGen();//Swagger/OpenAPI desteðini ekler. Swagger, API dokümantasyonu ve test etme aracý saðlar.


var app = builder.Build();//Uygulama yapýlandýrmasýný tamamlar ve çalýþtýrýlabilir bir uygulama oluþturur.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())// Uygulamanýn geliþtirme ortamýnda olup olmadýðýný kontrol eder.
{
    app.UseSwagger();//Swagger middleware'ini kullanýr, böylece API dökümantasyonuna eriþebilirsiniz.
    app.UseSwaggerUI();//Swagger UI'yi kullanýr, bu da API dökümantasyonunu görsel olarak görüntüler.
}

app.UseCors("CorsPolicy");//Daha önce tanýmlanan "CorsPolicy" politikasýný kullanýr.

app.UseHttpsRedirection();//HTTP isteklerini HTTPS'ye yönlendirir, böylece daha güvenli bir baðlantý saðlar.

app.UseAuthorization();//Yetkilendirme middleware'ini kullanýr. Bu, kullanýcýlarýn belirli kaynaklara eriþimi olup olmadýðýný kontrol eder.

app.MapControllers();// API kontrolcülerini uç noktalara (endpoints) haritalar.
app.MapHub<SignalRHub>("/signalrhub");//SignalR hub'ýný "/signalrhub" uç noktasýna haritalar. Bu, SignalR baðlantýlarýný dinler.
//Açýklama
//localhost:1234/swagger/category/index
//localhost:1234/signalrhub

app.Run();//Uygulamayý çalýþtýrýr ve gelen istekleri dinlemeye baþlar.