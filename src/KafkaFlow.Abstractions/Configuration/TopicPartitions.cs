namespace KafkaFlow.Configuration
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes topic partitions.
    /// </summary>
    public class TopicPartitions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TopicPartitions"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="partitions"></param>
        public TopicPartitions(string name, IEnumerable<int> partitions)
        {
            this.Name = name;
            this.Partitions = partitions;
        }

        /// <summary>
        /// Topic name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Partitions.
        /// </summary>
        public IEnumerable<int> Partitions { get; }
    }
}
