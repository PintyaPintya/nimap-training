using System.ComponentModel.DataAnnotations;

namespace MoshMVC.Models;

public class Min18YrsIfAMember : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var customer = (Customer)validationContext.ObjectInstance;

        if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            return ValidationResult.Success;

        if(customer.BirthDate == null)
            return new ValidationResult("Date of Birth is required for membership");

        var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

        return(age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 yrs old for membership");
    }
}