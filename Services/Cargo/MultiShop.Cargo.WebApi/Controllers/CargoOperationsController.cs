using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertCargoOperation(CreateCargoOperationDto createCargoOperationDto )
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
               OperationDate= createCargoOperationDto.OperationDate,

               Barcode =createCargoOperationDto.Barcode,

               Description =createCargoOperationDto.Description,
           
            };

            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperationl(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,

                OperationDate = updateCargoOperationDto.OperationDate,

                Barcode = updateCargoOperationDto.Barcode,

                Description = updateCargoOperationDto.Description
            };

            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperationl(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
    }
}
