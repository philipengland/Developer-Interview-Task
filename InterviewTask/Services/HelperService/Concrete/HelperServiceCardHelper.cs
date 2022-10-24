using AutoMapper;
using InterviewTask.HelperService.Models;
using InterviewTask.Logging;
using InterviewTask.Models;
using InterviewTask.Providers;
using System;
using System.Collections.Generic;

namespace InterviewTask.Services
{
    public class HelperServiceCardHelper : IHelperServiceCardHelper
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public HelperServiceCardHelper(IDateTimeProvider dateTimeProvider, ILogger logger, IMapper mapper)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.logger = logger;
            this.mapper = mapper;
        }

        public virtual HelperServiceCardModel MapHelperServiceCard(HelperServiceModel model)
        {
            if (model == null) { 
                logger.LogError("MapHelperServiceCard: Empty HelperServiceModel passed to method"); 
                throw new ArgumentNullException("HelperServiceModel is null"); 
            }

            var helperServiceCard = mapper.Map<HelperServiceCardModel>(model);

            // If the times are unavailable then we won't set the Opening hours
            if (AreTimesUnavailable(model) == true) 
            { 
                logger.LogWarning($"{model.Id}: {model.Title}: HelperService times unavailable"); 
                return helperServiceCard; 
            }

            helperServiceCard.ServiceOpening = SetServiceOpening(model);

            return helperServiceCard;
        }

        private ServiceOpening SetServiceOpening(HelperServiceModel model)
        {
            var currentOpeningTimes = GetOpeningTimesForDay(model, dateTimeProvider.GetNow().DayOfWeek);

            if (IsServiceWithinOpeningHours(currentOpeningTimes))
            {
                return SetServiceOpenProperties(currentOpeningTimes);
            }

            return SetServiceClosedProperties(model);
        }

        private ServiceOpening SetServiceClosedProperties(HelperServiceModel model)
        {
            var serviceOpening = new ServiceOpening();
            serviceOpening.ServiceOpen = false;

            // starting with the following day, we are checking for the next day where there are opening times
            // - then setting the start time and day properties
            var current = dateTimeProvider.GetNow().AddDays(1);
            var nextWeek = dateTimeProvider.GetNow().AddDays(8);
            while (current < nextWeek)
            {
                var openingTimes = GetOpeningTimesForDay(model, current.DayOfWeek);
                if (IsServiceOpenThatDay(openingTimes))
                {
                    serviceOpening.OpeningDay = current.DayOfWeek.ToString();
                    serviceOpening.OpeningTime = $"{openingTimes[0]}:00";

                    return serviceOpening;
                }

                current = current.AddDays(1);
            }

            return serviceOpening;
        }

        private static ServiceOpening SetServiceOpenProperties(List<int> currentOpeningTimes)
        {
            return new ServiceOpening()
            {
                ServiceOpen = true,
                ClosingTime = $"{currentOpeningTimes[1]}:00"
            };
        }

        private bool AreTimesUnavailable(HelperServiceModel model)
        {
            // Checking is any of the opening times have not been returned - 
            // If any are null we will determine that the times are unavailable
            return ((model.MondayOpeningHours == null)
                || (model.TuesdayOpeningHours == null)
                || (model.WednesdayOpeningHours == null)
                || (model.ThursdayOpeningHours == null)
                || (model.FridayOpeningHours == null)
                || (model.SaturdayOpeningHours == null)
                || (model.SundayOpeningHours == null));        
        }

        private List<int> GetOpeningTimesForDay(HelperServiceModel model, DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return model.SundayOpeningHours;
                case DayOfWeek.Monday:
                    return model.MondayOpeningHours;
                case DayOfWeek.Tuesday:
                    return model.TuesdayOpeningHours;
                case DayOfWeek.Wednesday:
                    return model.WednesdayOpeningHours;
                case DayOfWeek.Thursday:
                    return model.ThursdayOpeningHours;
                case DayOfWeek.Friday:
                    return model.FridayOpeningHours;
                case DayOfWeek.Saturday:
                    return model.SaturdayOpeningHours;
                default:
                    return null;
            }
        }
 
        private bool IsServiceWithinOpeningHours(IList<int> openingTimes)
        {
            if (IsServiceOpenThatDay(openingTimes) == false) { return false; }

            int openingHours = openingTimes[0];
            int closingHours = openingTimes[1];

            if (dateTimeProvider.GetNow().Hour >= openingHours && dateTimeProvider.GetNow().Hour < closingHours) { return true; }

            return false;
        }

        private bool IsServiceOpenThatDay(IList<int> openingTimes)
        {
            int openingHours = openingTimes[0];
            int closingHours = openingTimes[1];

            return (openingHours > 0 && closingHours > 0);
        }
    }
}