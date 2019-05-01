using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        public ActionResult GetServicesTypes()
        {
            return Ok(_serviceTypeService.GetAllAServiceTypes());
        }

        [HttpGet]
        [Route("getservicetype")]
        public ActionResult GetServiceType(Guid serviceTypeId)
        {
            return Ok(_serviceTypeService.GetServiceType(serviceTypeId));
        }   

        [HttpPost]
        [Route("create")]
        public ActionResult InsertServiceType([FromBody] ServiceTypeModel model)
        {
            try
            {
                var serviceType =
                    SimpleMapper.Mapper.Map<ServiceTypeModel, MedicalExamination.BLL.ServiceTypeModel>(model);

                _serviceTypeService.CreateServiceType(serviceType);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateServiceType([FromBody] ServiceTypeModel model)
        {
            try
            {
                var serviceType =
                    SimpleMapper.Mapper.Map<ServiceTypeModel, MedicalExamination.BLL.ServiceTypeModel>(model);

                _serviceTypeService.UpdateServiceType(serviceType);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteServiceType([FromBody] ServiceTypeModel model)
        {
            try
            {
                var serviceType =
                    SimpleMapper.Mapper.Map<ServiceTypeModel, MedicalExamination.BLL.ServiceTypeModel>(model);

                _serviceTypeService.DeleteServiceType(serviceType);

                return Ok();
            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
