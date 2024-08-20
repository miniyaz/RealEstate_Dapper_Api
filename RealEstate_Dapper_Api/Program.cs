using RealEstate_Dapper_Api.Containers;//projedeki Containers s�n�flar�na eri�imi sa�lar.
using RealEstate_Dapper_Api.Hubs;//projedeki SignalR hub'lar�na eri�imi sa�lar.

var builder = WebApplication.CreateBuilder(args);//yeni bir web uygulamas� olu�turur ve yap�land�rma nesnesini (builder) d�ner.
//Bu nesne, uygulamay� yap�land�rmak i�in kullan�l�r.

// Add services to the container.

builder.Services.ContainerDependencies();//ContainerDependencies y�ntemi �a�r�larak gerekli ba��ml�l�klar
//DI (Dependency Injection) konteynerine eklenir.

builder.Services.AddCors(opt =>//CORS (Cross-Origin Resource Sharing) politikas� ekler
{//Bu yap�land�rma, farkl� kaynaklardan (domain) gelen HTTP isteklerinin kabul edilip edilmeyece�ini kontrol eder.
    opt.AddPolicy("CorsPolicy", builder =>//CorsPolicy" ad�nda bir CORS politikas� tan�mlar.
    {
        builder.AllowAnyHeader()//Herhangi bir ba�l��a izin verir. Farkl� kaynaklardan gelen istekler herhangi bir ba�l�k ile gelebilir.
               .AllowAnyMethod()//Bu sat�r, t�m HTTP metodlar�na (GET, POST, PUT, DELETE vb.) izin verir.
               .SetIsOriginAllowed((host) => true)// gelen iste�in kayna�� ne olursa olsun bu da her kayna�a izin verildi�i anlam�na gelir.
               .AllowCredentials();//Kimlik bilgilerini i�eren isteklerin yap�lmas�na izin verir.
                //Bu, �erezler (cookies), HTTP kimlik do�rulama bilgileri veya SSL sertifikalar� gibi bilgilerin g�nderilmesine izin verir.
    });
});
builder.Services.AddHttpClient();//HTTP istekleri yapabilirsiniz.
builder.Services.AddSignalR();//SignalR hizmetini ekler, bu da ger�ek zamanl� web i�levselli�i sa�lar.


builder.Services.AddControllers();//MVC (Model-View-Controller) kontrollerini hizmete ekler. Bu, API kontrollerinin �al��abilmesi i�in gereklidir.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<SignalRHub>();//Bu metot, SignalRHub s�n�f�n�n bir singleton olarak servis koleksiyonuna eklenmesini sa�lar.
//Singleton: Singleton, belirli bir servis i�in uygulama �mr� boyunca tek bir �rne�in (instance) olu�turulaca�� anlam�na gelir.
//Yani, uygulama �al��t��� s�rece SignalRHub s�n�f�n�n yaln�zca bir �rne�i olacak ve her yerde bu tek �rnek kullan�lacak.

builder.Services.AddEndpointsApiExplorer();//API u� noktalar�n� ke�fetmek i�in kullan�l�r.
builder.Services.AddSwaggerGen();//Swagger/OpenAPI deste�ini ekler. Swagger, API dok�mantasyonu ve test etme arac� sa�lar.


var app = builder.Build();//Uygulama yap�land�rmas�n� tamamlar ve �al��t�r�labilir bir uygulama olu�turur.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())// Uygulaman�n geli�tirme ortam�nda olup olmad���n� kontrol eder.
{
    app.UseSwagger();//Swagger middleware'ini kullan�r, b�ylece API d�k�mantasyonuna eri�ebilirsiniz.
    app.UseSwaggerUI();//Swagger UI'yi kullan�r, bu da API d�k�mantasyonunu g�rsel olarak g�r�nt�ler.
}

app.UseCors("CorsPolicy");//Daha �nce tan�mlanan "CorsPolicy" politikas�n� kullan�r.

app.UseHttpsRedirection();//HTTP isteklerini HTTPS'ye y�nlendirir, b�ylece daha g�venli bir ba�lant� sa�lar.

app.UseAuthorization();//Yetkilendirme middleware'ini kullan�r. Bu, kullan�c�lar�n belirli kaynaklara eri�imi olup olmad���n� kontrol eder.

app.MapControllers();// API kontrolc�lerini u� noktalara (endpoints) haritalar.
app.MapHub<SignalRHub>("/signalrhub");//SignalR hub'�n� "/signalrhub" u� noktas�na haritalar. Bu, SignalR ba�lant�lar�n� dinler.
//A��klama
//localhost:1234/swagger/category/index
//localhost:1234/signalrhub

app.Run();//Uygulamay� �al��t�r�r ve gelen istekleri dinlemeye ba�lar.