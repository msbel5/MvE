using AutoMapper;
using MvE.BLL.Configurations;
using MvE.BLL.DTOs;
using MvE.BLL.Interfaces;
using MvE.DAL.Models;
using MvE.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MvE.BLL.Managers
{
    public class SheetManager:IManager<CharacterSheetDTO>
    {
        private SheetRepository _repository;
        private IMapper mapper;

        public SheetManager()
        {
            _repository = new SheetRepository();
            var MapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>();  });
            mapper = MapperConfig.CreateMapper();
        }

        public bool Add(CharacterSheetDTO entity)
        {
            var mappedSheet = mapper.Map<CharacterSheetDTO, CharacterSheet>(entity);
            return _repository.Add(mappedSheet);
        }

        public bool AddRange(IEnumerable<CharacterSheetDTO> entities)
        {

            var mappedSheets = mapper.Map<IEnumerable<CharacterSheetDTO>, IEnumerable<CharacterSheet>>(entities);
            return _repository.AddRange(mappedSheets);
        }

        public IEnumerable<CharacterSheetDTO> Find(Expression<Func<CharacterSheetDTO, bool>> predicate)
        {
            var mappedPredicate = mapper.Map<Expression<Func<CharacterSheetDTO, bool>>, Expression<Func<CharacterSheet, bool>>>(predicate);
            var sheetInDb = _repository.Find(mappedPredicate);
            return mapper.Map<IEnumerable<CharacterSheet>, IEnumerable<CharacterSheetDTO>>(sheetInDb);
        }

        public CharacterSheetDTO Get(int id)
        {
            var sheetInDb = _repository.Get(id);
            return mapper.Map<CharacterSheet, CharacterSheetDTO>(sheetInDb);
        }

        public IEnumerable<CharacterSheetDTO> GetAll()
        {
            var sheetInDb = _repository.GetAll();
            return mapper.Map<IEnumerable<CharacterSheet>, IEnumerable<CharacterSheetDTO>>(sheetInDb);
        }

        public bool Remove(int Id)
        {
            return _repository.Remove(Id);
        }

        public bool RemoveRange(IEnumerable<CharacterSheetDTO> entities)
        {
            var mappedSheet = mapper.Map<IEnumerable<CharacterSheetDTO>, IEnumerable<CharacterSheet>>(entities);
            return _repository.RemoveRange(mappedSheet);
        }

        public bool Update(int entityId, CharacterSheetDTO entity)
        {
            var mappedSheet = mapper.Map<CharacterSheetDTO, CharacterSheet>(entity);
            mappedSheet.Id = entityId;
            return _repository.Update(entityId, mappedSheet);
        }
        
        public CharacterSheet DTOtoModel(CharacterSheetDTO sheetDTO)
        {
            return mapper.Map<CharacterSheetDTO, CharacterSheet>(sheetDTO);
        }

        public CharacterSheetDTO ModeltoDto(CharacterSheet sheet)
        {
            return mapper.Map<CharacterSheet, CharacterSheetDTO>(sheet);
        }
    }
}
