﻿using Infra.NLogger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.Shared
{
    static class TestExtensions
    {
        [AssemblyInitialize]
        public static void ConfigurarLog()
        {
            NLogger.Logger.Factory.CreateNullLogger();
        }
        public static string ResetId(string tableName)
        {
            return $@"DELETE FROM {tableName} DBCC CHECKIDENT('[{tableName}]', RESEED, 0)";
        }
    }
}
