﻿using FinPlanner360.Business.Models.Enums;
using System.Text.Json.Serialization;

namespace FinPlanner360.Business.Models
{
    public class Category : Entity
    {
        #region Attributes

        public Guid? UserId { get; set; }
        public string Description { get; set; }
        public CategoryTypeEnum Type { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }

        #endregion Attributes

        #region Helper only for EF Mapping

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }

        #endregion Helper only for EF Mapping
    }
}
