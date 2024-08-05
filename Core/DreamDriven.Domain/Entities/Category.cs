﻿using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        public Category(string name, string description, DateTime updated_at)
        {
            Name = name;
            Description = description;
            Updated_at = updated_at;

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Updated_at { get; set; }

        //BackgroundImages
        public ICollection<BackgroundImage> BackgroundImages { get; set; }
    }
}
