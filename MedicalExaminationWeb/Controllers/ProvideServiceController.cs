using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class ProvideServiceController : ControllerBase
    {
        private readonly IProvideServiceService _provideServiceService;

        public ProvideServiceController(IProvideServiceService provideServiceService)
        {
            _provideServiceService = provideServiceService;
        }

        [HttpGet]
        public ActionResult GetAllProvideServices()
        {
            return Ok(_provideServiceService.GetAllProvideServices());
        }

        [HttpGet]
        [Route("getprovideservice")]
        public ActionResult GetProvideService(Guid id)
        {
            return Ok(_provideServiceService.GetProvideService(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateProvideService([FromBody] ProvideServiceModel model)
        {
            try
            {
                var provideService =
                    SimpleMapper.Mapper.Map<ProvideServiceModel, MedicalExamination.BLL.ProvideServiceModel>(model);

                _provideServiceService.CreateProvideService(provideService);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateProvideService([FromBody] ProvideServiceModel model)
        {
            try
            {
                var provideService =
                    SimpleMapper.Mapper.Map<ProvideServiceModel, MedicalExamination.BLL.ProvideServiceModel>(model);

                _provideServiceService.UpdateProvideService(provideService);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteProvideService([FromBody] ProvideServiceModel model)
        {
            try
            {
                var provideService =
                    SimpleMapper.Mapper.Map<ProvideServiceModel, MedicalExamination.BLL.ProvideServiceModel>(model);

                _provideServiceService.DeleteProvideService(provideService);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
