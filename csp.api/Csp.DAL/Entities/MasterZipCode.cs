using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterZipCode
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int SubDistrictId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual MasterDistrict District { get; set; }
        public virtual MasterProvince Province { get; set; }
        public virtual MasterSubDistrict SubDistrict { get; set; }
    }
}
