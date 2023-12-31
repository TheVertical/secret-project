﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.Web.ViewModels
{
    public interface IViewModel
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
    }
}
