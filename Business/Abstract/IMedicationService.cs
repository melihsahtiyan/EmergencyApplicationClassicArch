﻿using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Medication;

namespace Business.Abstract
{
    public interface IMedicationService
    {
        IDataResult<List<Medication>> GetAll();
        IDataResult<Medication> GetById(int medicationId);
        IResult Add(MedicationForCreateDto medication);
        IResult Update(MedicationForCreateDto medication);
        IResult Delete(MedicationForCreateDto medication);
    }
}
