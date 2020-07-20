using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Models.Entities.Owned
{
    [Owned]
    public class Person
    {
        [Required, StringLength(50)] 
        public string FirstName { get; set; } = "New";
        [Required, StringLength(50)] 
        public string LastName { get; set; } = "Customer";
    }
}