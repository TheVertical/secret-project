using SecretProject.VisualElements.Elements.Common;

namespace SecretProject.VisualElements.Elements.Blocks
{
    public class Block : VisualElement,IVisualElement, IColumnable
    {
        //public string Parametrs { get; set; }
        public VisualList VisualElements { get; set; } = new VisualList();
        public void AddVisualElement(object element)
        {
            VisualElements.Add(element);
        }
    }
}
