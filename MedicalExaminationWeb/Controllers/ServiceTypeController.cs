using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            serviceModel.Periodicity = GetDisplayNamesForProcedurePeriodicity();
            serviceModel.SelectedPeriodicity = (int) service.Periodicity;
        
            return View(serviceModel);
        }   

        [HttpGet]
        public ActionResult CreateServiceType()
        {
            var model = new ServiceViewModel();
            model.Periodicity = GetDisplayNamesForProcedurePeriodicity();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateServiceType(ServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Periodicity = GetDisplayNamesForProcedurePeriodicity();
                return View(model);
            }

            var serviceType =
                SimpleMapper.Mapper.Map<ServiceViewModel, MedicalExamination.BLL.ServiceTypeModel>(model);
            serviceType.Periodicity = (MedicalExamination.Entities.ProcedurePeriodicity) model.SelectedPeriodicity;

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

        [NonAction]
        private static SelectList GetDisplayNamesForProcedurePeriodicity()
        {
            var periodicityValues = Enum.GetValues(typeof(ProcedurePeriodicity));

            var displayAttributes = new List<SelectListItem>();
            foreach (var periodicityValue in periodicityValues)
            {
                displayAttributes.Add(new SelectListItem{Value = ((int)periodicityValue).ToString(), Text = ((ProcedurePeriodicity)(int)periodicityValue).GetDisplayName() });
            }
            return new SelectList(displayAttributes, "Value", "Text", displayAttributes.First().Value);
        }
    }
}
