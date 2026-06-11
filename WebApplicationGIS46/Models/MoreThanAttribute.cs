using System.ComponentModel.DataAnnotations;

namespace WebApplicationGIS46.Models
{
    public class MoreThanAttribute:ValidationAttribute
    {
        public MoreThanAttribute(int min)
        {
            MinNumber = min;
        }
        public int MinNumber { get; set; }
        public override bool IsValid(object? value)
        {
            int salary = int.Parse(value.ToString());
            if (salary > MinNumber)
            {
                return true;
            }
            return false;
        }
    }
}
