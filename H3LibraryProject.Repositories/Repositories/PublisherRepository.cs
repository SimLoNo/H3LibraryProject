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
    public interface IPublisherRepository
    {
        Task<Publisher> InsertNewPublisher(Publisher publisher);
        Task<List<Publisher>> SelectAllPublishers(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Publisher> SelectPublisherById(int publisherId);
        Task<Publisher> UpdateExistingPublisher(int publisherId, Publisher publisher);
        Task <Publisher> DeletePublisherById(int publisherId);
    }
    public class PublisherRepository : IPublisherRepository
    { 
        private readonly LibraryContext _context;

        public PublisherRepository(LibraryContext context)
        {
            _context = context;
        }

        //Create
        public async Task<Publisher> InsertNewPublisher(Publisher publisher)
        {
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        //Read      
        public async Task<List<Publisher>> SelectAllPublishers()
        {

            return await _context.Publisher
                .Include(b => b.Name)
                .ToListAsync();
        }       
        public async Task<Publisher> SelectPublisherById(int publisherId)
        {

            return await _context.Publisher
                    .FirstOrDefaultAsync(publisher => publisher.PublisherId == publisherId);
            
        }

        //Update
        public async Task<Publisher> UpdateExistingPublisher(int publisherId, Publisher publisher)
        {
            Publisher updatePublisher = await _context.Publisher
                .FirstOrDefaultAsync(publisher => publisher.PublisherId == publisherId);
            if (updatePublisher != null)
            {
                updatePublisher.Name = publisher.Name;
                await _context.SaveChangesAsync();
            }
            return updatePublisher;
        }
        //Delete
        public async Task<Publisher> DeletePublisherById(int publisherId)
        {
            Publisher deletePublisher = await _context.Publisher.FirstOrDefaultAsync(publisher => publisher.PublisherId == publisherId);
            if (deletePublisher != null)
            {
                _context.Publisher.Remove(deletePublisher);
                await _context.SaveChangesAsync();

            }
            return deletePublisher;
        }
        
        
    }
}
