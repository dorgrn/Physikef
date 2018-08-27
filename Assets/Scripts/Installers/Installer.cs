using Attributes;
using Exercises;
using Questions;
using Zenject;

namespace Installers
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IExercisePublisher>().To<InternalExercisePublisher>().AsTransient();
            Container.Bind<ApplicationManager>().AsSingle().NonLazy();
        }
    }
}