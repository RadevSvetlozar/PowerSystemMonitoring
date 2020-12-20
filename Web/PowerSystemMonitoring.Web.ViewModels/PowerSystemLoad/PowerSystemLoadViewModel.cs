namespace PowerSystemMonitoring.Web.ViewModels.PowerSystemLoad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class PowerSystemLoadViewModel
    {
        public double TotalLoad => this.Units.Sum(x => x.LoadAbsoluteValute);

        public DateTime DateTime => DateTime.UtcNow;

        public IEnumerable<PowerSystemLoadUnitViewModel> Units { get; set; }
}
}
