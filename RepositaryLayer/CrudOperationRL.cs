//using System.Data.SqlClient;
using System.Data.SqlClient;
using WebApplication4.CommomLayer.Model;


namespace WebApplication4.RepositaryLayer
{
    public class CrudOperationRL : ICrudOPerationRL
    {
        public readonly SqlConnection _sqlConnection;
        public CrudOperationRL(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse? response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "SuccessFull";
            try
            {
                string sqlQuery = "Insert Into CrudOperationTable(UserName, Age) values( @UserName, @Age)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Select UserName,Age,Id from CrudOperationTable;";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.UserName = sqlDataReader["UserName"] != DBNull.Value ? sqlDataReader["UserName"].ToString() : String.Empty;
                                dbData.Age = sqlDataReader["Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["Age"]): 0;
                                dbData.Id = sqlDataReader["Id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["Id"]) : 0;
                                response.readRecordData.Add(dbData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess= false;
                response.Message = ex.Message;  
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;

        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "Update CrudOperationTable Set UserName = @UserName, Age=@Age where Id = @Id";
                using (SqlCommand sqlcommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlcommand.CommandType = System.Data.CommandType.Text;
                    sqlcommand.CommandTimeout = 180;
                    sqlcommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlcommand.Parameters.AddWithValue("@Age", request.Age);
                    sqlcommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlcommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";  
                    }



                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally 
            {
                _sqlConnection.Close(); 
            }
            return response;
        }
        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse(); 
            response.IsSuccess = true;
            response.Message = "SuccessFully Deleted Record";
            try
            {
                string sqlQuery = "Delete from CrudOperationTable where Id=@Id";
                using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { 
                _sqlConnection.Close();
            }
            return response;
        }
    }
}
