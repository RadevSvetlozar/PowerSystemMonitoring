
namespace PowerSystemMonitoring.Web.Services
{
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.Extensions.Configuration;
    using PowerSystemMonitoring.Data;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.Hubs;
    using PowerSystemMonitoring.Web.ViewModels.RealTImeCurrentSensor;

    public class SqlDependencyService : IDatabaseChageNotificationService
    {
        private readonly IConfiguration configuration;
        private readonly IHubContext<CurrentSensorsHub> hubContext;
        private readonly IRealTimeCurrentSensorService realTimeCurrentSensorService;
        private readonly ApplicationDbContext dbContext;

        public SqlDependencyService(
            IConfiguration configuration,
            IHubContext<CurrentSensorsHub> hubContext,
            IRealTimeCurrentSensorService realTimeCurrentSensorService,
            ApplicationDbContext dbContext)
        {
            this.configuration = configuration;
            this.hubContext = hubContext;
            this.realTimeCurrentSensorService = realTimeCurrentSensorService;
            this.dbContext = dbContext;
        }

        public void Config()
        {
            ConfigSubMethod();
        }

        private void ConfigSubMethod()
        {
            string connString = this.configuration.GetConnectionString("DefaultConnection");

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT [Current],[Temparature] FROM [dbo].RealTimeValues", conn))
                {
                    cmd.Notification = null;

                    SqlDependency dependency = new SqlDependency(cmd);

                    dependency.OnChange += (object sender, SqlNotificationEventArgs e) =>
                    {
                        if (e.Type == SqlNotificationType.Change)
                        {
                            using (var conn = new SqlConnection(connString))
                            {
                                conn.Open();
                                string queryString = @"SELECT TOP (1) 
                                                         [CurrentSensorId]
                                                         ,[Current]
                                                         ,[Temparature]
                                                     FROM[PowerSystemMonitoring].[dbo].                                                                 [RealTimeValues]
                                                     ORDER BY CreatedOn Desc";

                                SqlCommand command = new SqlCommand(queryString, conn);

                                var model = new RealTimeCurrentSensorViewModel();

                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    model.CurrentSensorId = reader[0].ToString();
                                    model.Current = reader[1].ToString();
                                    model.Temperature = reader[2].ToString();
                                }

                                reader.Close();

                                this.hubContext.Clients.All.SendAsync("NewMessage", model).GetAwaiter().GetResult();
                            }
                        }

                        this.ConfigSubMethod();
                    };

                    SqlDependency.Start(connString);
                    cmd.ExecuteReader();
                }
            }
        }
    }
}

