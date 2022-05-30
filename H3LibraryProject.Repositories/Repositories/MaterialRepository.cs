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
        Task<List<Material>> GetAllMaterials(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret        
        Task<Material> GetMaterialById(int materialId);
        Task<Material> GetMaterialByTitleId(int titleId);              
        Task<Material> UpdateMaterial(int materialId, Material material);
        Task<Material> DeleteMaterial(int materialId); //jeg har på et tidspunkt kaldt den DeleteTitleById: måske vigtigt

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


        public async Task<List<Material>> GetAllMaterials()
        {
            return await _context.Material
                .Include(b => b.MaterialId)
                .OrderBy(b => b.LocationId)
                .ToListAsync();
        }

        public async Task<Material> GetMaterialById(int materialId)
        {
            return await _context.Material
                .FirstOrDefaultAsync(material => material.MaterialId == materialId);
        }

        public async Task<Material> GetMaterialByTitleId(int titleId)
        {
            return await _context.Material
                .FirstOrDefaultAsync(material => material.TitleId == titleId);
        }

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
