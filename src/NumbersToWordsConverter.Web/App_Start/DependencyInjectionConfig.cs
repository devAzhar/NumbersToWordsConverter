namespace NumbersToWordsConverter.Web
{
    using Core.Interfaces;
    using Core.Services;
    using DependencyInjection;
    using System.Web.Mvc;
    using Unity;

    public class DependencyInjectionConfig
    {
        /// <summary>
        /// Initializes the container.
        /// </summary>
        public static void InitializeContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICurrencyToWordsConverter, CurrencyToWordsConverter>();
            container.RegisterType<INumberToWordsConverter, NumberToWordsConverter>();
            container.RegisterType<ISplitNumberParts, SplitNumberParts>();

            SetControllerFactory(container);
        }

        /// <summary>
        /// Sets the controller factory.
        /// </summary>
        /// <param name="container">The container.</param>
        private static void SetControllerFactory(IUnityContainer container)
        {
            var controllerFactory = new ControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
