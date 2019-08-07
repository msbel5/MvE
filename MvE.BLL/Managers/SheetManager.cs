using MvE.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MvE.BLL.Managers
{
    public class SheetManager
    {
        public bool Add(CharacterSheetDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<CharacterSheetDTO> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CharacterSheetDTO> Find(Expression<Func<CharacterSheetDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CharacterSheetDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CharacterSheetDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<CharacterSheetDTO> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(int entityId, CharacterSheetDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
