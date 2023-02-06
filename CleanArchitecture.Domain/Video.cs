using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actores = new HashSet<Actor>();
        }
        public string? Nombre { get; set; }
        [ForeignKey("Streamer")]
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor>? Actores { get; set; } //relacion muchos a muchos con actores
        public virtual Director Director { get; set; } //relacion 1 a 1 con director
    }
}
