using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("Car")]
    public partial class Car
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int CarTypeId { get; set; }
        public int CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public int CarSubModelId { get; set; }
        public int CarGearId { get; set; }
        public string Chasis { get; set; }
        public string Code { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string CarBody { get; set; }
        public string EngineCc { get; set; }
        public string Color { get; set; }
        public int? CarUseDetail { get; set; }
        public int? CarWork { get; set; }
        public string CarWorkDetail { get; set; }
        public DateTime? FirstContactdate { get; set; }
        public DateTime? LastContactdate { get; set; }
        public int? FirstMileage { get; set; }
        public int? LastMileage { get; set; }
        public int? AverageMileage { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CancelBy { get; set; }

        [Write(false)]
        [Computed]
        public virtual MasterCarBrand CarBrand { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterCarGear CarGear { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterCarModel CarModel { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterCarSubModel CarSubModel { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterCarType CarType { get; set; }
        [Write(false)]
        [Computed]
        public virtual Contact Customer { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterProvince Province { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
