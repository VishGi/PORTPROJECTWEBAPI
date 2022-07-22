using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PORTPROJECTWEBAPI.Data;
using PORTPROJECTWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTPROJECTWEBAPI.Repository
{
    public class PortRepository:IPortRepository
    {
        private readonly SlotUserContext _Context;
        private readonly IMapper mapper;

        public PortRepository(SlotUserContext context, IMapper mapper)
        {
            this._Context = context;
            this.mapper = mapper;
        }
        public async Task UpdateSlot(int slotId, SlotClass slotsModel)
        {
            var slot = await _Context.PortSlotTable.FindAsync(slotId);
            if (slot != null)
            {
                slot.RUID = slotsModel.RUID;
                slot.Status = 0;
                slot.Cost = slot.Cost + slotsModel.Cost;
                slot.Sdate = slotsModel.Sdate;
                slot.Edate = slotsModel.Edate;
                await _Context.SaveChangesAsync();
            }
        }
        public async Task<List<SlotClass>> GetAvalSlotsAsync()
        {
            var records = await _Context.PortSlotTable.Where(x => x.Status == 1).Select(x => new SlotClass()
            {
                SlotId = x.SlotId,
                SLUserID=x.SLUserID,
                Status = x.Status


            }).ToListAsync();
            return records;
        }
        public async Task<UserClass> AddUserAsync(UserClass usersModel)
        {
            if (usersModel.UserType == "SL")
            {
                var user = new UserData()
                {
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    UserType = usersModel.UserType,
                    StartDate = usersModel.StartDate,
                    EndDate = usersModel.EndDate,
                    Cost = usersModel.Cost,
                };
                _Context.PortUserTable.Add(user);
                await _Context.SaveChangesAsync();
                var slot = new SlotData
                {
                    Status = 1,
                    SLUserID = user.ID,
                    RUID = 0
                };
                _Context.PortSlotTable.Add(slot);
                await _Context.SaveChangesAsync();
                return mapper.Map<UserClass>(user);
            }

            else
            {
                var user = new UserData()
                {
                    ID = usersModel.ID,
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    UserType = usersModel.UserType,
                };
                _Context.PortUserTable.Add(user);
                await _Context.SaveChangesAsync();
                return mapper.Map<UserClass>(user);
            };

        }


    }
}
