using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantasia.Shared
{
    public class Postava
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int FyzickaSila { get; set; }
        public int MagickaSila { get; set; }
        public int Viera { get; set; }
        public int Stamina { get; set; }
        public int Vitalita { get; set; }
        public int Stastie { get; set; }
        public int VolneStaty { get; set; }
        public FyzUtoky FyzUtoky { get; set; }
        public int FyzUtokyId { get; set; }
        public MagUtoky MagUtoky { get; set; }
        public int MagUtokyId { get; set; }
        public VieUtoky VieUtoky { get; set; }
        public int VieUtokyId { get; set; }

    }
}
