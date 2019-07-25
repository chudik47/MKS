﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Nedo_net.Database
{
    public class SQLcommands
    {
        SqlConnection conn;

        public SQLcommands()
        {
            conn = DBUtils.GetDBConnection();
            conn.Open();
        }

        public IEnumerable<T> SelectAll<T>(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            List<T> items = new List<T>();

            foreach (var row in dataTable.Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                items.Add(item);
            }

            return items;
        }

        public T Select<T>(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            T item = (T)Activator.CreateInstance(typeof(T), dataTable.Rows[0]);

            return item;

        }

        public void Insert<T> (string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
        }

        public void Delete<T> (string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
        }

        public void Update<T>(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
        }
    }
}
