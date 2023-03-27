
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;
using AutoMapper;
using Data.DataAccess.Constant;
using Data.Model;

namespace Services.Core
{
    public interface ISlotService
    {
        ResultModel Add(SlotCreateModel model);
        ResultModel Update(SlotUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class SlotService : ISlotService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public SlotService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public ResultModel Add(SlotCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<SlotCreateModel, Data.Entities.Slot>(model);
                _dbContext.Slot.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
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

                var data = _dbContext.Slot.Where(s => s.slotID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    data.isDeleted = true;
                    _dbContext.SaveChanges();
                    var view = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Slot" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Slot.Where(s => s.slotID == id && !s.isDeleted).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "Slot" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.Slot.Where(s => s.isDeleted != true);
                var view = _mapper.ProjectTo<SlotModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(SlotUpdateModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.Slot.Where(s => s.slotID == model.slotID).FirstOrDefault();
                if (data != null)
                {
                    if (model.slotID != null)
                    {
                        data.timeStart = model.timeStart;
                    }
                    if (model.timeEnd != null)
                    {
                        data.timeEnd = model.timeEnd;
                    }
                    if (model.fee != null)
                    {
                        data.fee = model.fee;
                    }



                    _dbContext.SaveChanges();
                    result.Succeed = true;
                    result.Data = _mapper.Map<Data.Entities.Slot, SlotModel>(data);
                }
                else
                {
                    result.ErrorMessage = "Slot" + ErrorMessage.ID_NOT_EXISTED;
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
