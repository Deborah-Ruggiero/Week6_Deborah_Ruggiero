using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    class DBManagerAgenti : IManager<Agente>
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        public void GetByYearOFService(int anniDiServizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select * from Agenti where AnnoInizioAttività <= @AnnoInizio";
                command.Parameters.AddWithValue("@AnnoInizio", anniDiServizio);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var cf = reader["CodiceFiscale"];
                    var areaGeografica = reader["AreaGeografica"];
                    var annoInizio = reader["AnnoInizioAttività"];


                }
                connection.Close();
            }
        
        }



        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agenti";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agentiDiPolizia = new List<Agente>();

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string codiceFiscale = (string)reader["CodiceFiscale"];
                    var areaGeografica = (string)reader["AreaGeografica"];
                    int annoInizio = (int)reader["AnnoInizioAttività"];

                    Agente a1 = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoInizio);
                    agentiDiPolizia.Add(a1);
                }
                connection.Close();
                return agentiDiPolizia;
            }
        }

        public Agente GetByGeographicArea(string areaGeografica)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agenti where AreaGeografica = @areaGeografica";
                command.Parameters.AddWithValue("@areaGeografica", areaGeografica);

                SqlDataReader reader = command.ExecuteReader();

                Agente agentiDiPolizia = null;


                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string codiceFiscale = (string)reader["CodiceFiscale"];
                    int annoInizio = (int)reader["AnnoInizioAttività"];

                    agentiDiPolizia = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoInizio);
                }
                connection.Close();
                return agentiDiPolizia;
            }
        }

       

        public bool GetByCF(string cf)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente";

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    string codiceFiscale = (string)reader["CodiceFiscale"];
                    if (codiceFiscale == cf)
                    {
                        return true;
                    }

                }

                connection.Close();

            }
            return false;

        }

        public void AddAgente(string nome, string cognome, string cf, string areaGeografica, int annoInizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agente values (@Nome, @Cognome, @CF, @AreaGeografica, @AnnoInizio)";
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Cognome", cognome);
                command.Parameters.AddWithValue("@CF", cf);
                command.Parameters.AddWithValue("@AreaGeografica", areaGeografica);
                command.Parameters.AddWithValue("@AnnoInizio", annoInizio);

                command.ExecuteNonQuery();

              

                connection.Close();
            }
        }
    }
    }


















