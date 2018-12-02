using DemoF.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoF.Core.Domain
{
    public class User : IUpdatableModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidUntill { get; set; }

        public IDictionary<string, object> GetUpdatableProperties() => new Dictionary<string, object>() { { nameof(FirstName), FirstName },
                                                                                                     { nameof(MiddleName), FirstName },
                                                                                                     { nameof(LastName), LastName }};
    }
}
