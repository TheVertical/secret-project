using System.ComponentModel.DataAnnotations;
using SecretProject.VisualElements.Elements.Common;

namespace SecretProject.VisualElements.Elements.Buttons
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
