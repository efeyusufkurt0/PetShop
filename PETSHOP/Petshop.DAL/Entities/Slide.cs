﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
    [Table("Slide2")]
    public class Slide
    {

        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Slayt adı boş geçilemez..."), Display(Name = "Slayt Adı")]
        public string Name { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Slayt Başlıgı")]
        public string Title { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Slayt Açıklaması")]
        public string Description { get; set; }
        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slayt Resmi")]
        public string Picture { get; set; }
        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Bağlantı Linki")]
        public string Link { get; set; }
        [Display(Name ="Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
    }
}



