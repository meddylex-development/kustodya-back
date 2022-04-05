using NucleoTareas;
using EntidadesTareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace DatosTareas
{
    public class UnitOfWork : IUnitOfWork
    {
        private kustodyaEntities context = new kustodyaEntities();
        private IRepository<CorreoAdjuntos> _CorreoAdjuntosRepository;
        private IRepository<Correos> _CorreosRepository;
        public IRepository<Correos> CorreosRepository
        {
            get
            {
                if (_CorreosRepository == null)
                {
                    _CorreosRepository = new Repository<Correos, kustodyaEntities>(context);
                }
                return _CorreosRepository;
            }
        }
        public IRepository<CorreoAdjuntos> CorreoAdjuntosRepository
        {
            get
            {
                if (_CorreoAdjuntosRepository == null)
                {
                    _CorreoAdjuntosRepository = new Repository<CorreoAdjuntos, kustodyaEntities>(context);
                }
                return _CorreoAdjuntosRepository;
            }
        }
        public string SaveChanges()
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        string rutaDoc = AppDomain.CurrentDomain.BaseDirectory + "bin/log/LogErrores" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString() + ".txt";
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutaDoc, true))
                        {
                            file.WriteLine("----------------------------");
                            file.WriteLine("MENSAJE: " + "Comunique al administrador del sistema la siguiente informacion: Tabla: " + eve.Entry.Entity.ToString() + ", Columna: " + ve.PropertyName + ", Error: " + ve.ErrorMessage);
                            file.WriteLine("FECHA Y HORA: " + DateTime.Now.ToString());
                            file.WriteLine("----------------------------");
                            file.Close();
                        }
                        return "Ha ocurrido un error en el sistema, contacte al administrador!!!";
                    }
                }
            }
            catch (Exception exc)
            {

                string mensaje = "";
                if (exc.InnerException != null)
                {
                    if (exc.InnerException.InnerException != null)
                    {
                        mensaje = exc.InnerException.InnerException.Message;
                    }
                    else if (exc.InnerException != null)
                    {
                        mensaje = exc.InnerException.Message;
                    }
                }
                if (exc.InnerException == null)
                {
                    mensaje = exc.Message;
                }
                string rutaDoc = AppDomain.CurrentDomain.BaseDirectory + "bin/log/LogErrores" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString() + ".txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutaDoc, true))
                {
                    file.WriteLine("----------------------------");
                    file.WriteLine("MENSAJE: " + "Comunique al administrador del sistema la siguiente informacion: Tabla: " + mensaje);
                    file.WriteLine("FECHA Y HORA: " + DateTime.Now.ToString());
                    file.WriteLine("----------------------------");
                    file.Close();
                }
                return "Ha ocurrido un error en el sistema, contacte al administrador!!!";
            }
            return null;
        }
    }
}
