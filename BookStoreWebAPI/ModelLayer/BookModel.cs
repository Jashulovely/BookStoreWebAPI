using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class BookModel
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string BookDetails { get; set; }
        [Required]
        public float BookPrice { get; set; }
        [Required]
        public float BookRating { get; set; }
        [Required]
        public int BookQuantity { get; set; }
        [Required]
        public string BookImage { get; set; }
        
    }
}
