using Microsoft.Data.SqlClient;
using System.Transactions;

Console.WriteLine("Connection Demo");

SqlConnectionStringBuilder connStr = new();
connStr.DataSource = "localhost\\sqlexpress";
connStr.InitialCatalog = "ClientManager";
connStr.Encrypt = false; // Must be false
connStr.IntegratedSecurity = true;

SqlConnection conn = new(connStr.ConnectionString);
conn.Open();

//SqlTransaction trans = conn.BeginTransaction();

using TransactionScope scope = new TransactionScope();

try
{
    SqlCommand cmd = conn.CreateCommand();
    cmd.CommandText = "INSERT INTO Customers VALUES (@firstname, @lastname, @address, @zip, @city, @phone, @email)";
    cmd.Parameters.AddWithValue("firstname", "Hans");
    cmd.Parameters.AddWithValue("lastname", "Jensen");
    cmd.Parameters.AddWithValue("address", "Bondegård");
    cmd.Parameters.AddWithValue("zip", "9240");
    cmd.Parameters.AddWithValue("city", "Nibe");
    cmd.Parameters.AddWithValue("phone", "98351243");
    cmd.Parameters.AddWithValue("email", "hj@gyllegym.dk");
    //cmd.Transaction = trans;

    int rowsAffedted = cmd.ExecuteNonQuery();

    //trans.Commit();

    //scope.Complete();
}
catch (Exception ex)
{
    // LOG ERROR!!!
    //trans.Rollback();
   
}

