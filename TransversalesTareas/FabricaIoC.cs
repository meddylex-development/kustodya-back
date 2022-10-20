using NucleoTareas;
using DatosTareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TransversalesTareas
{
    public class FabricaIoC
    {
        private static readonly FabricaIoC _contenedor = new FabricaIoC();
        private readonly IUnityContainer _unityContainer;

        private FabricaIoC()
        {
            _unityContainer = new UnityContainer();

            // Registrar los tipos utilizados en la aplicacion.
            // Especificamente con una nueva tecnologia de acceso a datos.

            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        public static FabricaIoC Contenedor
        {
            get { return _contenedor; }
        }

        /// <summary>
        ///   Crear una instancia de un objeto que implemente un tipo TServicio.
        /// </summary>
        /// <typeparam name = "TServicio">Tipo de servicio que deseamos resolver</typeparam>
        /// <returns></returns>
        public TServicio Resolver<TServicio>() where TServicio : class
        {
            return _unityContainer.Resolve<TServicio>();
        }
    }
}
