namespace KafkaFlow.Consumers.DistributionStrategies
{
    using System;

    /// <inheritdoc cref="MessageKeyBytesSumDistributionStrategy"/>
    [Obsolete("The type is obsolete and will be removed in future. Use 'KafkaFlow.Consumers.DistributionStrategies.MessageKeyBytesSumDistributionStrategy' instead.")]
    public class BytesSumDistributionStrategy : MessageKeyBytesSumDistributionStrategy
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BytesSumDistributionStrategy"/>.
        /// </summary>
        public BytesSumDistributionStrategy() :
            base()
        {

        }
    }
}
