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
            return Ok(_insuranceCompanyTypeService.GetAllInsuranceCompanies());
        }

        [HttpGet]
        [Route("getinsurancecompany")]
        public ActionResult GetInsuranceCompany(Guid id)
        {
            return Ok(_insuranceCompanyTypeService.GetInsuranceCompany(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateInsuranceCompany([FromBody] InsuranceCompanyViewModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyViewModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.CreateInsuranceCompany(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateInsuranceCompany([FromBody] InsuranceCompanyViewModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyViewModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.UpdateInsuranceCompany(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteInsuranceCompany([FromBody] InsuranceCompanyViewModel model)
        {
            try
            {
                var insuranceCompany = SimpleMapper.Mapper
                    .Map<InsuranceCompanyViewModel, MedicalExamination.BLL.InsuranceCompanyModel>(model);

                _insuranceCompanyTypeService.DeleteInsuranceCompany(insuranceCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
