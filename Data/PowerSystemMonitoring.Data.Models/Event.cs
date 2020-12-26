namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
