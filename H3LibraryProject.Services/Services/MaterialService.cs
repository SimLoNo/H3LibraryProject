﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;

namespace H3LibraryProject.Services.Services
{
    public interface IMaterialService
    {
        Task<List<MaterialResponse>> GetAllMaterials();
        Task<MaterialResponse> CreateMaterial(MaterialRequest newMaterial);
        Task<MaterialResponse> GetMaterialById(int id);
        Task<List<MaterialResponse>> GetMaterialsByTitleId(int id);
        Task<List<MaterialResponse>> SearchMaterial(string searchTitle, string location, string genre, string author);
        Task<MaterialResponse> UpdateMaterial(int materialId, MaterialRequest updateMaterial);
        Task<MaterialResponse> DeleteMaterial(int MaterialId);
    }
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository repository)
        {
            _materialRepository = repository;
        }
        //Mappings
        public MaterialResponse MapMaterialToMaterialResponse(Material material)
        {
            return new MaterialResponse
            {
                MaterialId = material.MaterialId,
                TitleId = material.TitleId,
                LocationId = material.LocationId,
                Home = material.Home,
                Title = material.Title != null ? new MaterialTitleResponse { // gemmer titlen på materialet, hvis der af en årsag ikke er en title på materialet bliver der genrereret en generisk ny title
                    TitleId = material.Title.TitleId,
                    Name = material.Title.Name,
                    RYear = material.Title.RYear,
                    Pages = material.Title.Pages,
                    Authors = material.Title.Authors != null ? material.Title.Authors.Select(authorObj => new MaterialTitleAuthorResponse // Hver title kan have en, flere eller ingen forattere
                    {
                        AuthorId = authorObj.AuthorId,
                        FName = authorObj.FName,
                        LName = authorObj.LName,
                        MName = authorObj.MName
                    }).ToList() : new()
                } : new(),
                Location = material.Location != null ? new MaterialLocationResponse // Hver materiale skal tilhøre et sted.
                {
                    LocationId = material.Location.LocationId,
                    Name = material.Location.Name
                } : new()
            };
        }

        private Material MapMaterialRequestToMaterial(MaterialRequest materialRequest)
        {
            return new Material
            {
                TitleId = materialRequest.TitleId,
                LocationId = materialRequest.LocationId,
                Home = materialRequest.Home
            };
        }
       
        //Create
        public async Task<MaterialResponse> CreateMaterial(MaterialRequest newMaterial)
        {
            Material material = MapMaterialRequestToMaterial(newMaterial);
            Material insertedMaterial = await _materialRepository.CreateMaterial(material);
            if (insertedMaterial != null)
            {
                return MapMaterialToMaterialResponse(insertedMaterial);
            }
            return null;
        }        
        //Read
        public async Task<List<MaterialResponse>> GetAllMaterials()
        {
            List<Material> materials = await _materialRepository.GetAllMaterials();
            return materials.Select(materials => MapMaterialToMaterialResponse(materials)).ToList();
        }

        public async Task<List<MaterialResponse>> SearchMaterial(string searchTitle, string location, string genre, string author)
        {
            if (searchTitle == null)
            {
                searchTitle = "";
            }
            if (location == null)
            {
                location = "";
            }
            if (genre == null)
            {
                genre = "";
            }
            if (author == null)
            {
                author = "";
            }
            List<Material> materials = await _materialRepository.SearchMaterial(searchTitle, location, genre, author);
            return materials.Select(materials => MapMaterialToMaterialResponse(materials)).ToList();
        }
        public async Task<MaterialResponse> GetMaterialById(int id)
        {
            Material material = await _materialRepository.GetMaterialById(id);
            if (material != null)
            {
                return MapMaterialToMaterialResponse(material);
            }
            return null;
        }
        public async Task<List<MaterialResponse>> GetMaterialsByTitleId(int id)
        {
            List <Material> materials = await _materialRepository.GetMaterialsByTitleId(id);
            if (materials != null)            {             

                return materials.Select(materials => MapMaterialToMaterialResponse(materials)).ToList();
            }
            return null;
        }
        //Update
        public async Task<MaterialResponse> UpdateMaterial(int materialId, MaterialRequest updateMaterial)
        {
            Material Material = MapMaterialRequestToMaterial(updateMaterial);

            Material updatedMaterial = await _materialRepository.UpdateMaterial(materialId, Material);

            if (updatedMaterial != null)
            {
                return MapMaterialToMaterialResponse(updatedMaterial);
            }
            return null;
        }
        //Delete
        public async Task<MaterialResponse> DeleteMaterial(int MaterialId)
        {
            Material deletedMaterial = await _materialRepository.DeleteMaterial(MaterialId);
            if (deletedMaterial != null)
            {
                return MapMaterialToMaterialResponse(deletedMaterial);
            }
            return null;
        }
    }
}
