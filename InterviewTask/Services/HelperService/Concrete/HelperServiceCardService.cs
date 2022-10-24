using InterviewTask.HelperService.Models;
using InterviewTask.HelperService.Repository;
using InterviewTask.Logging;
using InterviewTask.Models;
using InterviewTask.Services.Weather;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask.Services
{
    public class HelperServiceCardService : IHelperServiceCardService
    {
        private readonly IHelperServiceRepository helperServiceRepository;
        private readonly IHelperServiceCardHelper helperServiceCardHandler;
        private readonly IWeatherService helperServiceWeatherService;
        private readonly ILogger logger;

        public HelperServiceCardService(IHelperServiceRepository helperServiceRepository, IHelperServiceCardHelper helperServiceCardHandler, 
            IWeatherService helperServiceWeatherService, ILogger logger)
        {
            this.helperServiceRepository = helperServiceRepository;
            this.helperServiceCardHandler = helperServiceCardHandler;
            this.helperServiceWeatherService = helperServiceWeatherService;
            this.logger = logger;
        }

        /// <summary>
        /// Returns all Helper Service Cards for the Helper Service
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelperServiceCardModel> Get()
        {
            var cardModels = new List<HelperServiceCardModel>();

            var helperServiceModels = GetHelperServices();
            if (helperServiceModels == null) 
            {
                logger.LogWarning("HelperServiceCardService, Get: No card models returned by Repository");
                return cardModels; 
            }

            foreach (var helperService in helperServiceModels)
            {
                var card = helperServiceCardHandler.MapHelperServiceCard(helperService);
                cardModels.Add(card);
            }

            return cardModels;
        }

        /// <summary>
        /// Returns all Helper Service Cards for the Helper Service
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HelperServiceCardModel>> GetWithWeatherAsync()
        {
            var cardModels = new List<HelperServiceCardModel>();

            var helperServiceModels = GetHelperServices();
            if (helperServiceModels == null)
            {
                logger.LogWarning("HelperServiceCardService, GetWithWeatherAsync: No card models returned by Repository");
                return cardModels;
            }

            foreach (var helperService in helperServiceModels)
            {
                if (string.IsNullOrEmpty(helperService?.Title)) { 
                    logger.LogWarning("HelperServiceCardService, GetWithWeatherAsync: Card null or missing title"); 
                    continue; 
                }

                var weatherTask = helperServiceWeatherService.GetCurrentWeatherAsync(helperService.Title.Replace(" Helper Service", ""));
                var card = helperServiceCardHandler.MapHelperServiceCard(helperService);

                card.WeatherForcast = await weatherTask;

                cardModels.Add(card);
            }

            return cardModels;
        }

        private IEnumerable<HelperServiceModel> GetHelperServices()
        {
            try
            {
                return helperServiceRepository.Get();
            }
            catch (Exception exception)
            {
                logger.LogError($"HelperServiceCardService, No card models returned. Exception raised: {exception.Message}");
            }

            return null;
        }
    }
}