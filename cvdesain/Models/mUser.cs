using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvdesain.Models
{
    public class mUser
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Silahkan isi username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Silahkan isi nama depan")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Silahkan isi nama belakang")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Silahkan isi password")]
        public string password { get; set; }
    }
}