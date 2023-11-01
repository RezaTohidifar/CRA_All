using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIForCRA
{
    public class QueryServiceModel
    {
        [Required]
        public string serviceNum { get; set; }
    }
}
