﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {

        [Key]
        public int TransactionId { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="please select a category.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should not be zero.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Note { get; set; }   

        public DateTime Date { get; set; }= DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null? "": Category.Icon+" "+Category.Title ;
            }
        }

        [NotMapped]
        public string AmountwithSign
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("₹0");
            }
        }

    }
}
