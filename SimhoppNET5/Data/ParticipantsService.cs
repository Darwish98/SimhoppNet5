using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SimhoppNET5.Data
{
    public class ParticipantsService : IParticipantsService
    {
        //Databas conncetion
        private readonly SqlConnectionConfiguration _configuration;

        public ParticipantsService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }


        //add a partipant table row( SQL insert)

        public async Task<bool> ParticipantsInsert(Participants participants)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("FirstName", participants.FirstName, DbType.String);
                parameters.Add("LastName", participants.LastName, DbType.String);
                parameters.Add("Age", participants.Age, DbType.Int32);
                parameters.Add("EmailAddress", participants.EmailAddress, DbType.String);
                parameters.Add("club", participants.club, DbType.String);
                parameters.Add("Dive_Group", participants.Dive_Group, DbType.String);
                parameters.Add("Dive_position", participants.Dive_position, DbType.String);
                parameters.Add("Init_position", participants.Init_position, DbType.String);
                parameters.Add("half_somersaults", participants.half_somersaults, DbType.String);





                //Using stored procedure to avoid sql command inside the code

                await conn.ExecuteAsync("spParticipants_Insert", parameters, commandType : CommandType.StoredProcedure);


                // RAW SQL method

                //const string query = @"INSERT INTO Participants (FirstName, LastName , Age, EmailAddress) VALUES (@FirstName, @LastName, @Age , @EmailAddress)";
                //await conn.ExecuteAsync(query, new { participants.FirstName, participants.LastName, participants.Age, participants.EmailAddress }, commandType: CommandType.Text);
            }
            return true;


        }

        public async Task<IEnumerable<Participants>> ParticipantsList()
        {
            IEnumerable<Participants> participants;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participants = await conn.QueryAsync<Participants>("spParticipants_GetAll", commandType: CommandType.StoredProcedure);
            }
            return participants;

        }

        public async Task<IEnumerable<Participants>>Top32()
        {
            IEnumerable<Participants> participants;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participants = await conn.QueryAsync<Participants>("spParticipants_GetTop32", commandType: CommandType.StoredProcedure);
            }
            return participants;

        }
        public async Task<IEnumerable<Participants>> Top16()
        {
            IEnumerable<Participants> participants;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participants = await conn.QueryAsync<Participants>("spParticipants_GetTop16", commandType: CommandType.StoredProcedure);
            }
            return participants;

        }
        public async Task<IEnumerable<Participants>> Top8()
        {
            IEnumerable<Participants> participants;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participants = await conn.QueryAsync<Participants>("spParticipants_GetTop8", commandType: CommandType.StoredProcedure);
            }
            return participants;

        }
        public async Task<IEnumerable<Participants>> Top3()
        {
            IEnumerable<Participants> participants;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participants = await conn.QueryAsync<Participants>("spParticipants_GetTop3", commandType: CommandType.StoredProcedure);
            }
            return participants;

        }

        //Get on participant based on its ID 

        public async Task<Participants> Participants_GetOne(int ID)
        {
            Participants participant = new Participants();
            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                participant = await conn.QueryFirstOrDefaultAsync<Participants>("spParticipants_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }
            return participant;
        }

        //Update one row based on ID

        public async Task<bool> ParticipantsUpdate(Participants participants)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", participants.ID, DbType.Int32);
                parameters.Add("FirstName", participants.FirstName, DbType.String);
                parameters.Add("LastName", participants.LastName, DbType.String);
                parameters.Add("Age", participants.Age, DbType.Int32);
                parameters.Add("EmailAddress", participants.EmailAddress, DbType.String);
                parameters.Add("club", participants.club, DbType.String);
                parameters.Add("Dive_Group", participants.Dive_Group, DbType.String);
                parameters.Add("Dive_position", participants.Dive_position, DbType.String);
                parameters.Add("Init_position", participants.Init_position, DbType.String);
                parameters.Add("half_somersaults", participants.half_somersaults, DbType.String);


                //Using stored procedure to avoid sql command inside the code

                await conn.ExecuteAsync("spParticipants_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;


        }

        public async Task<bool> ParticipantsDelete(int ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("spParticipants_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;

        }
    }
}
