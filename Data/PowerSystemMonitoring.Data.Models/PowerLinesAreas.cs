namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PowerLinesAreas
    {
        public int PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}
