using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SalamaEnterpriseCore.Models
{
    public class FormFields
    {
        private IConfiguration config;
        public FormFields()
        {

        }
        public FormFields(IConfiguration _config)
        {
            config = _config;
        }
        
        public Array dropDownFiller(string key, string param)
        {
            var ConnectionString = config.GetConnectionString("SalamaDB");
            string query = "";
            if (key != null || key != "")
            {
                query = DBQueries.getDDLQuery(key, param);
            }


            ArrayList fetchInner;
            ArrayList fetchOuter = new ArrayList();
            string str_TempValue = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand(query, connection);
                    SqlDataReader rdr = com.ExecuteReader();
                    DataTable schema = rdr.GetSchemaTable();
                    fetchInner = new ArrayList();
                    while (rdr.Read())
                    {
                        fetchInner = new ArrayList();
                        for (int i = 0; i < schema.Rows.Count; i++)
                        {
                            str_TempValue = rdr.GetValue(i).ToString();
                            fetchInner.Add(str_TempValue);
                        }
                        fetchOuter.Add(fetchInner.ToArray());
                    }
                    rdr.Close();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return fetchOuter.ToArray();
            }

        }
    }
}
