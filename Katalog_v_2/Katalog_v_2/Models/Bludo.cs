using Katalog_v_2.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Katalog_v_2.Models
{
    [DataContract]
    public class Bludo : AModel
    {
        [DataMember]
        [ForeignKey("Bludo_Id")]
        public virtual List<Rezept> Rezepts { get; set; }
    }
}