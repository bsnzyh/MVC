using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public Nullable<int> CId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public bool IsDel { get; set; }
        public System.DateTime AddTime { get; set; }

        public ClassDTO Class { get; set; }
    }
}