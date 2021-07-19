using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Button : VisualElement,IVisualElement, IColumnable
    {
        [StringLength(20)]
        public string Title { get; set; }
        public string FontImage { get; set; }
        public string Action { get; set; }
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
    }
}
