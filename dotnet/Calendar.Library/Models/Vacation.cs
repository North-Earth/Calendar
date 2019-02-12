using System;

namespace Calendar.Library.Models
{
    public class Vacation
    {
        #region Fields

        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CountDays { get; set; }

        #endregion
    }
}
