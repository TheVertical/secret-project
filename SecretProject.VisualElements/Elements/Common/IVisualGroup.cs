using System.Collections.Generic;

namespace SecretProject.VisualElements.Elements.Common
{
    public interface IVisualGroup
    {
        List<IButton> Group { get; set; }
    }
}