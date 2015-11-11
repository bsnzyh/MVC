using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P02MVCAjax.Models
{
   
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class BirthdayAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public BirthdayAttribute()
            : base()
        {
            this.MinAge = 18;
            this.MaxAge = 65;
        }

        public override bool IsValid(object value)
        {
            DateTime date = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out date);
            if (date != DateTime.MinValue)
            {
                if (date > DateTime.Now.AddYears(-MaxAge) && date < DateTime.Now.AddYears(-MinAge))
                {
                    return true;
                }
            }
            return false;
        }
    }
}