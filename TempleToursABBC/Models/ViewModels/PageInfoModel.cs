using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models.ViewModels
{
    public class PageInfoModel
    {
        public int TotalNumTimes { get; set; }
        public int TimesPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(((double)TotalNumTimes / TimesPerPage));
    }
}
