using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.VisualElements.Elements
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
    public class Block : IVisualElement
    {
        private int id;

        [Key]
        public int Id { get => id; set => id = value; }
        [NotMapped]
        public string Type => this.GetType().Name;
        //public string Parametrs { get; set; }
        public VisualList VisualElements { get; set; } = new VisualList();
        public void AddVisualElement(object element)
        {
            VisualElements.Add(element);
        }
    }
}
