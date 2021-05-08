using System.Threading.Tasks;
using System.Collections.Generic;


namespace SimhoppNET5.Data
{
    public interface IScoreServices
    {
        Task<bool> ScoreAdd(Scores score);
        Task<Scores> Score_GetOne(int Score_ID);
        Task<bool> ScoreUpdate(Scores score);
        Task<IEnumerable<Scores>> ScoreList();
    }
}