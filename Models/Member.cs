using System;
using System.ComponentModel.DataAnnotations;

namespace ValidationTest.Models
{
    public class Member
    {
        [Key]
        public int id { get; set; }

        [CustomValidation(typeof(Member), "MyRequired")]
        public string name { get; set; }

        public string email { get; set; }

        public DateTime birth { get; set; }

        public bool married { get; set; }

        public decimal age { get; set; }

        public int? cookie { get; set; }
        public string address { get; set; }

        [StringLength(12, ErrorMessage = "{0} is {1}")]
        public string memo { get; set; }


        public static ValidationResult MyRequired(string name, ValidationContext context)
        {

            if ( name == null)
            {
                return new ValidationResult("This is required parameter.");
            }
            return ValidationResult.Success;
        }
    }
}
