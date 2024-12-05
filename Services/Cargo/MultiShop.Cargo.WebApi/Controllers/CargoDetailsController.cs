using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }


        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertCargoDetail(CreateCargoDetailDtos createCargoDetailDtos)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
              SenderCustomer = createCargoDetailDtos.SenderCustomer,

              ReceiverCustomer = createCargoDetailDtos.ReceiverCustomer,

              Barcode = createCargoDetailDtos.Barcode,

              CargoCompanyId = createCargoDetailDtos.CargoCompanyId,
            };

            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDtos updateCargoDetailDtos)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDtos.CargoDetailId,

                SenderCustomer = updateCargoDetailDtos.SenderCustomer,

                ReceiverCustomer = updateCargoDetailDtos.ReceiverCustomer,

                Barcode = updateCargoDetailDtos.Barcode,

                CargoCompanyId = updateCargoDetailDtos.CargoCompanyId,
            };

            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

    }
}
