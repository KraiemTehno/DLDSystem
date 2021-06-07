using DLD.BussinesLayer.Services;
using DLD.DataAccess;
using DLD.DataAccess.Interfaces;
using DLD.DataAccess.Repositories;
using DLDBussinesLayer.Interfaces;
using DLDBussinesLayer.Services;
using System;
using System.Web.Hosting;
using Unity;

namespace DLDApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            DataContext context = new DataContext();
            container.RegisterType<IDBConnetcion, DBConnetcion>();
            container.RegisterType<ICredentialRepository, CredentialRepository>();
            container.RegisterType<IWordRepository, WordRepository>();
            container.RegisterType<IShiftPointRepository, ShiftPointRepository>();
            container.RegisterType<IPageRepository, PageRepository>();
            container.RegisterType<IImagePageRepository, ImagePageRepository>();
            container.RegisterType<IDocumentRepository, DocumentRepository>();
            container.RegisterType<IInvestigationRepository, InvestigationRepository>();
            container.RegisterType<IReportItemRepository, ReportItemRepository>();
            container.RegisterType<IPdfService, PdfService>();
            container.RegisterType<IOcrService, OcrService>();
            container.RegisterType<IRenderService, RenderService>();
            container.RegisterType<IAnalizeService, AnalizeService>();
            container.RegisterType<IDocumentService, DocumentService>();
        }
    }
}