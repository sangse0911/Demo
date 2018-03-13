using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime? Date { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public Blog()
        {
            this.Categories = new HashSet<Category>();
        }
    }
}