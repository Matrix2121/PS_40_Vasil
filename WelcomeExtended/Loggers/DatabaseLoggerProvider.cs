﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended_.Loggers;

namespace WelcomeExtended.Loggers
{
    class DatabaseLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(categoryName);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
