using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.BusinessProject.Models.UserData
{
    public class DeliveryAdress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Stree { get; set; }
        public int BuildNumber { get; set; }
        /// <summary>
        /// Подъезд
        /// </summary>
        public byte Entrance { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public byte Floor { get; set; }
        public int AppartmentNumber { get; set; }
        public string BuildLiteral { get; set; }
        /// <summary>
        /// Широта в градусах
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// Долгота в градусах
        /// </summary>
        public float Longitude { get; set; }
    }
}
