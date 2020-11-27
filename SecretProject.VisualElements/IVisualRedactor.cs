using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.VisualElements
{
    public interface IVisualRedactor
    {
        object GetBackbone();
        object GetFormattedVisualElement(object element);
        object GetFormattedVisualElement(IEnumerable<object> element);
        object GetAllVisualElements();
    }

    public interface IVisualRedactor<TResult>
    {
        TResult GetBackbone();
        TResult GetFormattedVisualElement(object element);
        TResult GetFormattedVisualElement(IEnumerable<object> element);
        TResult GetAllVisualElements();
    }
}
