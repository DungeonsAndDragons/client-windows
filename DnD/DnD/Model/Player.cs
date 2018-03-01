namespace DnD.Model
{
    public class Player
    {
        public bool IsGM { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public CharacterCollection Characters { get; } = new CharacterCollection();
    }
}