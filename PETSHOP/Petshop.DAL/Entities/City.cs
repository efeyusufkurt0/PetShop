﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
	public class City
	{
        public int ID { get; set; }

        [StringLength(100),Column(TypeName ="varchar(100)"),Display(Name ="Şehir Adı")]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
		public ICollection<Order> Orders { get; set; }


	}
}
