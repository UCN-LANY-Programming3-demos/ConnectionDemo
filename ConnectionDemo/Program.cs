using Microsoft.Data.SqlClient;

Console.WriteLine("Connection Demo");

SqlConnectionStringBuilder connStr = new();
connStr.DataSource = "localhost\\sqlexpress";
connStr.InitialCatalog = "ClientManager";
connStr.Encrypt = false;

connStr.IntegratedSecurity = true;

SqlConnection conn = new(connStr.ConnectionString);

SqlCommand cmd = conn.CreateCommand();
cmd.CommandText = "SELECT * FROM Customers";

conn.Open();

SqlDataReader reader = cmd.ExecuteReader();
while (reader.Read())
{
   

    Customer customer = new Customer();
    customer.Name = reader["Firstname"] + " " + reader["Lastname"];

    Console.WriteLine(customer);

}


conn.Close();

class Customer
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}