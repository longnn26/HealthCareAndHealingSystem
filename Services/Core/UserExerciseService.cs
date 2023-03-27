using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using static Data.Model.UserExerciseCreateModel;

namespace Services.Core
{
    public interface IUserExerciseService
    {
        ResultModel Add(UserExerciseCreateModel model);
        ResultModel Update(UserExerciseUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class UserExerciseService : IUserExerciseService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        

        
        public UserExerciseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public ResultModel Add(UserExerciseCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<UserExerciseCreateModel, Data.Entities.UserExercise>(model);
                _dbContext.UserExercise.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.UserExercise, UserExerciseModel>(data);
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
                var data = _dbContext.UserExercise.Where(s => s.userExerciseID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.UserExercise, UserExerciseModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "UserExercise" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.UserExercise.Where(s => s.userExerciseID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.UserExercise, UserExerciseModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "UserExercise" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.UserExercise.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<ExerciseModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(UserExerciseUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.UserExercise.Where(s => s.userExerciseID == model.userExerciseID).FirstOrDefault();
                if (data != null)
                {
                    if (model.userExerciseID != null)
                    {
                    
                        data.status = model.status;
                    }
                    if (model.isDeleted!= true) 
                    {
                        data.isDeleted = model.isDeleted;
                    }

                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.UserExercise, UserExerciseModel>(data);
                }
                else
                {
                    result.ErrorMessage = "UserExercise" + ErrorMessage.ID_NOT_EXISTED;
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
