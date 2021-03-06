﻿using System;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public AuthorDTO Author { get; set; }
        public bool HasReplies { get; set; } = false;
        public int? ReplyMessageId { get; set; } = null;

    }
}
