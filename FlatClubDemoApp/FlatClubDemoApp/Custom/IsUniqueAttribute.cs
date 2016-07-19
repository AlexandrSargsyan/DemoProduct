using System.ComponentModel.DataAnnotations;
using DemoApp.Core;
using DemoApp.Core.Users;

namespace FlatClubDemoApp.Custom
{
    public class IsUniqueAttribute : ValidationAttribute
    {
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          
            var service = AppServiceLocator.Current.GetInstance<IUsersService>();
            var userId = value as string;

            return service.IsUserExists(userId) ? new ValidationResult(this.ErrorMessage) : ValidationResult.Success;
        }
    }
}