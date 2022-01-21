using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseManagementWPF_WithMVVM.Models
{
    [Index(nameof(Headline), IsUnique = true)]
    internal class Case
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Headline { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string? CaseHandler { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Updated { get; set; }

        [Required]
        public CaseStatus Status { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }

    internal enum CaseStatus
    {
        Pending,
        Ongoing,
        Closed
    }
}
