﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.Core.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Approved { get; set; } = false;
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Data: {Date.ToShortDateString()} - {Description}";
        }
    }
}
