using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Datos.Servidor;

namespace Datos.Admin
{
    public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            string consulta = "SELECT Id, Nombre, Apellido, DNI, Comision FROM dbo.Vendedor";
            SqlCommand comando = new SqlCommand(consulta, AdminDB.ConectarBase());
            SqlDataReader reader;
            reader = comando.ExecuteReader();
            List<Vendedor> lista = new List<Vendedor>();
            while (reader.Read())
            {
                lista.Add(
                    new Vendedor()
                    {

                        Id = Convert.ToInt32(reader["Id"]),
                        Apellido = reader["Apellido"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Dni = reader["Dni"].ToString(),
                        Comision = Convert.ToDecimal(reader["Comision"])

                    });
            }
            AdminDB.ConectarBase().Close();
            reader.Close();
            return lista; 
        }

        public static DataTable TraerPorId(int id)
        {
            string consulta = "SELECT Id, Nombre, Apellido, Dni, Comision FROM dbo.Vendedor WHERE Id=@Id";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Id");
            return ds.Tables["Id"]; 
        }
        public static int Insertar(Vendedor v)
        {
            string insert = "INSERT dbo.Vendedor (Nombre, Apellido, Dni, Comision) VALUES (@Nombre, @Apellido, @Dni, @Comision)";
            SqlCommand comando = new SqlCommand(insert, AdminDB.ConectarBase());
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = v.Nombre;
            comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = v.Apellido;
            comando.Parameters.Add("@Dni", SqlDbType.Char, 11).Value = v.Dni;
            comando.Parameters.Add("@Comision", SqlDbType.Decimal, 18).Value = v.Comision;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas; 

        }

        public static DataTable TraerVendedores(decimal comision)
        {
            string consulta = "SELECT Id, Nombre, Apellido, Dni, Comision FROM dbo.Vendedor WHERE Comision=@Comision";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = comision;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Comision");
            return ds.Tables["Comision"]; 
        }

        public static int Eliminar(int id)
        {
            string deleteSQL = "DELETE FROM dbo.Vendedor WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(deleteSQL, AdminDB.ConectarBase());
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas; 
        }
        public static int Modificar(Vendedor v)
        {
            string update = "UPDATE dbo.Vendedor SET Nombre=@Nombre, Apellido=@Apellido, Comision=@Comision, Dni=@Dni WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(update, AdminDB.ConectarBase());
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = v.Nombre;
            comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = v.Apellido;
            comando.Parameters.Add("@Dni", SqlDbType.Char, 11).Value = v.Dni;
            comando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = v.Comision;
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = v.Id;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        public static DataTable listarComisiones()
        {
            string consultaSQL = "SELECT DISTINCT Comision from dbo.Vendedor";
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminDB.ConectarBase());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Comision");
            return ds.Tables["Comision"];
        }
    }
}
