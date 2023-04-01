
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
    public interface IBookingDetailService
    {
        ResultModel Add(BookingDetailCreateModel model);
        ResultModel Update(BookingDetailUpdateModel model);
        ResultModel Get(Guid? id);
        ResultModel GetAll();
        ResultModel Delete(Guid id);

    }
    public class BookingDetailService : IBookingDetailService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingDetailService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
          
        }
        public ResultModel Add(BookingDetailCreateModel model)
        {
            var result = new ResultModel();
            try
            {
                var data = _mapper.Map<BookingDetailCreateModel, Data.Entities.BookingDetail>(model);
                _dbContext.BookingDetail.Add(data);
                _dbContext.SaveChanges();
                result.Data = _mapper.Map<Data.Entities.BookingDetail, BookingDetailModel>(data);
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
            throw new NotImplementedException();
        }

        public ResultModel Get(Guid? id)
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.BookingDetail.Where(s => s.bookingDetailID == id ).FirstOrDefault();
                if (data != null)
                {
                    var view = _mapper.Map<Data.Entities.BookingDetail, BookingDetailModel>(data);
                    result.Data = view;
                    result.Succeed = true;
                }
                else
                {
                    result.ErrorMessage = "BookingDetail" + ErrorMessage.ID_NOT_EXISTED;
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
                var data = _dbContext.BookingDetail;
                var view = _mapper.ProjectTo<BookingDetailModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(BookingDetailUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }



}
