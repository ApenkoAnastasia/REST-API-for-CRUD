using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace ProductLibrary
{
    public class ProductsProvider
    {
        private const string CONN_STRING = "Server=db;Port=3306;Database=product-db;Uid=root; Pwd=myPass;";
        private const string QUERY = "SELECT * FROM product";
        private const string GetId_QUERY = "SELECT * FROM product WHERE id = {0}";
        private const string Create_QUERY = "INSERT INTO product (Name, Description) VALUES ('{0}', '{1}')";
        private const string Modify_QUERY = "UPDATE product SET name = '{1}', description = '{2}'  WHERE id = {0}";
        private const string Delete_QUERY = "DELETE FROM product WHERE id = {0}";


        public Product[] GetAll()
        {
            using (var connection = new MySqlConnection(CONN_STRING))
            {
                return connection.Query<Product>(QUERY).ToArray();
            }
        }

        public Product GetById(int id)
        {
            using (var connection = new MySqlConnection(CONN_STRING))
            {
                string query = string.Format(GetId_QUERY, id);
                return connection.Query<Product>(query).FirstOrDefault();
            }
        }

        public Product Create(Product product)
        {
            using (var connection = new MySqlConnection(CONN_STRING))
            {
                string name = product.Name;
                string description = product.Description;

                string query = string.Format(Create_QUERY, name, description);

                return connection.Query<Product>(query).FirstOrDefault(x => x.Name == name);
            }
        }

        public Product Modify(int id, Product modifiedProduct)
        {
            using (var connection = new MySqlConnection(CONN_STRING))
            {
                string name = modifiedProduct.Name;
                string description = modifiedProduct.Description;
                string query = string.Format(Modify_QUERY, id, name, description);
                   
                return connection.Query<Product>(query).FirstOrDefault(x => x.Id == id); 
            }
            
        }

        public bool Delete(int id)
        {
            using (var connection = new MySqlConnection(CONN_STRING))
            {
                string query = String.Format(Delete_QUERY, id);

                return connection.Query<Product>(query).Any(x => x.Id == id);
            }
        }

    }
}
