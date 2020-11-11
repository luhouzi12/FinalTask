using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Common
{
    public sealed class GetOptions
    {

        public bool CaseSensitive { get; set; }

        [Required]
        public string FilterCriteria { get; set; }

    }
}
