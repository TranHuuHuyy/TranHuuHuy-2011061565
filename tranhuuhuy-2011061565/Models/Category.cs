﻿using System.ComponentModel.DataAnnotations;

namespace tranhuuhuy_2011061565.Models
{
    public class Category
    {
       
            public byte Id { get; set; }
            [Required]
            [StringLength(255)]
            public string Name { get; set; }
       
    }
}