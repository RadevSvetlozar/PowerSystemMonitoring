namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConductorsImages
    {
        public int ConductorId { get; set; }

        public virtual Conductor Conductor { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
