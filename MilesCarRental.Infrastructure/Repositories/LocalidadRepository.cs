using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MilesCarRental.Domain.Entities;
using MilesCarRental.Domain.Repositories;
using MilesCarRental.Domain.Repositories;

public class LocalidadRepository : ILocalidadRepository
{
    private readonly SqlConnection _connection;

    public LocalidadRepository(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<List<Localidad>> ObtenerTodas()
    {
        List<Localidad> localidadesObj = new List<Localidad>();

        try
        {
            _connection.Open();
            string query = "SELECT * FROM Localidad";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                localidadesObj.Add(new Localidad
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = Convert.ToString(reader["Nombre"])
                });
            }
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            _connection.Close();
        }

        // Devolver la lista de localidades envuelta en una tarea completada
        return await Task.FromResult(localidadesObj);
    }

}
