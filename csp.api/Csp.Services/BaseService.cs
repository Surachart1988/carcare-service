using Csp.DAL.UnitOfWork;

namespace Csp.Services
{
    public abstract class BaseService
    {
        public int UserId { get; set; }
        protected readonly IUnitOfWork _unitOfWork;
        
        //protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

    }
}
