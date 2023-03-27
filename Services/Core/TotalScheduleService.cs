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
    public interface ITotalScheduleService
    {
        ResultModel Add(TotalScheduleCreateModel model);
        ResultModel Update(TotalScheduleUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);


    }
    public class TotalScheduleService : ITotalScheduleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public TotalScheduleService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ResultModel Add(TotalScheduleCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<TotalScheduleCreateModel, Data.Entities.TotalSchedule>(model);
                _dbContext.TotalSchedule.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.TotalSchedule, TotalScheduleModel>(data);
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
                var data = _dbContext.TotalSchedule.Where(s => s.totalScheduleID == id).FirstOrDefault();
                if (data != null)
                {

                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.TotalSchedule, TotalScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "TotalSchedule" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.TotalSchedule.Where(s => s.totalScheduleID == id).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.TotalSchedule, TotalScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "TotalSchedule" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Exercise;
                var view = _mapper.ProjectTo<TotalScheduleModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(TotalScheduleUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
    }

