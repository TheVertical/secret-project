using SecretProject.VisualElements.Elements.Common;

namespace SecretProject.VisualElements.Elements.Buttons
{
    public class CheckBoxButton : Button, IVisualElement
    {
        public bool IsCheck { get; set; }
        public IVisualGroup Group { get; set; }

    }
}
