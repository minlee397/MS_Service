using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace QL_DT.Models
{
    public class Receipt_Note
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity),Key()]
        public int Receipt_ID {get; set;}
	    public int AccountID {get; set;}
	    public float Amount {get; set;}
	    public int State_Receipt {get; set;}
	    public DateTime Success_At {get; set;}
	    public bool Is_Active {get; set;}
	    public bool Archive	{get; set;}


		// Nhung thuoc tinh co lien toi bang khac
		public Account Account {get; set;}
		public ICollection<Detail_Receipt> Detail_Receipts {get; set;}
    }
}