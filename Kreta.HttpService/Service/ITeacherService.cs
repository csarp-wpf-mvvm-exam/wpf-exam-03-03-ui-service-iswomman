using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.HttpService.Service
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> SelectAllTeacher();
        public Task<ControllerResponse> UpdateAsync(Teacher teacherdto);
        public Task<ControllerResponse> DeleteAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Teacher teacher);
    

}
}
