using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Banner : IVisualElement,IColumnable
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public string Link { get; set; }
        public string ImageSource { get; set; }
        public int Row { get; set; }
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
        public int NeededColumns { get; set; }

    }
}
