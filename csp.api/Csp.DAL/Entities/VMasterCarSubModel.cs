﻿using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterCarSubModel
    {
        public int Id { get; set; }
        public string CarModelName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
