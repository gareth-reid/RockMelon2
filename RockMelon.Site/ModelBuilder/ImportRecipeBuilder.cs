using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EntityFramework.Common.Repositories;
using Rockmelon.Repository.Entities;
using RockMelon.Site.Models;

namespace RockMelon.Site.ModelBuilder
{
    public class ImportRecipeBuilder : IImportRecipeBuilder
    {
        private readonly IGenericAuditableRepository<Recipe> _genericAuditableRepository;
        
        public ImportRecipeBuilder(IGenericAuditableRepository<Recipe> genericAuditableRepository)
        {
            _genericAuditableRepository = genericAuditableRepository;
        }

        public RecipeModel BuildModel(Recipe recipe)
        {
            var model = new RecipeModel();
            Mapper.CreateMap<Recipe, RecipeModel>();
            Mapper.Map(recipe, model);
            model.Id = recipe.Id;
            return model;
        }

        public RecipeModel BuildModel(int entityId)
        {
            var model = new RecipeModel();
            model.Id = entityId;
            var page = _genericAuditableRepository.Get(x => x.Id == entityId && x.IsActive);
            if (page != null)
            {
                Mapper.CreateMap<Recipe, RecipeModel>();
                Mapper.Map(page, model);
            }
            
            return model;
        }

        public Recipe BuildEntity(RecipeModel model)
        {
            var page = _genericAuditableRepository.Get(x => x.Id == model.Id);

            if (page == null)
            {
                page = new Recipe();
                Mapper.CreateMap<RecipeModel, Recipe>();
                Mapper.Map(model, page);
            }
            
            _genericAuditableRepository.Add(page);
            _genericAuditableRepository.SaveMe();
            
            return page;
        }

        public Recipe CopyAndArchive(int pageId)
        {
            var page = BuildEntity(pageId);
            //create page to archive and leave the old 
            var pageToArchive = new Recipe();
            Mapper.CreateMap<Recipe, Recipe>();
            Mapper.Map(page, pageToArchive);
           
            _genericAuditableRepository.Add(pageToArchive);
            _genericAuditableRepository.SaveMe();
            return pageToArchive;
        }

        public Recipe MoveAndArchive(int pageId)
        {
            var pageToArchive = BuildEntity(pageId);
            
            _genericAuditableRepository.Add(pageToArchive);
            _genericAuditableRepository.SaveMe();
            return pageToArchive;
        }

        public Recipe BuildEntity(int pageId)
        {
            return _genericAuditableRepository.Get(x => x.Id == pageId);
        }

        public void Delete(int pageId)
        {
            _genericAuditableRepository.Delete(pageId);
            _genericAuditableRepository.SaveMe();
        }
        
    }
}