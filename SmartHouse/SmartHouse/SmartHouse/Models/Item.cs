using System;

namespace SmartHouse.Models
{
    public class Item
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string PortNumber { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
    }
}