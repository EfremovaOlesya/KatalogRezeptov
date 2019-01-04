using Katalog_v_2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Katalog_v_2.Models
{
    [DataContract]
    public class Rezept: AModel
    {
        [DataMember]
        public int bludId { get; set; }

        [DataMember]
        public string Ingrid { get; set; }

        [DataMember]
        public string soder { get; set; }

        [DataMember]
        public string RezeptData { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public string ImageMimeType { get; set; }

        [DataMember]
        public int Bludo_Id { get; set; }

        public virtual Bludo Bludo { get; set; }
    }
}