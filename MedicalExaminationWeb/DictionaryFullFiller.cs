using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb
{
    public class DictionaryFullFiller
    {
        public static void SetInsuranceCompanies(PatientViewModel model,
            IInsuranceCompanyTypeService insuranceCompanyService)
        {
            var insuranceCompaniesModels = insuranceCompanyService.GetAllInsuranceCompanies()
                .Map<InsuranceCompanyModel, InsuranceCompanyViewModel>().ToArray();

            model.InsuranceCompanies =
                new SelectList(insuranceCompaniesModels, "Id", "Name", insuranceCompaniesModels[0].Id);
        }

        public static void SetPassportIssuePlaces(PersonViewModel model,
            IPassportIssuePlaceTypeService passportIssuePlaceService)
        {
            var passportIssuePlaceModels = passportIssuePlaceService.GetAllPassportIssuePlaces()
                .Map<MedicalExamination.BLL.PassportIssuePlaceModel, PassportIssuePlaceModel>().ToArray();

            model.PassportIssuePlaces =
                new SelectList(passportIssuePlaceModels, "Id", "Name", passportIssuePlaceModels[0].Id);
        }

        public static void SetInsuranceCompaniesAndPassportPlaces(PatientViewModel model,
            IInsuranceCompanyTypeService insuranceCompanyService,
            IPassportIssuePlaceTypeService passportIssuePlaceService)
        {
            SetInsuranceCompanies(model, insuranceCompanyService);
            SetPassportIssuePlaces(model.Person, passportIssuePlaceService);
        }


    }
}
