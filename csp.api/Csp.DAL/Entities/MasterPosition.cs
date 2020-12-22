using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterPosition")]
    public partial class MasterPosition
    {
        
        //public MasterPosition()
        //{
        //    MasterPermisson = new HashSet<MasterPermisson>();
        //    User = new HashSet<User>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        public virtual ICollection<MasterPermisson> MasterPermisson { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<User> User { get; set; }

    }
}
