using System;
using System.Collections.Generic;

namespace SecretProject.VisualElements.Elements
{
    interface IHierarchyElement
    {
        Guid Id { get; set; }

        string Name { get; set; }

        bool IsRoot { get; set; }

        List<IHierarchyElement> Children { get; set;}

    }
}
