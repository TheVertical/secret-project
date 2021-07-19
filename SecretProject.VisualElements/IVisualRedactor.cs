using System.Collections.Generic;

namespace SecretProject.VisualElements
{
    public interface IVisualRedactor
    {
        bool Clear(string page);
        object GetBackbone();
        object GetAllViewModels();
        object GetFormattedElement(object element);
        public object GetVisualElementByName(string name);
        object GetFormattedElement(IEnumerable<object> element);
        object GetAllVisualElements();
    }

    public interface IVisualRedactor<TResult>
    {
        TResult GetBackbone();
        TResult GetFormattedVisualElement(object element);
        TResult GetFormattedElement(IEnumerable<object> element);
        TResult GetAllVisualElements();
    }
}
