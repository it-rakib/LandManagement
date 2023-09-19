﻿using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class FileCodeWiseLand
    {
        public string FileCodeInfoName { get; set; }
        public int FileNoInfoName { get; set; }
        public string DistrictName { get; set; }
        public string UpozilaName { get; set; }
        public string MouzaName { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public decimal? LandAmount { get; set; }
    }
}
