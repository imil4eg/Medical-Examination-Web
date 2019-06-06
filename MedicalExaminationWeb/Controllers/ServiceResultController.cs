using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class ServiceResultController : ControllerBase
    {
        private readonly IServiceResultService _serviceResultService;

        public ServiceResultController(IServiceResultService serviceResultService)
        {
            this._serviceResultService = serviceResultService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_serviceResultService.GetAllServiceResults());
        }

        [HttpGet]
        [Route("getserviceresult")]
        public ActionResult GetServiceResult(Guid id)
        {
            return Ok(_serviceResultService.GetServiceResult(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateServiceResult(ServiceResultViewModel model)
        {
            try
            {
                var serviceResult =
                    SimpleMapper.Mapper.Map<ServiceResultViewModel, MedicalExamination.BLL.ServiceResultModel>(model);

                this._serviceResultService.CreateServiceResult(serviceResult);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateServiceResult(ServiceResultViewModel model)
        {
            try
            {
                var serviceResult =
                    SimpleMapper.Mapper.Map<ServiceResultViewModel, MedicalExamination.BLL.ServiceResultModel>(model);

                this._serviceResultService.UpdateServiceResult(serviceResult);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteServiceResult(ServiceResultViewModel model)
        {
            try
            {
                var serviceResult =
                    SimpleMapper.Mapper.Map<ServiceResultViewModel, MedicalExamination.BLL.ServiceResultModel>(model);

                this._serviceResultService.DeleteServiceResult(serviceResult);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
