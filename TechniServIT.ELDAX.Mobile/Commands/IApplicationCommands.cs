using Prism.Commands;

namespace TechniServIT.ELDAX.Mobile.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand ShowPopup { get; }
    }
}