using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public ActionResult GetWorkers()
        {
            var workers = _workerService.GetAllWorkers();

            return Ok(workers);
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
        public  ActionResult CreateWorker([FromBody] WorkerModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonModel, MedicalExamination.BLL.PersonModel>(model.Person);

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
        public ActionResult UpdateWorker([FromBody] WorkerModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonModel, MedicalExamination.BLL.PersonModel>(model.Person); 

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
        public ActionResult DeleteWorker([FromBody] WorkerModel model)
        {
            try
            {
                var worker = SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model);
                worker.Person = SimpleMapper.Mapper.Map<PersonModel, MedicalExamination.BLL.PersonModel>(model.Person);

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
