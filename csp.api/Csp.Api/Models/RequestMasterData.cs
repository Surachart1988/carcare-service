using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csp.Api.Models
{
    public class RequestMasterData
    {
        public RequestMasterData()
        {
            MasterPermisson = new List<MasterPermisson>();
            MasterAssessmentDetails = new List<MasterAssessmentDetails>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProGroupID { get; set; }
        public int ProTypeID { get; set; }
        public int ProBrandID { get; set; }
        public int ProModelID { get; set; }
        public int NextServiceID { get; set; }
        public int CarTypeID { get; set; }
        public int CarBrandID { get; set; }
        public int CarModelID { get; set; }
        public string Fcode { get; set; }
        public string Cost { get; set; }
        public int ContactPayTypeID { get; set; }
        public int Scores { get; set; }
        public int AssessmentID { get; set; }
        public int Condition { get; set; }
        public int BankID { get; set; }
        public int? CountMileage { get; set; }
        public int? NextDaysCount { get; set; }
        public bool Status { get; set; }
        public List<MasterPermisson> MasterPermisson { get; set; }
        public List<MasterAssessmentDetails> MasterAssessmentDetails { get; set; }
    }
}
