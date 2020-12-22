using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using Csp.Services.CustomeException;
using Csp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Services.Services
{
    public class UserService : BaseService, IUserService
    {

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_cache = cache;
        }

        public async Task<User> Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new BadParametersException("Password is required");

            Dictionary<string, string> searchParams = new Dictionary<string, string>();
            searchParams.Add("LoginName", user.LoginName);

            if (_unitOfWork.UserRepository.SearchByField(searchParams).Result.Any()) {
                throw new DataDuplicateException(String.Format("LoginName {0} is already taken", user.LoginName));
            }


            // Generate Employee Code
            string code;
            if (_unitOfWork.UserRepository.GetAll().Result.OrderByDescending(u => u.Id).FirstOrDefault() == null)
                code = "1";
            else
                code = _unitOfWork.UserRepository.GetAll().Result.OrderByDescending(u => u.Id).FirstOrDefault().Code.Split("E")[1];

            user.Code = String.Format("E{0:D5}", Convert.ToInt64(code) + 1);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // set default active status
            user.Active = true;

            _unitOfWork.UserId = UserId;

            User newUser = await _unitOfWork.UserRepository.Add(user);
            return newUser;
        }

        public Task<User> GetUserById(int userId)
        {
            return _unitOfWork.UserRepository.Get(userId);
        }

        public async Task<User> GetUserByLoginName(string loginName)
        {   
            Dictionary<string, string> searchParams = new Dictionary<string, string>();
            searchParams.Add("LoginName", loginName);
            var users = await _unitOfWork.UserRepository.SearchByField(searchParams);
            return users.FirstOrDefault();
        }

        public async Task<bool> Update(User user)
        {
            return await _unitOfWork.UserRepository.Update(user);
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.Get(id);
            return await _unitOfWork.UserRepository.Delete(user);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return base._unitOfWork;
        }

        public async Task<IEnumerable<User>> SrchUsrByField(Dictionary<string, string> searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "UpdatedAt", bool orderAsc = false)
        {
            return  await _unitOfWork.UserRepository.SrchUsrByField(searchParams, pageIndex, pageSize, orderBy, orderAsc);
        }

        public async Task<int> GetTotalSrchUsrByField(Dictionary<string, string> searchParams)
        {
            return await _unitOfWork.UserRepository.GetTotalSrchUsrByField(searchParams);
        }
    }
}
