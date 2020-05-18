using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;
using Nefa.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nefa.Data
{
    public class ModelContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ModelContext()
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Model-Data;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public IEnumerable<DataModel> GetAllData()
        {
            IEnumerable<DataModel> data;
            using IDbConnection dbConnection = _connection;
            try
            {
                string query = @"SELECT *
                                FROM [dbo].[tblModel]";

            data = dbConnection.Query<DataModel>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }
            return data;
        }

        public int Update(DataModel model)
        {
            int data;
            using IDbConnection dbConnection = _connection;
            try
            {
                string query = @"UPDATE [dbo].[tblModel] SET  cariKod = @cariKod,  cariIsim = @cariIsim,  
                                                          adres = @adres,  ilceKod = @ilceKod,  ilceAdi = @ilceAdi,  ilKod = @ilKod,  ilAdi = @ilAdi,  ulkeKodu = @ulkeKodu,  ulkeAdi = @ulkeAdi,  telefonNumara = @telefonNumara,   tip = @tip,
                                                          faxNumara = @faxNumara,  vergiDairesi = @vergiDairesi, vergiDairesiNo =  @vergiDairesiNo,  tcKimlikNumarası = @tcKimlikNumarası,  postakodu = @postakodu,  emailAdres = @emailAdres,  webAdres = @webAdres
                                  WHERE id = @id";

                data = dbConnection.Execute(query, model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }
            return data;
        }

        public int Delete(DataModel model)
        {
            int data;
            using IDbConnection dbConnection = _connection;
            try
            {
                string query = @"DELETE FROM [dbo].[tblModel]
                                WHERE id = @id";

                data = dbConnection.Execute(query, model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return data;
        }

        public int Insert(DataModel model)
        {
            int data;
            using IDbConnection dbConnection = _connection;
            try
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                string query = @"INSERT INTO [dbo].[tblModel] (cariKod,  cariIsim,  adres,  ilceKod,  ilceAdi,  ilKod,  ilAdi,  ulkeKodu,  ulkeAdi,  telefonNumara,  faxNumara,  vergiDairesi, vergiDairesiNo,  tcKimlikNumarası,  postakodu,  emailAdres,  webAdres, tip)
                                                  VALUES (@cariKod, @cariIsim, @adres, @ilceKod, @ilceAdi, @ilKod, @ilAdi, @ulkeKodu, @ulkeAdi, @telefonNumara, @faxNumara, @vergiDairesi, @vergiDairesiNo, @tcKimlikNumarası, @postakodu, @emailAdres, @webAdres, @tip)";

                data = dbConnection.Execute(query, model);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }
            return data;
        }
        public DataModel GetData(DataModel model)
        {
            DataModel data = new DataModel();
            using IDbConnection dbConnection = _connection;
            try
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", model.id);
                parameters.Add("cariKod", model.cariKod);
                string query = @"SELECT *
                                FROM [dbo].[tblModel]
                                WHERE ([Id] = @Id OR @id = 0) 
                                  AND ([cariKod] = @cariKod OR @cariKod = NULL)";

                data = dbConnection.QueryFirstOrDefault<DataModel>(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return data;
        }
    }
}