using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimhoppNET5.Data
{
    public class ScoreServices : IScoreServices
    {
        private readonly SqlConnectionConfiguration _configuration;

        public ScoreServices(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ScoreAdd(Scores scores)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Dive1_Judge1_result", scores.Dive1_Judge1_result, DbType.Single);
                parameters.Add("Dive1_Judge2_result", scores.Dive1_Judge2_result, DbType.Single);
                parameters.Add("Dive1_Judge3_result", scores.Dive1_Judge3_result, DbType.Single);
                parameters.Add("Dive1_Difficulty", scores.Dive1_Difficulty, DbType.Single);
                parameters.Add("Dive1_Total_results", scores.Dive1_Total_results, DbType.Single);

                parameters.Add("Dive2_Judge1_result", scores.Dive2_Judge1_result, DbType.Single);
                parameters.Add("Dive2_Judge2_result", scores.Dive2_Judge2_result, DbType.Single);
                parameters.Add("Dive2_Judge3_result", scores.Dive2_Judge3_result, DbType.Single);
                parameters.Add("Dive2_Difficulty", scores.Dive2_Difficulty, DbType.Single);
                parameters.Add("Dive2_Total_results", scores.Dive2_Total_results, DbType.Single);

                parameters.Add("Dive3_Judge1_result", scores.Dive3_Judge1_result, DbType.Single);
                parameters.Add("Dive3_Judge2_result", scores.Dive3_Judge2_result, DbType.Single);
                parameters.Add("Dive3_Judge3_result", scores.Dive3_Judge3_result, DbType.Single);
                parameters.Add("Dive3_Difficulty", scores.Dive3_Difficulty, DbType.Single);
                parameters.Add("Dive3_Total_results", scores.Dive3_Total_results, DbType.Single);

                parameters.Add("Final_Total", scores.Final_Total, DbType.Single);
                await conn.ExecuteAsync("spScore_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;

        }

     
        public async Task<IEnumerable<Scores>> ScoreList()
        {
            IEnumerable<Scores> scores;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                scores = await conn.QueryAsync<Scores>("spScore_GetAll", commandType: CommandType.StoredProcedure);
            }
            return scores;

        }




        

        public async Task<Scores> Score_GetOne(int SCID)
        {
            Scores score = new Scores();
            var parameters = new DynamicParameters();
            parameters.Add("SCID", SCID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                score = await conn.QueryFirstOrDefaultAsync<Scores>("spScore_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }
            return score;
        }



        public async Task<bool> ScoreUpdate(Scores scores)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();

                parameters.Add("SCID", scores.SCID, DbType.Int32);
                parameters.Add("Dive1_Judge1_result", scores.Dive1_Judge1_result, DbType.Single);
                parameters.Add("Dive1_Judge2_result", scores.Dive1_Judge2_result, DbType.Single);
                parameters.Add("Dive1_Judge3_result", scores.Dive1_Judge3_result, DbType.Single);
                parameters.Add("Dive1_Difficulty", scores.Dive1_Difficulty, DbType.Single);
                parameters.Add("Dive1_Total_results", scores.Dive1_Total_results, DbType.Single);

                parameters.Add("Dive2_Judge1_result", scores.Dive2_Judge1_result, DbType.Single);
                parameters.Add("Dive2_Judge2_result", scores.Dive2_Judge2_result, DbType.Single);
                parameters.Add("Dive2_Judge3_result", scores.Dive2_Judge3_result, DbType.Single);
                parameters.Add("Dive2_Difficulty", scores.Dive2_Difficulty, DbType.Single);
                parameters.Add("Dive2_Total_results", scores.Dive2_Total_results, DbType.Single);

                parameters.Add("Dive3_Judge1_result", scores.Dive3_Judge1_result, DbType.Single);
                parameters.Add("Dive3_Judge2_result", scores.Dive3_Judge2_result, DbType.Single);
                parameters.Add("Dive3_Judge3_result", scores.Dive3_Judge3_result, DbType.Single);
                parameters.Add("Dive3_Difficulty", scores.Dive3_Difficulty, DbType.Single);
                parameters.Add("Dive3_Total_results", scores.Dive3_Total_results, DbType.Single);
                parameters.Add("Final_Total", scores.Final_Total, DbType.Single);

                await conn.ExecuteAsync("spScore_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;

        }


    }
}



