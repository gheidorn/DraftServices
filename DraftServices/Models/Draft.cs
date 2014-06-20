using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DraftServices.Models
{
    public class Draft
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string CompetitionType { get; set; }  // Sport

        [Required]
        public DateTime StartDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        // navigation property
        public ICollection<User> Users { get; set; }
    }

    public class DraftDBContext : DbContext
    {
        public DbSet<Draft> Drafts { get; set; }
    }

}