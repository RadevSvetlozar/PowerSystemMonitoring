namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AngleSharp;
    using PowerSystemMonitoring.Web.ViewModels.PowerSystemLoad;

    public class PowerSystemLoad : IPowerSystemLoad
    {
        public PowerSystemLoadViewModel GetLoad()
        {
            var config = Configuration.Default.WithDefaultLoader();

            var context = BrowsingContext.New(config);

            var document = context.OpenAsync("http://www.eso.bg/?did=32").GetAwaiter().GetResult();

            var currentLoads = new PowerSystemLoadViewModel();

            var unitLoads = new List<PowerSystemLoadUnitViewModel>();

            var allLoads = document.All.Where(m => m.LocalName == "tr" &&
                                     m.HasAttribute("id") &&
                                     m.GetAttribute("id").StartsWith("EEC_row"));

            foreach (var item in allLoads)
            {
                var unitLoad = new PowerSystemLoadUnitViewModel();
                var items = item.GetElementsByTagName("td");

                unitLoad.Name = items[0].TextContent.ToString();
                unitLoad.LoadAbsoluteValute = int.Parse(items[1].TextContent);
                unitLoad.LoadPercentageValute = double.Parse(items[3].TextContent.Substring(1, 4));

                unitLoads.Add(unitLoad);
            }

            currentLoads.Units = unitLoads;

            return currentLoads;
        }
    }
}
