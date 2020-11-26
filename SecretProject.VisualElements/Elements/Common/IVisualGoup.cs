using System.Collections.Generic;

namespace SecretProject.VisualElements.Elements
{
    public interface IVisualGroup
    {
        List<IButton> Group { get; set; }
    }
}