using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class CarModel
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
        //public DateTime? FirstContactdate { get; set; }
        //public DateTime? LastContactdate { get; set; }
        public int? FirstMileage { get; set; }
        //public int? LastMileage { get; set; }
        //public int? AverageMileage { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CancelBy { get; set; }

    }
}
    