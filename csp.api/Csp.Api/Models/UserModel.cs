using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }


        public string Code { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string NickName { get; set; }
        
        public string Idcard { get; set; }
        public DateTime? RegisterDate { get; set; }
        // ID CARD ExpirelyDate
        public DateTime? ExpireDate { get; set; }
        public DateTime? BirthDate { get; set; }
     
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
        public Decimal? SalaryPerDay { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public bool? Active { get; set; }
    }
}
