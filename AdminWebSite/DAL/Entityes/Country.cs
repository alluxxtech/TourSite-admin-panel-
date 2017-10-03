﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminWebSite.DAL.Entityes
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength:256)]
        public string Name { get; set; }
        public DateTime DataCreate { get; set; }

        public int Priority { get; set; }
        virtual public ICollection<City> Cities { get; set; }
    }
}