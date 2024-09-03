using System.ComponentModel.DataAnnotations;

namespace DigitalSolutionsStudio.Api.Db.Entities
{
    public record TaskEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TaskCompletionStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
