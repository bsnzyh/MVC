using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models
{
    public partial class Class
    {
        public DTO.ClassDTO ToDto()
        {
            return new DTO.ClassDTO()
            {
                CAddTime = this.CAddTime,
                CCount = this.CCount,
                CID = this.CID,
                CImg = this.CImg,
                CIsDel = this.CIsDel,
                CName = this.CName
            };
        }
    }
}