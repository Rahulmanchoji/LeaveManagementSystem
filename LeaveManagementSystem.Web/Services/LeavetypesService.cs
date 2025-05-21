using AutoMapper;
using AutoMapper.Configuration.Annotations;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.Leave_Types;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeavetypesService(ApplicationDbContext _context, IMapper _mapper) : ILeavetypesService
{
    public async Task<List<LeavetypeReadOnlyVM>> GetAll()
    {
        // var data = SELECT * FROM LeaveTypes
        var data = await _context.LeaveTypes.ToListAsync();
        // convert the datamodel into a view model - Use AutoMapper
        var viewData = _mapper.Map<List<LeavetypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T> Get<T>(int Id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == Id);
        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int Id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == Id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeavetypeEditVM model)
    {
        var leavetype = _mapper.Map<Leavetype>(model);
        _context.Update(leavetype);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeavetypeCreateVM model)
    {
        var Leavetype = _mapper.Map<Leavetype>(model);
        _context.Add(Leavetype);
        await _context.SaveChangesAsync();
    }

    public bool LeavetypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }


    public async Task<bool> CheckIfLeavetypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeavetypeNameExistsForEdit(LeavetypeEditVM leavetypeEdit)
    {
        var lowercaseName = leavetypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName)
            && q.Id != leavetypeEdit.Id);
    }
}
