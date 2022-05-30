using System;
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
        Task<List<LoanerType>> GetAllMaterials();
        Task<LoanerType> CreateMaterial(Material newMaterial);
        Task<LoanerType> GetLMaterialById(int id);
        Task<LoanerType> UpdateMaterial(int materialId, MaterialRequest updateMaterial);
        Task<LoanerType> DeleteMaterial(int MaterialId);
    }
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository repository)
        {
            _materialRepository = repository;
        }
        //Mappings
        public Material MapMaterialRequestToMaterial(MaterialRequest materialRequest)
        {
            return new Material
            {
                TitleId = materialRequest.TitleId,
                LocationId = materialRequest.LocationId,
                Home = materialRequest.Home
            };
        }
        public MaterialResponse MapMaterialToMaterialResponse(Material material)
        {
            return new MaterialResponse
            {
                TitleId = material.TitleId,
                LocationId = material.LocationId,
                Home = material.Home
            };
        }
        //Create
        public async Task<LoanerType> CreateMaterial(Material newMaterial)
        {
            Material material = MapMaterialRequestToMaterial(newMaterial);

            Material insertedMaterial = await _materialRepository.CreateMaterial(material);
            if (insertedMaterial != null)
            {
                return MapMaterialRequestToMaterial(insertedMaterial);
            }
            return null;
        }        
        //Read
        public async Task<List<LoanerType>> GetAllMaterials()
        {
            List<Material> materials = await _materialRepository.GetAllMaterials();
            return materials.Select(material => MapMaterialToMaterialResponse(material)).ToList();
        }
        public async Task<LoanerType> GetLMaterialById(int id)
        {
            Material material = await _materialRepository.GetLMaterialById(id);
            if (material != null)
            {
                return MapMaterialToMaterialResponse(material);
            }
            return null;
        }
        //Update
        public async Task<LoanerType> UpdateMaterial(int materialId, MaterialRequest updateMaterial)
        {
            Material Material = MapMaterialRequestToMaterial(updateMaterial);

            Material updatedMaterial = await _MaterialRepository.UpdateMaterial(materialId, Material);

            if (updatedMaterial != null)
            {
                return MapMaterialToMaterialResponse(updatedMaterial);
            }
            return null;
        }
        //Delete
        public async Task<LoanerType> DeleteMaterial(int MaterialId)
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
