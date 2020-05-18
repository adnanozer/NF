using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nefa.Models
{
    public class Enums
    {
        public enum Tip {
            [Display(Name = "Alıcı")]
            alici = 1,
            [Display(Name = "Satıcı")]
            satici = 2,
            [Display(Name = "toptancı")]
            toptanci = 3,
            [Display(Name = "kefil")]
            kefil = 4,
            [Display(Name = "müstahsil")]
            müstahsil = 5,
            [Display(Name = "diğer")]
            diger = 6
        }
    }
}
