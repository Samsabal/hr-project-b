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
            Menu.Option = 0;
            
            action();

            Menu.IsLooping = false;

        }
    }
}