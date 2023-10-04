namespace KafkaFlow.Consumers.DistributionStrategies
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This strategy sums all bytes in the partition key and apply a mod operator with the total number of workers, the resulting number is the worker ID to be chosen.
    /// This algorithm is fast and creates a good work balance. Message order is not guaranteed.
    /// </summary>
    public class MessageKeyBytesSumDistributionStrategy : IDistributionStrategy
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
            if (messageKey is null)
            {
                return Task.FromResult(this.workers[0]);
            }

            return Task.FromResult(
                cancellationToken.IsCancellationRequested
                    ? null
                    : this.workers.ElementAtOrDefault(messageKey.Sum(x => x) % this.workers.Count));
        }
    }
}
