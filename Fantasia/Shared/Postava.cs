
namespace Fantasia.Shared
{
    public class Postava
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public int FyzickaSila { get; set; }
        public int MagickaSila { get; set; }
        public int Viera { get; set; }
        public int Stamina { get; set; }
        public int Vitalita { get; set; }
        public int Stastie { get; set; }
        public int VolneStaty { get; set; }
        public FyzUtoky FyzUtoky { get; set; } = new FyzUtoky();
        public int FyzUtokyId { get; set; }
        public MagUtoky MagUtoky { get; set; } = new MagUtoky();
        public int MagUtokyId { get; set; }
        public VieUtoky VieUtoky { get; set; } = new VieUtoky();
        public int VieUtokyId { get; set; }

    }
}
