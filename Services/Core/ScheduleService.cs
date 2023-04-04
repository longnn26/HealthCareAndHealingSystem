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
    public interface IScheduleService
    {
        ResultModel Add(ScheduleCreateModel model);
        ResultModel Update(ScheduleUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

        
    }
    public class ScheduleService : IScheduleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Guid id;

        
        
        public ScheduleService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public ResultModel Add(ScheduleCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<ScheduleCreateModel, Data.Entities.Schedule>(model);
                _dbContext.Schedule.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.Schedule, ScheduleModel>(data);
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
                var data = _dbContext.Schedule.FirstOrDefault();
                if (data != null)
                {
                    
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Schedule, ScheduleModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Physiotherapist Slot" + ErrorMessage.ID_NOT_EXISTED;
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
            throw new NotImplementedException();
        }

        public ResultModel GetAll()
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Schedule;
                var view = _mapper.ProjectTo<ScheduleModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(ScheduleUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
