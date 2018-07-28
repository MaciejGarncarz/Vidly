using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter customer's name")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of birth")]
        [Min18IfAMember]
        public DateTime? Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public int MembershipTypeId { get; set; }
    }
}