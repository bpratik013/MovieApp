using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Display(Name="MembershipType")]
        public string Name { get; set; }

        public short SignUpFee { get; set; }
        public short DurationInMonths { get; set; }
        public short DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}