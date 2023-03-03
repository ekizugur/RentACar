
using RentACar.Service.Services.Abstractions;

namespace RentACar.BgServices.Services
{
    public class RememberEmailService : BackgroundService
    {
        
        private readonly IServiceProvider services;
        private Timer? timer=null;

        public RememberEmailService(IServiceProvider services)
        {
            
            this.services = services;
            
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async (state) => { await DoWork(stoppingToken); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            await Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            

            using (var scope = services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IRentalService>();

                await scopedProcessingService.RentalRememberEmail();
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }

    }
}
