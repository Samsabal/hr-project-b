namespace Festivity
{
    public class MenuOption
    {
        public delegate void MenuAction();

        private readonly MenuAction action;

        public string Name { get; }

        public MenuOption(string menuName, MenuAction action)
        {
            Name = menuName;
            this.action = action;
        }

        public void Select()
        {
            action();
        }
    }
}