using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace Moongathottathil_Camping.Models.db
{
    public class RepositoryAnfrageDB : IRepositoryAnfrage
    {
        private string _connectionString = "Server=localhost;Database=db_camp;Uid=root;Pwd=Sonic222;";
        private MySqlConnection _connection = null;
        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }
        public void Close()
        {
            if (this._connection != null && this._connection.State != ConnectionState.Closed)
            {
                this._connection.Close();
            }
        }

        public bool Insert(Campingplatzreservierung campres)
        {
            if(campres == null)
            {
                return false;
            }
            DbCommand cmdInsert = this._connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO camp VAlUES(null, @vorname, @nachname, @von, @bis, @geburtsdatum, @strasse, @plz, @ort, @telefonnummer, @email, @reservierplatz)";
            DbParameter paramVN = cmdInsert.CreateParameter();
            paramVN.ParameterName = "vorname";
            paramVN.Value = campres.Vorname;
            paramVN.DbType = DbType.String;

            DbParameter paramNN = cmdInsert.CreateParameter();
            paramNN.ParameterName = "nachname";
            paramNN.Value = campres.Nachname;
            paramNN.DbType = DbType.String;

            DbParameter paramV = cmdInsert.CreateParameter();
            paramV.ParameterName = "von";
            paramV.Value = campres.Von;
            paramV.DbType = DbType.Date;

            DbParameter paramB = cmdInsert.CreateParameter();
            paramB.ParameterName = "bis";
            paramB.Value = campres.Bis;
            paramB.DbType = DbType.Date;

            DbParameter paramGB = cmdInsert.CreateParameter();
            paramGB.ParameterName = "geburtsdatum";
            paramGB.Value = campres.Geburtsdatum;
            paramGB.DbType = DbType.Date;

            DbParameter paramSt = cmdInsert.CreateParameter();
            paramSt.ParameterName = "strasse";
            paramSt.Value = campres.Strasse;
            paramSt.DbType = DbType.String;

            DbParameter paramP = cmdInsert.CreateParameter();
            paramP.ParameterName = "plz";
            paramP.Value = campres.Plz;
            paramP.DbType = DbType.Int32;

            DbParameter paramO = cmdInsert.CreateParameter();
            paramO.ParameterName = "ort";
            paramO.Value = campres.Ort;
            paramO.DbType = DbType.String;

            DbParameter paramTN = cmdInsert.CreateParameter();
            paramTN.ParameterName = "telefonnummer";
            paramTN.Value = campres.Telefonnummer;
            paramTN.DbType = DbType.Int32;

            DbParameter paramEm = cmdInsert.CreateParameter();
            paramEm.ParameterName = "email";
            paramEm.Value = campres.Email;
            paramEm.DbType = DbType.String;

            DbParameter paramRP = cmdInsert.CreateParameter();
            paramRP.ParameterName = "reservierplatz";
            paramRP.Value = campres.Reservierplatz;
            paramRP.DbType = DbType.String;


            cmdInsert.Parameters.Add(paramVN);
            cmdInsert.Parameters.Add(paramNN);
            cmdInsert.Parameters.Add(paramV);
            cmdInsert.Parameters.Add(paramB);
            cmdInsert.Parameters.Add(paramGB);
            cmdInsert.Parameters.Add(paramSt);
            cmdInsert.Parameters.Add(paramP);
            cmdInsert.Parameters.Add(paramO);
            cmdInsert.Parameters.Add(paramTN);
            cmdInsert.Parameters.Add(paramEm);
            cmdInsert.Parameters.Add(paramRP);

            return cmdInsert.ExecuteNonQuery() == 1;
        }

        
    }
}