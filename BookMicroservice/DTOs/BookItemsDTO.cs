using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.API.DTOs
{
    public class BookItemsDTO
    {
        public long Id { get; set; }
        [Required,StringLength(50)]
        public string Book_name { get; set; }
        [Required, StringLength(50)]
        public  string Book_type { get;  set; }
        [Required]
        public decimal Book_price { get;set; }

    }
}
