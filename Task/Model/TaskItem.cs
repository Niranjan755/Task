using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskManagerAPI.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}