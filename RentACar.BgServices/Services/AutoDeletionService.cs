using RentACar.Service.Services.Abstractions;

namespace RentACar.BgServices.Services
{
    public class AutoDeletionService:BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private Timer? timer = null;

        public AutoDeletionService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(async (state) => { await DoWork(stoppingToken); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
            await Task.CompletedTask;
            
        }
        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedProsessingService = scope.ServiceProvider.GetRequiredService<IRentalService>();
                await scopedProsessingService.RentalControl();
            }

        }
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}
