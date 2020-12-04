using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.VisualElements.Elements.Common
{
    interface IColumnable
    {
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
        int NeededColumns { get; set; }
    }
}
