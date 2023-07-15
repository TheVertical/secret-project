using System;
using System.Collections;
using SecretProject.VisualElements.Elements.Common;

namespace SecretProject.VisualElements.Elements.Blocks
{
    /// <summary>
    /// Специальный нетипизированный список,
    /// допускающий добавление только элементов реализующих интрефейс IVisualElement
    /// Сделан пока не поймем как правильно сериализовать визуальные объекты в json
    /// </summary>
    public class VisualList : ArrayList
    {
        public VisualList() : base()
        {
        }

        /// <param name="value">"Объект, реализующий интерфейс IVisualElement</param>
        /// <exception cref="ArrayTypeMismatchException">Происходит при отсутствии у какого-либо объекта коллекции реализации интерфейса IVisualElement</exception>
        /// <returns>Номер элеменат в списке</returns>
        public override int Add(object value)
        {
            if (!(value is IVisualElement))
                throw new ArrayTypeMismatchException(value.GetType().Name);
            return base.Add(value);
        }
        /// <param name="с">"Коллекция объектов, реализующих интерфейс IVisualElement</param>
        /// <exception cref="ArrayTypeMismatchException">Происходит при отсутствии у какого-либо объекта коллекции реализации интерфейса IVisualElement</exception>
        /// <returns>Номер элеменат в списке</returns>
        public override void AddRange(ICollection c)
        {
            foreach (var value in c)
            {
                if (!(value is IVisualElement))
                    throw new ArrayTypeMismatchException(value.GetType().Name);
            }
            base.AddRange(c);
        }
    }
}