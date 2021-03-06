﻿using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Patient"/> entity service implementation
    /// </summary>
    public interface IPatientService
    {
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatient(int id);
        void CreatePatient(PatientModel patient);
        void UpdatePatient(PatientModel patient);
        void DeletePatient(PatientModel patient);
    }
}
