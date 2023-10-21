namespace EAD_Ticket_Reservation_system.Models
{
    public interface IDatabaseConnection
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
