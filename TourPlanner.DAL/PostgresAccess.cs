﻿using Npgsql;
using System;

namespace TourPlanner.DAL
{
    /*
     *  Access to postgres DB via ADO.NET
     *  Singelton, Lazy initialization
     */
    public sealed class PostgresAccess : IDisposable
    {
        private static readonly Lazy<PostgresAccess> lazy = new Lazy<PostgresAccess>(() => new PostgresAccess());
        public static PostgresAccess Instance { get { return lazy.Value; } }

        private NpgsqlConnection _connection;

        private PostgresAccess()
        {
            try
            {
                _connection = new NpgsqlConnection("Host=localhost;Username=docker;Password=pass123;Database=tourplannerdb;Port=5432");
                _connection.Open();

            }
            catch (System.Exception e)
            {
                Console.WriteLine($"[{DateTime.UtcNow}]\tError connecting to PostgresDB: {e.Message}");
                throw; 
            }

            Console.WriteLine($"[{DateTime.UtcNow}]\tConnection to PostgresDB established.");
        }

        public NpgsqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}