using System;

public static partial class EventManager
{

    public static event Action OnStartShoot;
    public static void Fire_OnStartShoot() { OnStartShoot?.Invoke(); }

    public static event Action OnStopShoot;
    public static void Fire_OnStopShoot() { OnStopShoot?.Invoke(); }


}
