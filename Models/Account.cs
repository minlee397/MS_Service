using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace QL_DT.Models
{
    public class Account
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity),Key()]
        public int AccountID {get; set;}
        public string AccountName {get; set;}
        public string Acc_Type {get; set;}


        // Nhung thuoc tinh co lien toi bang khac
        public ICollection<Receipt_Note> Receipt_Notes{get; set;}
    }
}