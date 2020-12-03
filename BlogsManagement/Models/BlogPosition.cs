using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogsManagement.Models
{
    public class BlogPosition
    {
        [Key]
        public int Id { get; set; }

        public int BlogId { get; set; }

        public int PositionId { get; set; }

    }
}