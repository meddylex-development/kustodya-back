using Kustodya.Infrastructure;
using Kustodya.WebApi.Models.K2Seguridad;
using Kustodya.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers
{
    public class K2PerfilesController : BaseController
    {
        private readonly dbProtektoV1Context _context;
        private readonly IConfiguration _configuration;
        public K2PerfilesController(dbProtektoV1Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //Consultar Perfiles
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> ConsultarPerfiles()
        {
            try
            {
                var ListPerfiles = await _context.TblPerfiles.ToListAsync();
                return Ok(ListPerfiles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Crear Perfil
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult CrearPerfil1(CrearPerfil p)
        {
            string SProcedure = @"seguridad.SPGestionartblPerfiles";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 1);
                    myCommand.Parameters.AddWithValue("@iIDPerfil", 0);
                    myCommand.Parameters.AddWithValue("@tDescripcion", p.tDescripcion);
                    myCommand.Parameters.AddWithValue("@bActivo", 0);
                    myCommand.Parameters.AddWithValue("@Pagina", 0);
                    myCommand.Parameters.AddWithValue("@CantidadReg", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Perfil creado exitosamente");
        }

        //Editar Perfil
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EditarPerfil(EditarPerfil p)
        {
            string SProcedure = @"seguridad.SPGestionartblPerfiles";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 2);
                    myCommand.Parameters.AddWithValue("@iIDPerfil", p.iIDPerfil);
                    myCommand.Parameters.AddWithValue("@tDescripcion", p.tDescripcion);
                    myCommand.Parameters.AddWithValue("@bActivo", p.bActivo);
                    myCommand.Parameters.AddWithValue("@Pagina", 0);
                    myCommand.Parameters.AddWithValue("@CantidadReg", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Perfil editado exitosamente");
        }

        //Eliminar Perfil
        [HttpDelete]
        //[AllowAnonymous]
        public JsonResult EliminarPerfil(EliminarPerfil p)
        {
            string SProcedure = @"seguridad.SPGestionartblPerfiles";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 3);
                    myCommand.Parameters.AddWithValue("@iIDPerfil", p.iIDPerfil);
                    myCommand.Parameters.AddWithValue("@tDescripcion", 0);
                    myCommand.Parameters.AddWithValue("@bActivo", 0);
                    myCommand.Parameters.AddWithValue("@Pagina", 0);
                    myCommand.Parameters.AddWithValue("@CantidadReg", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Perfil eliminado exitosamente");
        }
    }
}
