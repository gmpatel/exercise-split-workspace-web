using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Dataract.e5.RACTi.WM.RequestManager
{
    public static class DbHelper
    {
        public static Database GetDatabase(string connectionString)
        {
            return new SqlDatabase(connectionString);
        }

        public static List<T> ExecuteStoredProcTrans<T>(Database database, string procName, object[] parameters) where T : new()
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            var connection = database.CreateConnection();

            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                using (connection)
                {
                    var transaction = connection.BeginTransaction();

                    try
                    {
                        var data = database.ExecuteSprocAccessor<T>(procName, parameters);

                        var ret = data.ToList();

                        transaction.Commit();

                        return ret;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            throw new Exception("Could not open database connection");
        }

        public static List<T> ExecuteStoredProc<T>(Database database, string procName, object[] parameters) where T : new()
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            var data = database.ExecuteSprocAccessor<T>(procName, parameters);

            return data.ToList();
        }

        public static DataSet ExecuteStoredProcTrans(Database database, string procName, object[] parameters)
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            var connection = database.CreateConnection();

            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                using (connection)
                {
                    var transaction = connection.BeginTransaction();

                    try
                    {
                        var data = database.ExecuteDataSet(procName, parameters);

                        transaction.Commit();

                        return data;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            throw new Exception("Could not open database connection");
        }

        public static DataSet ExecuteStoredProc(Database database, string procName, object[] parameters)
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            return database.ExecuteDataSet(procName, parameters);
        }

        public static object ExecuteStoredProcScalar(Database database, string procName, object[] parameters)
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            return database.ExecuteScalar(procName, parameters);
        }

        public static int ExecuteStoredProcNonQuery(Database database, string procName, object[] parameters)
        {
            FilterProcParams(ref parameters);

            //var database = GetDatabase();

            return database.ExecuteNonQuery(procName, parameters);
        }

        public static int ExecuteTextNonQuery(Database database, string query)
        {
            //var database = GetDatabase();

            return database.ExecuteNonQuery(CommandType.Text, query);
        }

        public static object ExecuteTextScalar(Database database, string query)
        {
            //var database = GetDatabase();

            return database.ExecuteScalar(CommandType.Text, query);
        }

        public static DataSet ExecuteText(Database database, string query)
        {
            //var database = GetDatabase();

            return database.ExecuteDataSet(CommandType.Text, query);
        }

        public static DataSet ExecuteTextTrans(Database database, string query)
        {
            //var database = GetDatabase();

            var connection = database.CreateConnection();

            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                using (connection)
                {
                    var transaction = connection.BeginTransaction();

                    try
                    {
                        var data = database.ExecuteDataSet(CommandType.Text, query);

                        transaction.Commit();

                        return data;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            throw new Exception("Could not open database connection");
        }

        public static List<T> ExecuteText<T>(Database database, string query) where T : new()
        {
            //var database = GetDatabase();

            var data = database.ExecuteSqlStringAccessor<T>(query);

            return data.ToList();
        }

        public static List<T> ExecuteTextTrans<T>(Database database, string query) where T : new()
        {
            //var database = GetDatabase();

            var connection = database.CreateConnection();

            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                using (connection)
                {
                    var transaction = connection.BeginTransaction();

                    try
                    {
                        var data = database.ExecuteSqlStringAccessor<T>(query);

                        transaction.Commit();

                        return data.ToList();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            throw new Exception("Could not open database connection");
        }

        private static void FilterProcParams(ref object[] parameters)
        {
            if (parameters.Length > 0)
            {
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = FilterProcParamValue(parameters[i]);
                }
            }
        }

        private static object FilterProcParamValue(object data)
        {
            if (data is DateTime)
            {
                if (((DateTime)data).Equals(DateTime.MinValue))
                    return null;

                return (DateTime)data;
            }

            if (data is Guid)
            {
                if (((Guid)data).Equals(Guid.Parse("{00000000-0000-0000-0000-000000000000}")))
                    return null;

                return (Guid)data;
            }

            if (data is int)
            {
                if (((int)data).Equals(0))
                    return null;

                return (int)data;
            }

            if (data is long)
            {
                if (((long)data).Equals(0))
                    return null;

                return (long)data;
            }

            if (data is double)
            {
                if (((double)data).Equals(0))
                    return null;

                return (double)data;
            }

            if (data is string)
            {
                var sdata = data.ToString();

                if (String.IsNullOrEmpty(sdata) || String.IsNullOrWhiteSpace(sdata))
                    return null;

                return sdata.Trim();
            }

            return data;
        }
    }
}