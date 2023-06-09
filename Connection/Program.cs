﻿using System;
using System.Data.SqlClient;

namespace Connection
{
    public class Program
    {
        private static SqlConnection connection { get; set; } = default!;

        private static string connectionString = "Data Source=OXE\\WULAN;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public static void Main()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection Open!");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed : " + e);
            }

            ////=================Region=================
            GetAllRegion();
            //GetByIdRegion(1);
            //InsertRegion("Region 5");
            //UpdateRegion(1001, "Region di Update 2");
            //DeleteRegion(1001);

            //=================Country=================
            //GetAllCountry(); 
            //GetByIdCountry("EG");
            //InsertCountry("NC", "New Country",4);
            //UpdateCountry("NC", "New Country di Update", 1);
            //DeleteCountry("NC");
        }

        //=========================Region=========================
        // GET ALL : Region
        public static void GetAllRegion()
        {
            // Membuat instance SQL Server Connection
            connection = new SqlConnection(connectionString);

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From regions;";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id : " + reader[0]);
                    Console.WriteLine("Name : " + reader[1]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Region is Empty!");
            }
            reader.Close();
            connection.Close();
        }
        // GET BY ID : Region
        public static void GetByIdRegios(int id)
        {
            // Membuat instance SQL Server Connection
            connection = new SqlConnection(connectionString);

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From regions Where id = @id;";

            // Membuat instance SQL Parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }
            reader.Close();
            connection.Close();
        }
        // INSERT : Region
        public static void InsertRegion(string name)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into regions (name) Values (@name);";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Insert Success!");
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        // UPDATE : Region
        public static void UpdateRegion(int id, string name)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update regions Set name = @name Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                command.Parameters.Add(pId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success!");
                }
                else
                {
                    Console.WriteLine($"id = {id} is not found!");
                }

                transaction.Commit();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        // DELETE : Region
        public static void DeleteRegion(int id)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete From regions Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                command.Parameters.Add(pId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success!");
                }
                else
                {
                    Console.WriteLine($"id = {id} is not found!");
                }

                transaction.Commit();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }
        //=========================Country=========================
        // GET ALL : Country
        public static void GetAllCountry()
        {
            // Membuat instance SQL Server Connection
            SqlConnection connection = new SqlConnection(connectionString);

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From countries;";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id : " + reader[0]);
                    Console.WriteLine("Name : " + reader[1]);
                    Console.WriteLine("region_id : " + reader[2]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Country is Empty!");
            }
            reader.Close();
            connection.Close();
        }

        // GET BY ID : Country
        public static void GetByIdCountry(string id)
        {
            // Membuat instance SQL Server Connection
            connection = new SqlConnection(connectionString);

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From countries Where id = @id;";

            // Membuat instance SQL Parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("region_id : " + reader[2]);
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }
            reader.Close();
            connection.Close();
        }
        // INSERT : Country
        public static void InsertCountry(string id, string name, int region_id)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into countries (id, name, region_id) Values (@id, @name, @region_id)SELECT SCOPE_IDENTITY()";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                command.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                SqlParameter pRegion_id = new SqlParameter();
                pRegion_id.ParameterName = "@region_id";
                pRegion_id.SqlDbType = System.Data.SqlDbType.VarChar;
                pRegion_id.Value = region_id;
                command.Parameters.Add(pRegion_id);

                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Insert Success!");
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        // UPDATE : Country
        public static void UpdateCountries(string id, string name)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update region Set name = @name Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                command.Parameters.Add(pId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success!");
                }
                else
                {
                    Console.WriteLine($"id = {id} is not found!");
                }

                transaction.Commit();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        // UPDATE : Country
        public static void UpdateCountry(string id, string name, int region_id)
        {
            connection = new SqlConnection(connectionString);

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update countries Set name = @name, region_id = @region_id Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                command.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                SqlParameter pRegion_id = new SqlParameter();
                pRegion_id.ParameterName = "@region_id";
                pRegion_id.SqlDbType = System.Data.SqlDbType.Int;
                pRegion_id.Value = region_id;
                command.Parameters.Add(pRegion_id);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success!");
                }
                else
                {
                    Console.WriteLine($"id = {id} is not found!");
                }
                transaction.Commit();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        public static void DeleteCountry(string id)
        {
            connection = new SqlConnection(connectionString);

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try 
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete From countries Where id = @id;";
                command.Transaction = transaction; 

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                command.Parameters.Add(pId); 

                int result = command.ExecuteNonQuery();
                if (result > 0) 
                {
                    Console.WriteLine("Delete Success!");
                }
                else
                {
                    Console.WriteLine($"id = {id} is not found!");
                }
                transaction.Commit();
                connection.Close();
            }
            catch (Exception e) 
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message); 
                }
            }
        }

    }
}

