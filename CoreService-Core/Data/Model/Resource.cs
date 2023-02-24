using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService_Core.Data.Model
{
    internal class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAdress { get; set; }
        public string UserId { get; set; }
        public TimeSpan Repeat { get; set; }
    }
}
