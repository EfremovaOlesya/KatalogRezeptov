using Katalog_v_2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Katalog_v_2.Models
{
    [DataContract]
    public class User: AModel
    {
        [DataMember]
        [Required]
        public string Login { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }
    }
}