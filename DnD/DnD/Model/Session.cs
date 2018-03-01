using System;

namespace DnD.Model
{
    public class Session
    {
        public string Id { get; set; }
        public DateTime Original { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Player[] Users;
        public Player GM;
    }
}