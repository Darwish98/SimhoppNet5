using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SimhoppNET5.Data
{
    public class CompetitionServices : ICompetitionServices
    {
        private readonly SqlConnectionConfiguration _configuration;

        public CompetitionServices(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

      

        public async Task<bool> StatusUpdate(CompetitionStatus competitionStatus)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Value_", competitionStatus.Value_, DbType.Int32);
                await conn.ExecuteAsync("spCompetition_UpdateStatus", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;

        }
        public async Task<CompetitionStatus> GetStatus()
        {
            CompetitionStatus competitionStatus = new CompetitionStatus();
            var parameters = new DynamicParameters();
            using (var conn = new SqlConnection(_configuration.Value))
            {
                competitionStatus = await conn.QueryFirstOrDefaultAsync<CompetitionStatus>("spCompetition_GetStatus", parameters, commandType: CommandType.StoredProcedure);
            }
            return competitionStatus;
        }

    }
}
