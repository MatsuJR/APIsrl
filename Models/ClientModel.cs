﻿namespace APIsrl.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public List<ServiceModel> Services { get; set; }


        
    }
}
