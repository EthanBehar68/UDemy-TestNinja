using System;

namespace UDemyTestNinja.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }
}