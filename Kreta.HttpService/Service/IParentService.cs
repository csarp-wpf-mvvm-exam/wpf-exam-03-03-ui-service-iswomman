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
    public interface IParentService
    {
        public Task<List<Parent>> SelectAllParent();
        public Task<ControllerResponse> UpdateAsync(Parent parentdto);
        public Task<ControllerResponse> DeleteAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Parent parent);

    }
}
