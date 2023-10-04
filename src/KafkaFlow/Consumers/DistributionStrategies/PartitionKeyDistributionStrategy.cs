namespace KafkaFlow.Consumers.DistributionStrategies
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This strategy uses the partition key and applies a mod operator with the total number of workers, the resulting number is the worker ID to be chosen.
    /// This algorithm is fast and creates a good work balance. Messages with the same partition key are always delivered in the same worker, so, message order is guaranteed.
    /// </summary>
    public class PartitionKeyDistributionStrategy : IDistributionStrategy
    {
        private IReadOnlyList<IWorker> workers;

        /// <inheritdoc />
        public void Init(IReadOnlyList<IWorker> workers)
        {
            this.workers = workers;
        }

        /// <inheritdoc />
        public Task<IWorker> GetWorkerAsync(byte[] messageKey, int partition, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this.workers[partition % this.workers.Count]);
        }
    }
}
