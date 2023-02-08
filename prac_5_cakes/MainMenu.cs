namespace prac_5_cakes
{
    internal class MainMenu
    {
        public string Name;
        public List<MiniMenu> MiniMenu;

        public MainMenu(string name, List<MiniMenu> list)
        {
            Name = name;
            MiniMenu = list;
        }
    }
}
