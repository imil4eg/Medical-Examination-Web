using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class InsuranceCompanyController : ControllerBase
    {
        private readonly IInsuranceCompanyTypeService _insuranceCompanyTypeService;

        public InsuranceCompanyController(IInsuranceCompanyTypeService insuranceCompanyTypeService)
        {
            _insuranceCompanyTypeService = insuranceCompanyTypeService;
        }

        [HttpGet]
        public ActionResult GetAllInsuranceCompanies()
        {
            return Ok(_insuranceCompanyTypeService.GetAllInsuranceCompanyTypes());
        }

        [HttpGet]
        [Route("getinsurancecompany")]
        public ActionResult GetInsuranceCompany(Guid id)
        {
            return Ok(_insuranceCompanyTypeService.GetInsuranceCompanyType(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateInsuranceCompany([FromBody] InsuranceCompanyModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.CreateInsuranceCompanyType(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateInsuranceCompany([FromBody] InsuranceCompanyModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.UpdateInsuranceCompanyType(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteInsuranceCompany([FromBody] InsuranceCompanyModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.DeleteInsuranceCompanyType(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
