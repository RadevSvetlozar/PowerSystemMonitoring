namespace PowerSystemMonitoring.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class EventInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Is active")]
        public bool IsActive { get; set; }
    }
}
