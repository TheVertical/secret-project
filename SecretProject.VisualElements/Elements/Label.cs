using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Label : IVisualElement
    {
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public int Row { get; set; }
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
        public int NeededColumns { get; set; }
        /// <summary>
        /// Собственный стиль элемента
        /// </summary>
        public string SelfStyle { get; set; }
        public string Text { get; set; }
    }
}
