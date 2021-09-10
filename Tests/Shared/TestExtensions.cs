﻿namespace Tests.Shared
{
    static class TestExtensions
    {
        public static string ResetId(string tableName)
        {
            return $@"DELETE FROM {tableName} DBCC CHECKIDENT('[{tableName}]', RESEED, 0)";
        }
    }
}
