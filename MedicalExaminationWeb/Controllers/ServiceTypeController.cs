using System;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class ServiceTypeController : Controller
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        public ActionResult ServiceTypes()
        {
            var servicesModels = _serviceTypeService.GetAllAServiceTypes().Map<ServiceTypeModel, ServiceViewModel>();

            return View(servicesModels);
        }

        [HttpGet]
        public ActionResult ServiceType(Guid serviceTypeId)
        {
            var service = _serviceTypeService.GetServiceType(serviceTypeId);
        
            var serviceModel = SimpleMapper.Mapper.Map<ServiceTypeModel, ServiceViewModel>(service);
        
            return View(serviceModel);
        }   

        [HttpGet]
        public ActionResult CreateServiceType()
        {
            var model = new ServiceViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateServiceType(ServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceType =
                SimpleMapper.Mapper.Map<ServiceViewModel, MedicalExamination.BLL.ServiceTypeModel>(model);

            _serviceTypeService.CreateServiceType(serviceType);

            return RedirectToAction("ServiceTypes");
        }

        [HttpPost]
        public ActionResult UpdateServiceType(ServiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View("ServiceType", model);
            
            var serviceType =
                SimpleMapper.Mapper.Map<ServiceViewModel, MedicalExamination.BLL.ServiceTypeModel>(model);

            _serviceTypeService.UpdateServiceType(serviceType);

            return RedirectToAction("ServiceTypes");
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteServiceType([FromBody] ServiceViewModel model)
        {
            try
            {
                var serviceType =
                    SimpleMapper.Mapper.Map<ServiceViewModel, MedicalExamination.BLL.ServiceTypeModel>(model);

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
