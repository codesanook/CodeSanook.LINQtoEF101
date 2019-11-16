Rollback


ทำไมต้องมี rollback ทั้งๆ ที่ commit ไม่ได้ successful หรือถูก call
-- case 1
With using and no error
using(db = new DbContext())
{
	1 SaveChanges
}
Opened connection at 9/30/2019 1:00:13 PM +07:00
Started transaction at 9/30/2019 1:00:13 PM +07:00
insert object
Committed transaction at 9/30/2019 1:00:13 PM +07:00
Closed connection at 9/30/2019 1:00:13 PM +07:00

-- case 2
With using and error
using(db = new DbContext())
{
	1 SaveChanges
}
Opened connection at 9/30/2019 1:00:13 PM +07:00
Started transaction at 9/30/2019 1:00:13 PM +07:00
//No rollback but close the connection release the resource and lock on table
Closed connection at 9/30/2019 1:00:13 PM +07:00

-- case 3 with explicit start transaction, commit but not rollback and error at application code
using (var db = new NoteDbContext())
{
    db.Database.Log = Console.WriteLine;
    using (var transaction = db.Database.BeginTransaction())
    {
    try
    {
    var notebook = new Notebook()
    {
        Name = "Programming Tips"
    };
    db.Notebooks.Add(notebook);
    db.SaveChanges();
    //Fake application exception
    throw new Exception("application error");
    transaction.Commit();
}
catch (Exception ex)
{
//not roll back here
}
finally
{
transaction.Commit();
//It is possible that a driver implmentation can commit before closing a connection.
//This will leave an invalid state, in this example it will save a notebook which is not what we want
//because an error is from application code not a database.
//If a connection is reuse and last long, we can minimize the lock of table by calling rollback immediately
}
}
}
more info
https://dba.stackexchange.com/.../if-you-dont-rollback-a...
https://stackoverflow.com/a/9644783/1872200
