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
        Task<List<Material>> GetAllMaterials();
        Task<Material> CreateMaterial(MaterialRequest newMaterial);
        Task<Material> GetLMaterialById(int id);
        Task<List<Material>> GetLMaterialsByTitleId(int id);
        Task<Material> UpdateMaterial(int materialId, MaterialRequest updateMaterial);
        Task<Material> DeleteMaterial(int MaterialId);
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
                Home = material.Home
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
        public async Task<Material> CreateMaterial(MaterialRequest newMaterial)
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
        public async Task<List<Material>> GetAllMaterials()
        {
            List<Material> materials = await _materialRepository.GetAllMaterials();
            return materials.Select(material => MapMaterialToMaterialResponse(material)).ToList();
        }
        public async Task<Material> GetLMaterialById(int id)
        {
            Material material = await _materialRepository.GetMaterialById(id);
            if (material != null)
            {
                return MapMaterialToMaterialResponse(material);
            }
            return null;
        }
        public async Task<List<Material>> GetLMaterialsByTitleId(int id)
        {
            List <Material> material = await _materialRepository.GetMaterialsByTitleId(id);
            if (material != null)
            {
                return MapMaterialToMaterialResponse(material);
            }
            return null;
        }
        //Update
        public async Task<Material> UpdateMaterial(int materialId, MaterialRequest updateMaterial)
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
        public async Task<Material> DeleteMaterial(int MaterialId)
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
