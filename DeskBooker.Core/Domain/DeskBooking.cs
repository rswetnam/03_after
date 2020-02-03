using DeskBooker.Core.DataInterface;
using System;
using System.Linq;

namespace DeskBooker.Core.Domain
{
    public class DeskBooking : DeskBookingBase
    {
        private readonly IDeskBookingRepository _deskBookingRepository;
        private readonly IDeskRepository _deskRepository;

        public DeskBooking()
        {
        }

        public DeskBooking(IDeskBookingRepository deskBookingRepository,
            IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository;
            _deskRepository = deskRepository;
        }


        public int Id { get; set; }
        public int DeskId { get; set; }

        public void CreateBooking()
        {

        }

        public DeskBooking CreateBooking(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var availableDesks = _deskRepository.GetAvailableDesks(request.Date);

            var deskBooking = Create<DeskBooking>(request);

            deskBooking.DeskId = availableDesks.First().Id;

            _deskBookingRepository.Save(deskBooking);

            return deskBooking;
        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }



    }
}