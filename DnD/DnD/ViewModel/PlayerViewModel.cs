using DnD.Model;

namespace DnD.ViewModel
{
    public class PlayerViewModel : ObservableObject
    {
        public string Id
        {
            get => (id = Player.Id);
            set
            {
                SetPropertyValue(ref id, value);
                Player.Id = value;
            }
        }

        public string Name
        {
            get => (name = Player.Name);
            set
            {
                SetPropertyValue(ref name, value);
                Player.Name = value;
            }
        }

        private string id;
        private string name;

        public Player Player { get; }

        public PlayerViewModel(Player player)
        {
            Player = player;
        }
    }
}
