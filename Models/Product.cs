using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QL_DT.Models
{
    public class Product
    {
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity),Key()]
        public int ProductID {get; set;}
 	    public string NameProduct {get; set;}
        public float Price {get; set;}
        public int Quantity {get; set;}

    }
}