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
    public interface ISubProfileService
    {
        ResultModel Add(SubProfileCreateModel model);
        ResultModel Update(SubProfileUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

       
    }
    public class SubProfileService : ISubProfileService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
    

        
        
        public SubProfileService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
           
        }
        public ResultModel Add(SubProfileCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<SubProfileCreateModel, Data.Entities.SubProfile>(model);
                _dbContext.SubProfile.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.SubProfile, SubProfileModel>(data);
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
                var data = _dbContext.SubProfile.Where(s => s.profileID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.SubProfile, SubProfileModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "SubProfile" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.SubProfile.Where(s => s.profileID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.SubProfile, SubProfileModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "SubProfile" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.SubProfile.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<SubProfileModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(SubProfileUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.SubProfile.Where(s => s.profileID == model.profileID).FirstOrDefault();
                if (data != null)
                {
                    if (model.profileID != null)
                    {
                        data.medicalRecordID = model.medicalRecordID;
                    }
                    if (model.profileName != null)
                    {
                        data.profileName = model.profileName;
                    }
                    if (model.isDeleted != null)
                    {
                        data.isDeleted = model.isDeleted;
                    }
                    

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.SubProfile, SubProfileModel>(data);
                }
                else
                {
                    result.ErrorMessage = "SubProfile" + ErrorMessage.ID_NOT_EXISTED;
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
