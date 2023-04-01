﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;

namespace Services.Core
{
    public interface IMedicalRecordService
    {
        ResultModel Add(MedicalRecordCreateModel model);
        ResultModel Update(MedicalRecordUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        public MedicalRecordService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(MedicalRecordCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<MedicalRecordCreateModel, Data.Entities.MedicalRecord>(model);
                _dbContext.MedicalRecord.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.MedicalRecord, MedicalRecordModel>(data);
                result.Succeed = true;

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Delete(Guid id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.MedicalRecord.Where(s => s.medicalRecordID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.MedicalRecord, MedicalRecordModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "MedicalRecord" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Get(Guid? id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.MedicalRecord.Where(s => s.medicalRecordID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.MedicalRecord, MedicalRecordModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "MedicalRecord" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetAll()
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.MedicalRecord.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<MedicalRecordModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }



        public ResultModel Update(MedicalRecordUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.MedicalRecord.Where(s => s.medicalRecordID == model.medicalRecordID).FirstOrDefault();
                if (data != null)
                {
                    if (model.medicalRecordID != null)
                    {
                        data.presentIllness = model.presentIllness;
                    }
                    if (model.pastMedical != null)
                    {
                        data.pastMedical = model.pastMedical;
                    }
                    if (model.pastMedical != null)
                    {
                        data.pastMedical = model.pastMedical;
                    }
                    if (model.isDeleted != null)
                    {
                        data.isDeleted = model.isDeleted;
                    }
                    if (model.categoryID != null)
                    {
                        data.categoryID = model.categoryID;
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.MedicalRecord, MedicalRecordModel>(data);
                }
                else
                {
                    result.ErrorMessage = "MedicalRecord" + ErrorMessage.ID_NOT_EXISTED;
                    result.Succeed = false;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

    }


}
