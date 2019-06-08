using System;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IPositionTypeService _positionTypeService;
        private readonly IPassportIssuePlaceTypeService _passportIssuePlaceService;

        public WorkerController(IWorkerService workerService, IPositionTypeService positionTypeService, IPassportIssuePlaceTypeService passportIssuePlaceService)
        {
            _workerService = workerService;
            _positionTypeService = positionTypeService;
            _passportIssuePlaceService = passportIssuePlaceService;
        }

        [HttpGet]
        public ActionResult Workers()
        {
            var workers = _workerService.GetAllWorkers().ToArray();

            var models = workers.Map<WorkerModel, WorkerViewModel>().ToArray();

            for (int i = 0; i < models.Length; i++)
            {
                models[i].Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(workers[i].Person);
                models[i].Positions = workers[i].Positions.Map<PositionModel, PositionViewModel>();
                models[i].PositionTypes = workers[i].PositionTypes.Map<PositionTypeModel, PositionTypeViewModel>();
            }

            if (TempData.ContainsKey("ErrorMessage"))
            {
                ModelState.AddModelError("", TempData["ErrorMessage"] as string);
            }

            return View(models);
        }

        [HttpGet]
        public ActionResult GetWorker(int workerId)
        {
            var worker = _workerService.GetWorker(workerId);

            var model = SimpleMapper.Mapper.Map<WorkerModel, WorkerViewModel>(worker);
            model.Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(worker.Person);
            model.Person.SelectedPassportIssuePlaceId = worker.Person.PassportIssuePlaceId;

            var passportIssuePlaces = _passportIssuePlaceService.GetAllPassportIssuePlaces();
            model.Person.PassportIssuePlaces = new SelectList(passportIssuePlaces, "Id", "Name");

            model.PositionsList = new SelectList(_positionTypeService.GetAllPositionTypes(), "Id", "Name");
            model.SelectedPosition = worker.Position;
            

            return View("Worker", model);
        }

        [HttpGet]
        public ActionResult CreateWorker()
        {
            var worker = new WorkerViewModel
            {
                Person = new PersonViewModel()
            };

            var positions = _positionTypeService.GetAllPositionTypes();

            worker.PositionsList = new SelectList(positions, "Id", "Name");
            worker.SelectedPosition = positions.First().Id;

            var passportIssuePlaces = _passportIssuePlaceService.GetAllPassportIssuePlaces();
            worker.Person.PassportIssuePlaces = new SelectList(passportIssuePlaces, "Id", "Name");
            worker.Person.SelectedPassportIssuePlaceId = passportIssuePlaces.First().Id;

            return View("CreateWorker", worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorker(WorkerViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var positions = _positionTypeService.GetAllPositionTypes();

                model.PositionsList = new SelectList(positions, "Id", "Name");
                model.SelectedPosition = positions.First().Id;

                var passportIssuePlaces = _passportIssuePlaceService.GetAllPassportIssuePlaces();
                
                model.Person.PassportIssuePlaces = new SelectList(passportIssuePlaces, "Id", "Name");

                return View("CreateWorker", model);
            }

            var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model);
            worker.Person = SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);
            worker.Position = model.SelectedPosition;
            worker.Person.PassportIssuePlaceId = model.Person.SelectedPassportIssuePlaceId;

                _workerService.CreateWorker(worker);

            return RedirectToAction("Workers");
        }

        [HttpPost]
        public ActionResult UpdateWorker(WorkerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var positions = _positionTypeService.GetAllPositionTypes();

                model.PositionsList = new SelectList(positions, "Id", "Name");
                model.SelectedPosition = positions.First().Id;

                var passportIssuePlaces = _passportIssuePlaceService.GetAllPassportIssuePlaces();

                model.Person.PassportIssuePlaces = new SelectList(passportIssuePlaces, "Id", "Name");

                return View("Worker", model);
            }

            var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model);
            worker.Person = SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);
            worker.Person.PassportIssuePlaceId = model.Person.SelectedPassportIssuePlaceId;
            worker.Position = model.SelectedPosition;

            _workerService.UpdateWorker(worker);

            return RedirectToAction("Workers");
        }

        [HttpGet]
        public ActionResult DeleteWorker(int workerId)
        {
            try
            {
                var worker = new WorkerModel {PersonId = workerId};

                _workerService.DeleteWorker(worker);

                return RedirectToAction("Workers");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Workers");
            }
        }
    }
}
