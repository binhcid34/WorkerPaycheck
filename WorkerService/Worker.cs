using Tasks.Schedule;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private ScheduleBL _ScheduleBL = new ScheduleBL();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _ScheduleBL.sendPaycheckAuto();
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}