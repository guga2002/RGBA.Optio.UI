﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Entities
{

    [Table("TypeOfTransactions")]
    [Index(nameof(TransactionName),IsUnique =true)]
    public class TypeOfTransaction:AbstractClass
    {
        [Column("Transaction_Name")]
        [MaxLength(100)]
        public required string TransactionName { get; set; }

        public required IEnumerable<Transaction> Transactions { get; set; }

    }
}
