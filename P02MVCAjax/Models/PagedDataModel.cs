using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models
{
    /// <summary>
    /// 分页数据实体
    /// </summary>
    public class PagedDataModel<T>
    {
        public List<T> PagedData { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
    }
}