using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class ExaminationResultController : ControllerBase
    {
        private readonly IExaminationResultTypeService _examinationResultTypeService;

        public ExaminationResultController(IExaminationResultTypeService examinationResultTypeService)
        {
            _examinationResultTypeService = examinationResultTypeService;
        }

        [HttpGet]
        public ActionResult GetAllExaminationResults()
        {
            return Ok(_examinationResultTypeService.GetAllExaminationResultTypes());
        }

        [HttpGet]
        [Route("getexaminationresult")]
        public ActionResult GetExaminationResult(Guid id)
        {
            return Ok(_examinationResultTypeService.GetExaminationResultType(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateExaminationResult([FromBody] ExaminationResultModel model)
        {
            try
            {
                var examinationResult = SimpleMapper.Mapper
                    .Map<ExaminationResultModel, MedicalExamination.BLL.ExaminationResultModel>(model);

                _examinationResultTypeService.CreateExaminationResultType(examinationResult);

                return Ok(examinationResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateExaminationResult([FromBody] ExaminationResultModel model)
        {
            try
            {
                var examinationResult = SimpleMapper.Mapper
                    .Map<ExaminationResultModel, MedicalExamination.BLL.ExaminationResultModel>(model);

                _examinationResultTypeService.UpdateExaminationResultType(examinationResult);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteExaminationResult([FromBody] ExaminationResultModel model)
        {
            try
            {
                var examinationResult = SimpleMapper.Mapper
                    .Map<ExaminationResultModel, MedicalExamination.BLL.ExaminationResultModel>(model);

                _examinationResultTypeService.DeleteExaminationResultType(examinationResult);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
