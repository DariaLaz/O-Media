using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Constants
{
    public class MessageConstants
    {
        public const string ErrorMessage = "ErrorMessage";
        public const string WarningMessage = "WarningMessage";
        public const string SuccessMessage = "SuccessMessage";
    }
    public class AgeGroups 
    {
        public const string AgeRangeError = "Age must be a positive number and less than 100";
    }
    public class Competitions
    {
        public const string NameLenRangeError = "Name is required and must have lenght up to 50 characters";
        public const string LocationLenRangeError = "Name is required and must have lenght up to 50 characters";
        public const string DetailsLenRangeError = "Name is required and must have lenght up to 50 characters";

    }
}
