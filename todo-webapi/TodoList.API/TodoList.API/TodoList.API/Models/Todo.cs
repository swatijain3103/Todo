using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.API.Models
// step 1 creating models folder and then making file
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        // This is nullable field
        // A model is a class that represents data that the app manages.
    }
}
