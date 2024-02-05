using Kreta.Shared.Dtos;
using Kreta.Shared.Models;

namespace Kreta.Shared.Extensions
{
    public static class ParentExtension
    {
        public static ParentDto ToParentDto(this Parent parent)
        {
            return new ParentDto
            {
                Id = parent.Id,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                BirthsDay = parent.BirthsDay,
            };
        }

        public static Parent ToParent(this ParentDto parentdto)
        {
            return new Parent
            {
                Id = parentdto.Id,
                FirstName = parentdto.FirstName,
                LastName = parentdto.LastName,
                BirthsDay = parentdto.BirthsDay,
            };
        }
    }

}
