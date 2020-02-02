using DeskBooker.Core.DataInterface;
using System;

namespace DeskBooker.Core.Domain
{
    public class DeskBooking : DeskBookingBase
    {
        private readonly IDeskBookingRepository _deskBookingRepository;

        public DeskBooking()
        {
        }

        public DeskBooking(IDeskBookingRepository deskBookingRepository)
        {
            _deskBookingRepository = deskBookingRepository;
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

            var deskBooking = Create<DeskBooking>(request);

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