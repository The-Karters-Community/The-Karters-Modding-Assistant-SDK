using System;

namespace TheKartersAssistant.Event;

public class PlayerInputEvent {
     // Ant_KartInput::ProcessRacingInput
    public static Action<Player> onBottomFaceButtonPress;
    public static Action<Player> onBottomFaceButtonHold;
    public static Action<Player> onBottomFaceButtonRelease;

    public static Action<Player> onTopFaceButtonPress;
    public static Action<Player> onTopFaceButtonHold;
    public static Action<Player> onTopFaceButtonRelease;

    public static Action<Player> onRightFaceButtonPress;
    public static Action<Player> onRightFaceButtonHold;
    public static Action<Player> onRightFaceButtonRelease;

    public static Action<Player> onLeftFaceButtonPress;
    public static Action<Player> onLeftFaceButtonHold;
    public static Action<Player> onLeftFaceButtonRelease;
}