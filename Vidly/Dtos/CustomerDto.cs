using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter customer's name")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //[Min18IfAMember]
        public DateTime? Birthdate { get; set; }

        public int MembershipTypeId { get; set; }
    }
}