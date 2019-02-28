using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard12.Pages;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard12.Models
{
    public class MessageBoard12Context : DbContext
    {
        public MessageBoard12Context (DbContextOptions<MessageBoard12Context> options)
            : base(options)
        {
        }

        public DbSet<MessageData> messageData { get; set; }
    }
}
