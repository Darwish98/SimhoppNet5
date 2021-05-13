using System.Threading.Tasks;

namespace SimhoppNET5.Data
{
    public interface ICompetitionServices
    {
        Task<CompetitionStatus> GetStatus();
        Task<bool> StatusUpdate(CompetitionStatus competitionStatus);
    }
}