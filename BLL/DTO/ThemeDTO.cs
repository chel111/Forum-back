﻿using System;
using System.Collections.Generic;


namespace BLL.DTO
{
    public class ThemeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public AuthorDTO Author { get; set; }
        public IEnumerable<string> Hashtags { get; set; }
    }
}
