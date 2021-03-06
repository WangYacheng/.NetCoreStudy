﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Dang.Domain.Core
{
    public abstract class Command:Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
