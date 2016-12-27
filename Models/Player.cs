using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularCRUD_Latest.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
    }
}