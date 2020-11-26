﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public interface IVisualElement
    {
        int Id { get; set; }
        [NotMapped]
        string Type { get; }
    }
}
