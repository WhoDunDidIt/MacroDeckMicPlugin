using WDI_ToolBox.MicController;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using WhoDunIt.MacroDeckMicPlugin.Actions;

namespace WhoDunIt.MacroDeckMicPlugin;

public class Main : MacroDeckPlugin
{
    public bool MuteStatusVariable
    {
        get => bool.Parse(VariableManager.GetVariable(this, "wdi_micmuter_micstatus").Value);
        set => VariableManager.SetValue("wdi_micmuter_micstatus", value, VariableType.Bool, this, Array.Empty<string>());
    }

    public Main()
    {
        // Create our Mic Controller
        using var mic = new MicController();

        // Hook the On Volume event so we know when we're muted externally
        mic.OnVolumeNotification += (data) =>
        {
            // If the mute state hasn't changed, ignore it
            if (data.Muted == MuteStatusVariable) return;

            // Update the status variable
            MuteStatusVariable = data.Muted;
        };
    }

    public override void Enable()
    {
        // Load the actions
        Actions = new List<PluginAction> { new MuteMic(), new UnmuteMic() };

        // Set the initial variable value to the current state of the mic
        using var mic = new MicController();
        MuteStatusVariable = mic.IsMuted;
    }
}