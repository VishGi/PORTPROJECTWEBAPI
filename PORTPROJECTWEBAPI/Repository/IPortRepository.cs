using PORTPROJECTWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTPROJECTWEBAPI.Repository
{
    public interface IPortRepository
    {
        Task<List<SlotClass>> GetAvalSlotsAsync();
        Task<UserClass> AddUserAsync(UserClass usersModel);
        Task UpdateSlot(int slotId, SlotClass slotsModel);
    }
}
