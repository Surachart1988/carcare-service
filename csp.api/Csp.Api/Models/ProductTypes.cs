using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    [Flags]
    public enum ProductTypes
    {
        product = 1,
        oldproduct,
        supplies
    }

    [Flags]
    public enum ProductStatus
    {
        normal = 1,
        cancel,
    }
}
