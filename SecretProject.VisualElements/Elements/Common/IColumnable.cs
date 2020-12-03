using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.VisualElements.Elements.Common
{
    interface IColumnable
    {
        int Row { get; set; }
        /// <summary>
        /// Необходимое количество столбцов для отрисовки
        /// </summary>
        int NeededColumns { get; set; }
    }
}
