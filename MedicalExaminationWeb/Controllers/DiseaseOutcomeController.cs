using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class DiseaseOutcomeController : ControllerBase
    {
        private readonly IDiseaseOutcomeTypeService _diseaseOutcomeTypeService;

        public DiseaseOutcomeController(IDiseaseOutcomeTypeService diseaseOutcomeTypeService)
        {
            _diseaseOutcomeTypeService = diseaseOutcomeTypeService;
        }

        [HttpGet]
        public ActionResult GetAllDiseaseOutcomes()
        {
            return Ok(_diseaseOutcomeTypeService.GetAllDiseaseOutcomeTypes());
        }

        [HttpGet]
        [Route("getdiseaseoutcome")]
        public ActionResult GetDiseaseOutcome(Guid id)
        {
            return Ok(_diseaseOutcomeTypeService.GetDiseaseOutcomeType(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateDiseaseOutcome([FromBody] DiseaseOutcomeModel model)
        {
            try
            {
                var diseaseOutcome =
                    SimpleMapper.Mapper.Map<DiseaseOutcomeModel, MedicalExamination.BLL.DiseaseOutcomeModel>(model);

                _diseaseOutcomeTypeService.CreateDiseaseOutcomeType(diseaseOutcome);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateDiseaseOutcome([FromBody] DiseaseOutcomeModel model)
        {
            try
            {
                var diseaseOutcome =
                    SimpleMapper.Mapper.Map<DiseaseOutcomeModel, MedicalExamination.BLL.DiseaseOutcomeModel>(model);

                _diseaseOutcomeTypeService.UpdateDiseaseOutcomeType(diseaseOutcome);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteDiseaseOutcome([FromBody] DiseaseOutcomeModel model)
        {
            try
            {
                var diseaseOutcome =
                    SimpleMapper.Mapper.Map<DiseaseOutcomeModel, MedicalExamination.BLL.DiseaseOutcomeModel>(model);

                _diseaseOutcomeTypeService.DeleteDiseaseOutcomeType(diseaseOutcome);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
