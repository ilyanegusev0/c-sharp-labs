using RestaurantManagementSystem.Interfaces;

namespace RestaurantManagementSystem
{
    public class Table : IReservable, IPrintable
    {
        // Fields:
        private int _number;
        private int _seats;
        private bool _isReserved;
        private DateTime _reservationDate;

        // Properties:
        public int Number => _number;
        public int Seats => _seats;
        public bool IsReserved => _isReserved;
        public DateTime ReservationDate => _reservationDate;

        // Constructors:
        public Table(int number, int seats)
        {
            _number = number;
            _seats = seats;
            _isReserved = false;
        }

        // Methods:
        public void Reserve()
        {
            if (!_isReserved)
            {
                _isReserved = true;
                _reservationDate = DateTime.Now;
            }
        }

        public void Free()
        {
            if (_isReserved)
                _isReserved = false;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            if (_isReserved)
            {
                return
                    $"Table #{_number}:\n" +
                    $"-------------------------\n" +
                    $"Seats: {_seats}\n" +
                    $"Reservation: {_isReserved}\n" +
                    $"Date of reservation: {_reservationDate}\n" +
                    $"-------------------------";
            }
            else
            {
                return
                    $"Table #{_number}:\n" +
                    $"-------------------------\n" +
                    $"Seats: {_seats}\n" +
                    $"Reservation: {_isReserved}\n" +
                    $"-------------------------";
            }

        }
    }
}