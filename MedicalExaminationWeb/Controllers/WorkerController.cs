using System;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public ActionResult Workers()
        {
            var workers = _workerService.GetAllWorkers().ToArray();

            var models = workers.Map<WorkerModel, WorkerViewModel>().ToArray();

            for (int i = 1; i < workers.Length; i++)
            {
                models[i].Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(workers[i].Person);
                models[i].Positions = workers[i].Positions.Map<PositionModel, PositionViewModel>();
            }

            return View(models);
        }

        [HttpGet]
        [Route("getworker")]
        public ActionResult GetWorker(int workerId)
        {
            var worker = _workerService.GetWorker(workerId);

            return Ok(worker);
        }

        [HttpPost]
        [Route("create")]
        public  ActionResult CreateWorker([FromBody] WorkerViewModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);

                _workerService.CreateWorker(worker);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateWorker([FromBody] WorkerViewModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person); 

                _workerService.UpdateWorker(worker);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteWorker([FromBody] WorkerViewModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);

                _workerService.DeleteWorker(worker);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
