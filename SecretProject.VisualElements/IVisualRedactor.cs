using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretProject.VisualElements
{
    public interface IVisualRedactor
    {
        object GetBackbone();
        object GetFormattedVisualElement(object element);
        public object GetVisualElementByName(string name);
        object GetFormattedVisualElement(IEnumerable<object> element);
        object GetAllVisualElements();

        //Task<ResultType> GetBackboneAsync<ResultType>();
        //Task<ResultType> GetFormattedVisualElementAsync<ResultType>(object element);
        //Task<ResultType> GetFormattedVisualElementAsync<ResultType>(IEnumerable<object> element);
        //Task<ResultType> GetAllVisualElementsAsync<ResultType>();
    }

    public interface IVisualRedactor<TResult>
    {
        TResult GetBackbone();
        TResult GetFormattedVisualElement(object element);
        TResult GetFormattedVisualElement(IEnumerable<object> element);
        TResult GetAllVisualElements();
    }
}
