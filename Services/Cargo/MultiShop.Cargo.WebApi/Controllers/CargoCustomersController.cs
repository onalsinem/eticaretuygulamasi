using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System.Xml.Linq;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values= _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertCargoCustomer(CreateCargoCustomerDtos createCargoCustomerDtos)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDtos.Name,

                Surname= createCargoCustomerDtos.Surname,

                Email= createCargoCustomerDtos.Email,

                Phone= createCargoCustomerDtos.Phone,

                District= createCargoCustomerDtos.District,

                Address= createCargoCustomerDtos.Address,

                City= createCargoCustomerDtos.City,
            };
            _cargoCustomerService.TInsert(cargoCustomer);
             return Ok("Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,

                Name = updateCargoCustomerDto.Name,

                Surname = updateCargoCustomerDto.Surname,

                Email = updateCargoCustomerDto.Email,

                Phone = updateCargoCustomerDto.Phone,

                District = updateCargoCustomerDto.District,

                Address = updateCargoCustomerDto.Address,

                City = updateCargoCustomerDto.City,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
             _cargoCustomerService.TDelete(id);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }
    }
}
