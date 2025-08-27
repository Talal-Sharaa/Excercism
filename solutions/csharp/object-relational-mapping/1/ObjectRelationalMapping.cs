public class Orm:IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if (database.DbState != Database.State.Closed)
        {
            throw new InvalidOperationException($"database has an internal state of {database.DbState}");
        }
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        if (database.DbState == Database.State.TransactionStarted)
        {
            database.lastData = data;

            if (data == "bad write" || data == "bad commit")
            {
                Dispose();
            }
            else
            {
                database.Write(data);
            }
        }
    }

    public void Commit()
    {
        if (database.DbState == Database.State.DataWritten)
        {
            database.EndTransaction();
        }
        else if (database.DbState == Database.State.TransactionStarted)
        {
            throw new InvalidOperationException($"database has an internal state of {database.DbState}");
        }
    }
    public void Dispose(){
        database.Dispose();
    }
}