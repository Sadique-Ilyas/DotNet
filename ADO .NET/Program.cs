using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConnectToDatabase();

            // Holds the Console Window
            Console.ReadLine();
        }

        static void ConnectToDatabase()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Yeyyy....Connection Established !!!\n\n");
                    }

                    // SELECT
                    //               string query = "SELECT * FROM Employees WHERE EmployeeID = @id";
                    //               SqlCommand comm = new SqlCommand(query, conn);
                    //comm.Parameters.AddWithValue("@id", 5);
                    //SqlDataReader reader = comm.ExecuteReader();

                    //               Console.WriteLine("SELECT");
                    //               while (reader.Read())
                    //               {
                    //                   Console.WriteLine("Id: " + reader["EmployeeID"] +
                    //                                     " Name: " + reader["FirstName"] + " " + reader["LastName"]);
                    //               }

                    // SELECT (Stored Procedure)
                    //string query = "spGetAllEmployees";
                    //SqlCommand comm = new SqlCommand(query, conn);
                    //comm.CommandType = CommandType.StoredProcedure;
                    //SqlDataReader reader = comm.ExecuteReader();

                    //Console.WriteLine("SELECT (Stored Procedure)");
                    //while (reader.Read())
                    //{
                    //    Console.WriteLine("Id: " + reader["EmployeeID"] +
                    //                      " Name: " + reader["FirstName"] + " " + reader["LastName"]);
                    //}

                    // INSERT
                    //Console.WriteLine("INSERT");
                    //Console.WriteLine("Enter First Name: ");
                    //string? firstName = Console.ReadLine();
                    //Console.WriteLine("Enter Last Name: ");
                    //string? lastName = Console.ReadLine();

                    //SqlCommand comm = new SqlCommand("INSERT INTO Employees(LastName,FirstName) VALUES(@LastName, @FirstName)", conn);
                    //comm.Parameters.AddWithValue("@LastName", lastName);
                    //comm.Parameters.AddWithValue("@FirstName", firstName);

                    //int rows = comm.ExecuteNonQuery();
                    //if (rows > 0) Console.WriteLine("\n\nData Inserted Successfully");
                    //else Console.WriteLine("\n\nProblem inserting Data");

                    // UPDATE
                    //Console.WriteLine("UPDATE");
                    //Console.WriteLine("Enter Employee ID: ");
                    //string? empId = Console.ReadLine();
                    //Console.WriteLine("Enter First Name: ");
                    //string? firstName = Console.ReadLine();
                    //Console.WriteLine("Enter Last Name: ");
                    //string? lastName = Console.ReadLine();

                    //SqlCommand comm = new SqlCommand("UPDATE Employees SET LastName = @LastName, FirstName = @FirstName WHERE EmployeeID = @EmpId", conn);
                    //comm.Parameters.AddWithValue("@EmpId", empId);
                    //comm.Parameters.AddWithValue("@LastName", lastName);
                    //comm.Parameters.AddWithValue("@FirstName", firstName);

                    //int rows = comm.ExecuteNonQuery();
                    //if (rows > 0) Console.WriteLine("\n\nData Updated Successfully");
                    //else Console.WriteLine("\n\nProblem updating Data");

                    // DELETE
                    //Console.WriteLine("DELETE");
                    //Console.WriteLine("Enter Employee ID: ");
                    //string? empId = Console.ReadLine();

                    //SqlCommand comm = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmpId", conn);
                    //comm.Parameters.AddWithValue("@EmpId", empId);

                    //int rows = comm.ExecuteNonQuery();
                    //if (rows > 0) Console.WriteLine("\n\nData Deleted Successfully");
                    //else Console.WriteLine("\n\nProblem deleting Data");

                    // Aggregate Function (Product with max unit price)
                    //SqlCommand comm = new SqlCommand("SELECT MIN(UnitPrice) FROM Products", conn);

                    //decimal unitPrice = (decimal)comm.ExecuteScalar();

                    //Console.WriteLine(unitPrice);

                    // Aggregate Function (Product Average unit price)
                    //SqlCommand comm = new SqlCommand("SELECT AVG(UnitPrice) FROM Products", conn);

                    //decimal unitPrice = (decimal)comm.ExecuteScalar();

                    //Console.WriteLine("Product Average unit price" + unitPrice);

                    // SQlDataReader methods
                    //string query = "SELECT * FROM Employees;";
                    //SqlCommand comm = new SqlCommand(query, conn);
                    //using (SqlDataReader reader = comm.ExecuteReader())
                    //{

                    //    Console.WriteLine("Get number of columns in current row - " + reader.FieldCount);
                    //    Console.WriteLine("Get datatype of column at index 5 - " + reader.GetFieldType(5));
                    //    Console.WriteLine("Checks if there are any rows then return true, else false - " + reader.HasRows);
                    //    Console.WriteLine("Checks if SQLdatareader instance is closed - " + reader.IsClosed);

                    //    while (reader.Read())
                    //    {
                    //        try
                    //        {
                    //            Console.WriteLine("Get values of column at index 5 - " + reader.GetFieldValue<DateTime>(5));
                    //        }
                    //        catch (SqlNullValueException ex)
                    //        {
                    //            Console.WriteLine(ex.Message);
                    //        }
                    //    }
                    //}

                    // Execute multiple queries using NextResult()
                    //string query = "SELECT * FROM Employees; SELECT * FROM Customers;";
                    //SqlCommand comm = new SqlCommand(query, conn);
                    //using (SqlDataReader reader = comm.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        Console.WriteLine("#" + reader[0] + " " + reader[1] + " " + reader[2]);
                    //    }
                    //    Console.WriteLine("===============================================");
                    //    if(reader.NextResult())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            Console.WriteLine("#" + reader[0] + " " + reader[1] + " " + reader[2]);
                    //        }
                    //    }
                    //}

                    // SqlDataAdapter (DataSet)
                    // With SqlDataAdapter class, we don't need to worry about opening and closing the SqlConnection
                    //string query = "SELECT * FROM Employees; SELECT * FROM Customers;";
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    //DataSet dataSet = new DataSet();
                    //dataAdapter.Fill(dataSet);
                    //foreach (DataTable table in dataSet.Tables)
                    //{
                    //    Console.WriteLine("\n==================================================");
                    //    foreach (DataRow row in table.Rows)
                    //    {
                    //        Console.WriteLine("#" + row[0] + " " + row[1] + " " + row[2]);
                    //    }
                    //}

                    // LINQ to DataSets
                    //Console.WriteLine("\n\n--------------USING LINQ ON DATASETS----------------");
                    //var resultRows = from DataRow rows in dataSet.Tables[0].AsEnumerable() where rows.Field<int>("EmployeeID") < 4 select rows;
                    //foreach (DataRow row in resultRows)
                    //{
                    //    Console.WriteLine("#" + row[0] + " " + row[1] + " " + row[2]);
                    //}


					// SqlDataAdapter (DataTables)
					//string query = "SELECT * FROM Employees;";
					//SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
					//DataTable dataTable = new DataTable();
					//dataAdapter.Fill(dataTable);

					//Console.WriteLine("\n\n--------------USING LINQ ON DATASETS----------------");
					//foreach (DataRow row in dataTable.Rows)
					//{
					//    Console.WriteLine("#" + row[0] + " " + row[1] + ", " + row[2]);
					//}

					// LINQ to DataTables
					//var resultRows = from DataRow row in dataTable.AsEnumerable() where row.Field<int>("EmployeeID") < 4 select row;

					//foreach (DataRow row in resultRows)
					//{
					//	Console.WriteLine("#" + row[0] + " " + row[1] + ", " + row[2]);
					//}

					// DataTable
					//DataTable dataTable = new DataTable();
					//dataTable.TableName = "DataTable Name";

					//DataColumn[] dataColumns = { 
					//    new DataColumn()
					//    {
					//        ColumnName = "ID",
					//        Unique = true,
					//        DataType = typeof(int),
					//        AutoIncrementSeed = 1,
					//        AutoIncrementStep = 1,
					//        AutoIncrement = true,
					//        AllowDBNull = false,
					//    },
					//    new DataColumn()
					//    {
					//        ColumnName = "Name",
					//        DataType = typeof(string),
					//        AllowDBNull = true,
					//        DefaultValue = "Unknown",
					//        MaxLength = 30
					//    },
					//    new DataColumn()
					//    {
					//        ColumnName = "Phone Number",
					//        DataType = typeof(string),
					//        AllowDBNull = true,
					//        MaxLength = 12
					//    }
					//};
					//dataTable.Columns.AddRange(dataColumns);

					//dataTable.Rows.Add(null, "Peter Parker", "46546456");
					//dataTable.Rows.Add(null, "Miles Morales", "34656562");
					//dataTable.Rows.Add(null, "Gwen Stacy", null);
					//dataTable.Rows.Add(null, null, null);

					//Console.WriteLine($"==================={dataTable.TableName}====================");
					//foreach (DataRow row in dataTable.Rows)
					//{
					//    Console.WriteLine($"#{row[0]} {row[1]} {row[2]}");
					//}

					//// Clone method of DataTable
					//DataTable clonedDataTable = new DataTable();
					//clonedDataTable = dataTable.Clone();
					//clonedDataTable.TableName = "Cloned Data Table";

					//clonedDataTable.Rows.Add(null, "Vin Diesel", "97846345");
					//clonedDataTable.Rows.Add(null, null, "34656562");
					//clonedDataTable.Rows.Add(null, "Gwen Stacy", null);
					//clonedDataTable.Rows.Add(null, null, null);

					//Console.WriteLine($"==================={clonedDataTable.TableName}====================");
					//foreach (DataRow row in clonedDataTable.Rows)
					//{
					//    Console.WriteLine($"#{row[0]} {row[1]} {row[2]}");
					//}

					//// Copy method of DataTable
					//DataTable copyDataTable = new DataTable();
					//copyDataTable = dataTable.Copy();
					//copyDataTable.TableName = "Copy Data Table";

					//Console.WriteLine($"==================={copyDataTable.TableName}=====================");
					//foreach (DataRow row in copyDataTable.Rows)
					//{
					//    Console.WriteLine($"#{row[0]} {row[1]} {row[2]}");
					//}

					//// DataSet
					//DataSet dataSet = new DataSet();
					//dataSet.DataSetName = "DataSet Name";

					//DataTable[] dataTables = { dataTable, clonedDataTable, copyDataTable };

					//dataSet.Tables.AddRange(dataTables);

					//Console.WriteLine($"==================={dataSet.DataSetName}====================");
					//foreach (DataTable table in dataSet.Tables)
					//{
					//    foreach (DataRow row in table.Rows)
					//    {
					//        Console.WriteLine($"#{row[0]} {row[1]} {row[2]}");
					//    }
					//}

					// DataSet (Stored Procedure)
					//SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetAllEmployees", conn);
					//dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					//DataSet dataSet = new DataSet();
					//dataSet.DataSetName = "DataSet Name";
					//dataAdapter.Fill(dataSet);

					//Console.WriteLine($"==================={dataSet.DataSetName} (Stored Procedure)====================");
					//foreach (DataTable table in dataSet.Tables)
					//{
					//    foreach (DataRow row in table.Rows)
					//    {
					//        Console.WriteLine($"#{row[0]} {row[1]} {row[2]}");
					//    }
					//}
				}
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (conn.State == ConnectionState.Closed)
            {
                Console.WriteLine("\n\nConnection Closed !");
            }
        }
    }
}
