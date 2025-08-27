public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        if(data.ToLower() == "good write"){
            database.BeginTransaction();
            database.Write(data);
            Database.lastData = data;
            database.EndTransaction();
            database.Dispose();
        }
        else{
            Database.lastData = data;
            database.Dispose();
            throw new InvalidOperationException($"an exception is thrown but database is left with an internal state of {Database.State.Closed}");
        }
    }

    public bool WriteSafely(string data)
    {
        try{
            Write(data);
            return true;
        }
        catch(InvalidOperationException){
            return false;
        }
    }
}
