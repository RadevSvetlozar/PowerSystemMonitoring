namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class PowerLinesEvents
    {
        [Key]
        public int PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        [Key]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
