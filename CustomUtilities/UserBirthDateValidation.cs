using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSite.CustomUtilities
{
    public class UserBirthDateValidation : ValidationAttribute
    {
        public UserBirthDateValidation()
        {
            ErrorMessage = "Ваш возраст не может быть меньше 18  или больше 110";
        }

        public override bool IsValid(object value)
        {
            bool result = true;

            bool isDate = DateTime.TryParse(value.ToString(), out DateTime date);

            if (isDate)
            {
                if (date.Year + 18 > DateTime.Now.Year)
                    result = false;
                if (DateTime.Now.Year - date.Year > 100)
                    result = false;
            }

            return result;
        }
    }
}