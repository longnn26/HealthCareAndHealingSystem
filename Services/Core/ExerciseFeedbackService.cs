using Data.Model;
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
    public interface IExerciseFeedbackService
    {
        ResultModel Add(ExerciseFeedbackCreateModel model);
        ResultModel Update(ExerciseFeedbackUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class ExerciseFeedbackService : IExerciseFeedbackService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

  
        public ExerciseFeedbackService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            id = Guid.NewGuid();
        }
        public ResultModel Add(ExerciseFeedbackCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<ExerciseFeedbackCreateModel, Data.Entities.ExerciseFeedback>(model);
                _dbContext.ExerciseFeedback.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.ExerciseFeedback, ExerciseFeedbackModel>(data);
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
                var data = _dbContext.ExerciseFeedback.Where(s => s.exerciseFeedbackID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.ExerciseFeedback, ExerciseFeedbackModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "ExerciseFeedback" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseFeedback.Where(s => s.exerciseFeedbackID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.ExerciseFeedback, ExerciseFeedbackModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "ExerciseFeedback" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.ExerciseFeedback.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<ExerciseFeedbackModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ExerciseFeedbackUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.ExerciseFeedback.Where(s => s.exerciseFeedbackID == model.exerciseFeedbackID).FirstOrDefault();
                if (data != null)
                {
                    if (model.exerciseFeedbackID != null)
                    {
                        data.feedbackContent = model.feebackContent;
                    }


                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.ExerciseFeedback, ExerciseFeedbackModel>(data);
                }
                else
                {
                    result.ErrorMessage = "ExerciseFeedback" + ErrorMessage.ID_NOT_EXISTED;
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
