 using Player.Signals;
 using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<PlayerSignals.PlayerChangePos>().OptionalSubscriber();
        
        SignalBusInstaller.Install(Container);
    }
}
