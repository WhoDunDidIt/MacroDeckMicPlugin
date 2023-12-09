using WDI_ToolBox.MicController;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace WhoDunIt.MacroDeckMicPlugin.Actions;

public class UnmuteMic : PluginAction
{
    public override string Name => "Unmute all mics";
    public override string Description => "Unmutes all mics.";
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        using var mic = new MicController();
        mic.UnmuteMic();
    }
}