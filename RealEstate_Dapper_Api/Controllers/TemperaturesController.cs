using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate_Dapper_Api.Dtos.TemperatureDtos;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Repositories.TemperatureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly IHubContext<SignalRHub> _hubContext;

        public TemperaturesController(ITemperatureRepository temperatureRepository, IHubContext<SignalRHub> hubContext)
        {
            _temperatureRepository = temperatureRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> TemperaturesList()
        {
            var values = await _temperatureRepository.GetAllTemperatureAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTemperature(CreateTemperatureDto createTemperatureDto)
        {

            _temperatureRepository.CreateTemperature(createTemperatureDto);
            var result = _temperatureRepository.ActiveTemperatureCount();
            var result1 = _temperatureRepository.PassiveTemperatureCount();
            var result2 = _temperatureRepository.AverageTemperatureCount();
            var result3 = _temperatureRepository.HighTemperature();
            var result4 = _temperatureRepository.LowTemperature();
            var result5 = _temperatureRepository.NewTemperature();
            var result6 = _temperatureRepository.LastTemperature();
            var result7 = _temperatureRepository.TemperatureNameMax();
            var result8 = _temperatureRepository.TemperatureNameMin();
            var result9 = _temperatureRepository.TemperatureDifference();
            _hubContext.Clients.All.SendAsync("ReceiveActiveTemperatureCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceivePassiveTemperatureCount", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveAverageTemperatureCount", result2);
            _hubContext.Clients.All.SendAsync("ReceiveHighTemperature", result3);
            _hubContext.Clients.All.SendAsync("ReceiveLowTemperature", result4);
            _hubContext.Clients.All.SendAsync("ReceiveNewTemperature", result5);
            _hubContext.Clients.All.SendAsync("ReceiveLastTemperature", result6);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMax", result7);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMin", result8);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureDifference", result9);
            return Ok("Sıcaklık Başarılı Bir Şekilde Eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperatures(Guid id)
        {
            await _temperatureRepository.DeleteTemperature(id);
            var result = _temperatureRepository.ActiveTemperatureCount();
            var result1 = _temperatureRepository.PassiveTemperatureCount();
            var result2 = _temperatureRepository.AverageTemperatureCount();
            var result3 = _temperatureRepository.HighTemperature();
            var result4 = _temperatureRepository.LowTemperature();
            var result5 = _temperatureRepository.NewTemperature();
            var result6 = _temperatureRepository.LastTemperature();
            var result7 = _temperatureRepository.TemperatureNameMax();
            var result8 = _temperatureRepository.TemperatureNameMin();
            var result9 = _temperatureRepository.TemperatureDifference();
            _hubContext.Clients.All.SendAsync("ReceiveActiveTemperatureCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceivePassiveTemperatureCount", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveAverageTemperatureCount", result2);
            _hubContext.Clients.All.SendAsync("ReceiveHighTemperature", result3);
            _hubContext.Clients.All.SendAsync("ReceiveLowTemperature", result4);
            _hubContext.Clients.All.SendAsync("ReceiveNewTemperature", result5);
            _hubContext.Clients.All.SendAsync("ReceiveLastTemperature", result6);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMax", result7);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMin", result8);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureDifference", result9);
            return Ok("Sıcaklık Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemperature(UpdateTemperatureDto updateTemperatureDto)
        {
            _temperatureRepository.UpdateTemperature(updateTemperatureDto);
            var result = _temperatureRepository.ActiveTemperatureCount();
            var result1 = _temperatureRepository.PassiveTemperatureCount();
            var result2 = _temperatureRepository.AverageTemperatureCount();
            var result3 = _temperatureRepository.HighTemperature();
            var result4 = _temperatureRepository.LowTemperature();
            var result5 = _temperatureRepository.NewTemperature();
            var result6 = _temperatureRepository.LastTemperature();
            var result7 = _temperatureRepository.TemperatureNameMax();
            var result8 = _temperatureRepository.TemperatureNameMin();
            var result9 = _temperatureRepository.TemperatureDifference();
            _hubContext.Clients.All.SendAsync("ReceiveActiveTemperatureCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceivePassiveTemperatureCount", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveAverageTemperatureCount", result2);
            _hubContext.Clients.All.SendAsync("ReceiveHighTemperature", result3);
            _hubContext.Clients.All.SendAsync("ReceiveLowTemperature", result4);
            _hubContext.Clients.All.SendAsync("ReceiveNewTemperature", result5);
            _hubContext.Clients.All.SendAsync("ReceiveLastTemperature", result6);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMax", result7);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMin", result8);
            _hubContext.Clients.All.SendAsync("ReceiveTemperatureDifference", result9);
            return Ok("Sıcaklık Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("ActiveTemperatureCount")]//aktif sıcaklık sayısı
        public async Task<ActionResult> ActiveTemperatureCount()
        {
            var result = _temperatureRepository.ActiveTemperatureCount();
            await _hubContext.Clients.All.SendAsync("ReceiveActiveTemperatureCount", result);
            return Ok(result);
        }

        [HttpGet("PassiveTemperatureCount")]//pasif sıcaklık sayısı
        public async Task<ActionResult> PassiveTemperatureCount()
        {
            var result = _temperatureRepository.PassiveTemperatureCount();
            await _hubContext.Clients.All.SendAsync("ReceivePassiveTemperatureCount", result);
            return Ok(result);
        }

        [HttpGet("AverageTemperatureCount")]//ortalama sıcaklık
        public async Task<ActionResult> AverageTemperatureCount()
        {
            var result = _temperatureRepository.AverageTemperatureCount();
            await _hubContext.Clients.All.SendAsync("ReceiveAverageTemperatureCount", result);
            return Ok(result);
        }

        [HttpGet("HighTemperature")]//en yüksek sıcaklık
        public async Task<ActionResult> HighTemperature()
        {
            var result = _temperatureRepository.HighTemperature();
            await _hubContext.Clients.All.SendAsync("ReceiveHighTemperature", result);
            return Ok(result);
        }

        [HttpGet("LowTemperature")]//en yüksek sıcaklık
        public async Task<ActionResult> LowTemperature()
        {
            var result = _temperatureRepository.LowTemperature();
            await _hubContext.Clients.All.SendAsync("ReceiveLowTemperature", result);
            return Ok(result);
        }

        [HttpGet("NewTemperature")]//en yeni eklenen sıcaklık
        public async Task<ActionResult> NewTemperature()
        {
            var result = _temperatureRepository.NewTemperature();
            await _hubContext.Clients.All.SendAsync("ReceiveNewTemperature", result);
            return Ok(result);
        }

        [HttpGet("LastTemperature")]//en son eklenen sıcaklık
        public async Task<ActionResult> LastTemperature()
        {
            var result = _temperatureRepository.LastTemperature();
            await _hubContext.Clients.All.SendAsync("ReceiveLastTemperature", result);
            return Ok(result);
        }

        [HttpGet("TemperatureDifference")]//en yüksek ve en düşük değer arasındaki fark
        public async Task<ActionResult> TemperatureDifference()
        {
            var result = _temperatureRepository.TemperatureDifference();
            await _hubContext.Clients.All.SendAsync("ReceiveTemperatureDifference", result);
            return Ok(result);
        }

        [HttpGet("TemperatureNameMax")]//en çok sıcaklık verisi girilen isim
        public async Task<ActionResult> TemperatureNameMax()
        {
            var result = _temperatureRepository.TemperatureNameMax();
            await _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMax", result);
            return Ok(result);
        }

        [HttpGet("TemperatureNameMin")]//en az sıcaklık verisi girilen isim
        public async Task<ActionResult> TemperatureNameMin()
        {
            var result = _temperatureRepository.TemperatureNameMin();
            await _hubContext.Clients.All.SendAsync("ReceiveTemperatureNameMin", result);
            return Ok(result);
        }
    }
}