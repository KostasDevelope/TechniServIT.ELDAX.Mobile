using Prism.Commands;

namespace TechniServIT.ELDAX.Mobile.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _showPopup = new CompositeCommand();

        public CompositeCommand ShowPopup
        {
            get { return _showPopup; }
        }
    }
}