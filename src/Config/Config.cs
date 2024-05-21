namespace TheKartersAssistant;

public class Config {
    protected bool isDebugModeEnabled;

    public bool IsDebugModeEnabled() {
        return this.isDebugModeEnabled;
    }

    public Config IsDebugModeEnabled(bool isDebugModeEnabled) {
        this.isDebugModeEnabled = isDebugModeEnabled;

        return this;
    }
}