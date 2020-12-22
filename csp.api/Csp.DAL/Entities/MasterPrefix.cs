using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterPrefix")]
    public partial class MasterPrefix
    {
        public MasterPrefix()
        {
            Contact = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Contact> Contact { get; set; }
    }
}
