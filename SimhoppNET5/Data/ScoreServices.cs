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

        public async Task<bool> ScoreAdd(Scores score)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Judge1_result", score.Judge1_result, DbType.Single);
                parameters.Add("Judge2_result", score.Judge2_result, DbType.Single);
                parameters.Add("Judge3_result", score.Judge3_result, DbType.Single);
                parameters.Add("Total_results", score.Total_results, DbType.Single);
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




        

        public async Task<Scores> Score_GetOne(int Score_ID)
        {
            Scores score = new Scores();
            var parameters = new DynamicParameters();
            parameters.Add("Score_ID", Score_ID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                score = await conn.QueryFirstOrDefaultAsync<Scores>("spScore_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }
            return score;
        }



        public async Task<bool> ScoreUpdate(Scores score)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Score_ID", score.Score_ID, DbType.Int32);
                parameters.Add("Judge1_result", score.Judge1_result, DbType.Single);
                parameters.Add("Judge2_result", score.Judge2_result, DbType.Single);
                parameters.Add("Judge3_result", score.Judge3_result, DbType.Single);
                parameters.Add("Difficulty", score.Difficulty, DbType.Single);
                parameters.Add("Total_results", score.Total_results, DbType.Single);
                await conn.ExecuteAsync("spScore_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;

        }


    }
}



