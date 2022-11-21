using HumansAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumansAPI.Models
{
    public class HumanModel
    {
        public HumanModel(Humans humans) 
        { 
            Id = humans.Id;
            Name = humans.Name;
            Count = humans.Count;
            Image = humans.Image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string Image { get; set; }
    }
}