using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimhoppNET5.Data
{
    public interface IParticipantsService
    {
        Task<bool> ParticipantsInsert(Participants participants);

        Task<IEnumerable<Participants>> ParticipantsList();

        Task<Participants> Participants_GetOne(int ID);

        Task<bool> ParticipantsUpdate(Participants participants);

        Task<bool> ParticipantsDelete(int ID);

        Task<IEnumerable<Participants>> Top32();
        Task<IEnumerable<Participants>> Top16();
        Task<IEnumerable<Participants>> Top8();
        Task<IEnumerable<Participants>> Top3();
    }
}