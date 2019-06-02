using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class PositionTypeController : Controller
    {
        private readonly IPositionTypeService _positionTypeService;
        private readonly IServiceTypeService _serviceTypeService;

        public PositionTypeController(IPositionTypeService positionTypeService, IServiceTypeService serviceTypeService)
        {
            _positionTypeService = positionTypeService;
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        public ActionResult GetPositionTypes()
        {
            var models = _positionTypeService.GetAllPositionTypes().Map<PositionTypeModel, PositionTypeViewModel>();

            if (TempData.ContainsKey("ErrorMessage"))
            {
                ModelState.AddModelError("", TempData["ErrorMessage"] as string);
            }

            return View("PositionTypes", models);
        }
        
        public ActionResult GetPositionType(Guid id)
        {
            var positionTypes = _positionTypeService.GetPositionType(id);
            var serviceTypes = _serviceTypeService.GetAllAServiceTypes();

            var model = SimpleMapper.Mapper.Map<PositionTypeModel, PositionTypeViewModel>(positionTypes);
            model.ProvideServices = positionTypes.ProvideServices.Map<ProvideServiceModel, ProvideServiceViewModel>();
            model.ServiceTypes = new MultiSelectList(serviceTypes, "Id", "Name");
            model.SelectedServiceTypes = positionTypes.ServiceTypes.Select(st => st.Id);
        
            return View("PositionType", model);
        }

        [HttpGet]
        public ActionResult CreatePositionType()
        {
            var model = new PositionTypeViewModel();

            var serviceTypes = _serviceTypeService.GetAllAServiceTypes();
            model.ServiceTypes = new MultiSelectList(serviceTypes, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePositionType(PositionTypeViewModel model)
        {
            var positionType =
                SimpleMapper.Mapper.Map<PositionTypeViewModel, MedicalExamination.BLL.PositionTypeModel>(model);

            positionType.ServiceTypes = model.SelectedServiceTypes.Select(s => new ServiceTypeModel {Id = s});
            _positionTypeService.CreatePositionType(positionType);

            return RedirectToAction("GetPositionTypes");
        }

        [HttpPost]
        public ActionResult UpdatePositionType(PositionTypeViewModel model)
        {
            var positionType =
                SimpleMapper.Mapper.Map<PositionTypeViewModel, MedicalExamination.BLL.PositionTypeModel>(model);
            positionType.ServiceTypes = model.SelectedServiceTypes.Select(st => new ServiceTypeModel {Id = st});
            _positionTypeService.UpdatePositionType(positionType);
            return RedirectToAction("GetPositionTypes");
        }

        [HttpGet]
        public ActionResult DeletePositionType(Guid positionId)
        {
            try
            {
                var positionType = new PositionTypeModel {Id = positionId};

                _positionTypeService.DeletePositionType(positionType);

                return RedirectToAction("GetPositionTypes");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("GetPositionTypes");
            }
        }
    }
}
