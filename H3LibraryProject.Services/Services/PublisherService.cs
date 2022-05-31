using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface IPublisherService
    {
        Task<List<PublisherResponse>> GetAllPublishers();
        Task<PublisherResponse> GetPublisherById(int id);
        Task<PublisherResponse> CreatePublisher(PublisherRequest request);
        Task<PublisherResponse> UpdatePublisher(int id, PublisherRequest request);
        Task<PublisherResponse> DeletePublisher(int id);
    }
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _repository;

        public PublisherService(IPublisherRepository repository)
        {
            _repository = repository;
        }
        public async Task<PublisherResponse> CreatePublisher(PublisherRequest request)
        {
            Publisher newPublisher = MapPublisherRequestToPublisher(request);
            newPublisher = await _repository.InsertNewPublisher(newPublisher);

            if (newPublisher != null)
            {
                return MapPublisherToPublisherResponse(newPublisher);

            }
            return null;
        }

        public async Task<PublisherResponse> DeletePublisher(int id)
        {
            Publisher deletedPublisher = await _repository.DeletePublisherById(id);
            if (deletedPublisher != null)
            {
                return MapPublisherToPublisherResponse(deletedPublisher);
            }
            return null;
        }

        public async Task<List<PublisherResponse>> GetAllPublishers()
        {
            List<Publisher> publishers = await _repository.SelectAllPublishers();
            return publishers.Select(publisher => MapPublisherToPublisherResponse(publisher)).ToList();
        }

        public async Task<PublisherResponse> GetPublisherById(int id)
        {
            Publisher publisher = await _repository.SelectPublisherById(id);
            if (publisher != null)
            {
                return MapPublisherToPublisherResponse(publisher);
            }
            return null;
        }

        public async Task<PublisherResponse> UpdatePublisher(int id, PublisherRequest request)
        {
            Publisher updatePublisher = MapPublisherRequestToPublisher(request);
            updatePublisher = await _repository.UpdateExistingPublisher(id, updatePublisher);

            if (updatePublisher != null)
            {
                return MapPublisherToPublisherResponse(updatePublisher);
            }
            return null;
        }

        private Publisher MapPublisherRequestToPublisher(PublisherRequest request)
        {
            return new()
            {
                Name = request.Name
            };
        }

        private PublisherResponse MapPublisherToPublisherResponse(Publisher publisher)
        {

            return new()
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name
            };

        }
    }
}
