using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    [Table("[dbo].[User]")]
    public partial class User
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public string LoginName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string NickName { get; set; }
        public string Idcard { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? Blood { get; set; }
        public string Address { get; set; }
        public string AddressNo { get; set; }
        public string AddressMoo { get; set; }
        public string AddressTrog { get; set; }
        public string AddressRoad { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int SubDistrictId { get; set; }
        public int ZipCodeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? EmployeeType { get; set; }
        public decimal? SalaryPerDay { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Active { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        [Write(false)]
        [Computed]
        public virtual MasterPosition Position { get; set; }
    }
}
