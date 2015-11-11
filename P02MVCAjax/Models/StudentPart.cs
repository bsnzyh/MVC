using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models
{
    public partial class Student
    {

        public DTO.StudentDTO ToDto()
        {
            return new DTO.StudentDTO()
            {
                Id = this.Id,
                Name = this.Name,
                Gender = this.Gender,
                CId = this.CId,
                AddTime = this.AddTime,
                IsDel = this.IsDel,
                Class = this.Class.ToDto()
            };
        }
    }
}