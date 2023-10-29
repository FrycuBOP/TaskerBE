namespace Tasker.TaskManager.Domain.Entities
{
    public class TaskModel
    {
        public required Guid Id { get; init; }
            = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime Created { get; init; }
        = DateTime.UtcNow;
        public DateTime? LastModified { get; set; } = null;
        public string? ModifiedReason { get; set; }
        public decimal EstimatedTime { get; set; } = 0;
        public string? Owner { get; set; }

        public TaskModel()
        {

        }
        private TaskModel(string name, string desc, decimal estimatedTime, string? owner)
        {
            Name = name;
            Description = desc;
            EstimatedTime = estimatedTime;
            Owner = owner;
        }

        //public Task CreateTask(string name, string desc, decimal estimatedTime, string? owner)
        //{

        //}
    }
}
