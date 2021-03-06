﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [DisplayName("Event Start")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss tt}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Event Start Time is Required")]
        public DateTime EventFromDateAndTime { get; set; }
        [DisplayName("Event End")]
        [Required(ErrorMessage = "Event End Time is Required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime EventToDateAndTime { get; set; }
        [DisplayName("Created by")]
        public string EnteredByUsername { get; set; }

        [DisplayName("Activity ID")]
        public int ActivityCategoryId { get; set; }
        [DisplayName("Activity")]
        public ActivityCategory ActivityCategory { get; set; }

        [DisplayName("Created on")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
