using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Repositories
{
    public interface IMaterialRepository
    {
        Task<Material> CreateMaterial(Material material);
        Task<List<Material>> GetAllMaterials();     
        Task<Material> GetMaterialById(int materialId);
        Task<List<Material>> GetMaterialsByTitleId(int titleId);              
        Task<Material> UpdateMaterial(int materialId, Material material);
        Task<Material> DeleteMaterial(int materialId); 

    }
    public class MaterialRepository : IMaterialRepository
    {
        private readonly LibraryContext _context;

        public MaterialRepository(LibraryContext context)
        {
            _context = context;
        }



        //CREATE
        public async Task<Material> CreateMaterial(Material material)
        {
            _context.Material.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        //Read
        public async Task<List<Material>> GetAllMaterials()
        {
            return await _context.Material
                .OrderBy(b => b.LocationId)
                .ToListAsync();
        }

        public async Task<Material> GetMaterialById(int materialId)
        {
            return await _context.Material
                .FirstOrDefaultAsync(material => material.MaterialId == materialId);
        }

        public async Task<List<Material>> GetMaterialsByTitleId(int titleId)
        {
            return await _context.Material
                .Include(material => material.TitleId == titleId)
                .ToListAsync();
        }

        //Update
        public async Task<Material> UpdateMaterial(int materialId, Material material)
        {
            Material updatematerial = await _context.Material
                .FirstOrDefaultAsync(material => material.MaterialId == materialId);
            if (updatematerial != null)
            {
                updatematerial.MaterialId = material.MaterialId;
                updatematerial.LocationId = material.LocationId;
                updatematerial.Home = material.Home;
                updatematerial.TitleId = material.TitleId;
                await _context.SaveChangesAsync();
            }
            return updatematerial;
        }

        //Delete
        public async Task<Material> DeleteMaterial(int materialId)
        {
            Material deletematerial = await _context.Material.FirstOrDefaultAsync(material => material.MaterialId == materialId);
            if (deletematerial != null)
            {
                _context.Material.Remove(deletematerial);
                await _context.SaveChangesAsync();
            }
            return deletematerial;
        }
    }
}
