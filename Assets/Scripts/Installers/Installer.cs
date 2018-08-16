using Attributes;
using Questions;
using Zenject;

namespace Installers
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IQuestionPublisher>().To<InternalQuestionPublisher>().AsTransient();
            Container.Bind<ApplicationManager>().AsSingle().NonLazy();
        }
    }
}