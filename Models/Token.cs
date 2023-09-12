
using System;
using System.ComponentModel.DataAnnotations;
using CoreTravel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTravel.Models
{
    public class Token
    {
        [Key
        ]
        public int Id
        {
            get; set;
        }

        [Required
    ]
        public int? UserId
        {
            get; set;
        } = 0;

        [Required
    ]
        public int? CustomerID
        {
            get; set;
        } = 0;

        [Required
    ]
        public string? Value
        {
            get; set;
        }

        public DateTime CreatedAt
        {
            get; set;
        }

        [ForeignKey(nameof(UserId))
    ]
        public User? User
        {
            get; set;
        }

        [ForeignKey(nameof(CustomerID))
    ]
        public Customer? Customer
        {
            get; set;
        }

        public Token()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}