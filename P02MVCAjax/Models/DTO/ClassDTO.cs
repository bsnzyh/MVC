using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models.DTO
{
    /// <summary>
    /// Class数据传输实体类
    /// </summary>
    public class ClassDTO
    {
        public int CID { get; set; }
        public string CName { get; set; }
        public int CCount { get; set; }
        public string CImg { get; set; }
        public bool CIsDel { get; set; }
        public System.DateTime CAddTime { get; set; }

    }
}