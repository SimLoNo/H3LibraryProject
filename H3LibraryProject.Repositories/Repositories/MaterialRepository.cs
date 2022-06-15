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
        Task<List<Material>> SearchMaterial(string searchTitle, string location, string genre, string author);
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
                .Include(m => m.Title)
                .Include(m => m.Location)
                .OrderBy(m => m.LocationId)
                .ToListAsync();
        }

        public async Task<Material> GetMaterialById(int materialId)
        {
            return await _context.Material
                .Include(m => m.Title).ThenInclude(t => t.Authors)
                .Include(m => m.Title.Genre)
                .Include(m => m.Location)
                .FirstOrDefaultAsync(material => material.MaterialId == materialId);
        }

        public async Task<List<Material>> SearchMaterial(string searchTitle, string location, string genre, string author)
        {
            return await _context.Material
                .Include(m => m.Title).ThenInclude(t => t.Genre)
                .Include(m => m.Location)
                .OrderBy(m => m.LocationId)
                .Where(m => (m.Title.Name.Contains(searchTitle) || searchTitle == "") && (m.Location.Name.Contains(location) || location == "") && (m.Title.Genre.Name.Contains(genre) || genre == ""))
                .ToListAsync();
        }

        public async Task<List<Material>> GetMaterialsByTitleId(int titleId)
        {
            return await _context.Material
                .Include(m => m.Title)
                .Include(m => m.Location)
                .Where(m => m.TitleId == titleId)
                .ToListAsync();
        }

        //Update
        public async Task<Material> UpdateMaterial(int materialId, Material material)
        {
            Material updatematerial = await _context.Material
                .FirstOrDefaultAsync(material => material.MaterialId == materialId);
            if (updatematerial != null)
            {
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
