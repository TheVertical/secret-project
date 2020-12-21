using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements.Common
{
    public class VisualElement : IVisualElement, IColumnable
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
        [StringLength(20)]
        public int NeededColumns { get; set; }
        /// <summary>
        /// Расположение по оси X
        /// </summary>
        public string JustyfyContent { get; set; }
        /// <summary>
        /// Расположение по оси Y
        /// </summary>
        public string AlignContent { get; set; }
    }
}
