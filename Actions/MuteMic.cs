using WDI_ToolBox.MicController;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace WhoDunIt.MacroDeckMicPlugin.Actions;

public class MuteMic : PluginAction
{
    public override string Name => "Mute all mics";
    public override string Description => "Mutes all mics.";
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        using var mic = new MicController();
        mic.MuteMic();
    }
}