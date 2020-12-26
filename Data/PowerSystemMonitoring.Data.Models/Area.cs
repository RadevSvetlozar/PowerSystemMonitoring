namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Area : BaseDeletableModel<int>
    {
        public Area()
        {
            this.CurrentSensors = new HashSet<CurrentSensor>();
            this.PowerLines = new HashSet<PowerLinesAreas>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }

        public virtual Image Image { get; set; }

        public ICollection<PowerLinesAreas> PowerLines { get; set; }
    }
}
