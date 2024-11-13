using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DearyDiary.Models
{
    public class DiaryEntry
    {
        [Key]
        public int UId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateModified { get; set; }
        
        public int UserId { get; set; }

    }
}
