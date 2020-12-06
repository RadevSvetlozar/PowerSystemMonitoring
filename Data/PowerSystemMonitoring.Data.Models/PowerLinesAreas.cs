namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class PowerLinesAreas
    {
        [Key]
        public int PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        [Key]
        public int AreaId { get; set; }

        public virtual Area Areas { get; set; }
    }
}
