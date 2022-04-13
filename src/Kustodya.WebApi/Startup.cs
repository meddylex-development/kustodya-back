using AutoMapper;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.AI;
using Kustodya.ApplicationCore.Interfaces.Configuracion.CodigoQR;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Logging;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Services.AI;
using Kustodya.BusinessLogic.Services.AI;
using Kustodya.BusinessLogic.Services.Configuracion.CodigoQR;
using Kustodya.BusinessLogic.Services.Configuracion.Email;
using Kustodya.BusinessLogic.Services.Configuracion.Notificaciones;
using Kustodya.BusinessLogic.Services.Configuracion.Parametros;
using Kustodya.BusinessLogic.Services.General;
using Kustodya.BusinessLogic.Services.Incapacidades;
using Kustodya.BusinessLogic.Services.Negocio;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.BussinessLogic.Services;
using Kustodya.Infrastructure;
using Kustodya.Infrastructure.Data;
using Kustodya.Infrastructure.Services;
using Kustodya.Infrastructure.Services.Incapacidades;
using Kustodya.Infrastructure.Services.Negocio;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services;
using Kustodya.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prozess.Infrastructure.Identity;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using WebApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Linq;
using Kustodya.WebApi.Services.Contabilidades;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Configuration;
using Kustodya.WebApi.Controllers.Contabilidades;
using Kustodya.Infrastructure.Data.Contabilidades;
using Kustodya.ApplicationCore.Services.DepuracionesContables;
using Kustodya.WebApi.Models.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Interfaces.Administrativo;
using Kustodya.Infrastructure.Services.Auditoria;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.ApplicationCore.Services.ConceptoRehabilitacion;
using Kustodya.ApplicationCore.Interfaces.CalificacionOrigen;
using Kustodya.ApplicationCore.Services.CalificacionOrigen;
using Kustodya.WebApi.Services.Rethus;
using Newtonsoft.Json.Serialization;

namespace WebApi
{
    public class Startup
    {
        #region Dependency Injection

        private ILogger _logger;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _logger = loggerFactory.CreateLogger("startup");
        }

        private IConfiguration Configuration { get; }

        #endregion Dependency Injection


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            });
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOsMappingProfiles());
                mc.AddProfile(new MappingProfiles());
                mc.AddProfile(new ContabilidadMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new DinkToPdf.SynchronizedConverter(new DinkToPdf.PdfTools()));

            // MVC Routing
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Db Contexts
            services.AddCosmosDbContext(o => Configuration.GetSection("CosmosDb").Bind(o));
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    //options.UseSqlServer(Configuration.GetConnectionString("IdentityContextConnection"), b => b.MigrationsAssembly("WebApi"))
            //    options.UseIn("AppIdentity")
            //        );
            services.AddDbContext<dbProtektoV1Context>(c =>
            {
                 c.UseSqlServer(Configuration.GetConnectionString("KustodyaDb"));
                 c.EnableSensitiveDataLogging();
            });
            services.AddDbContext<ContabilidadContext>(c =>
            {
                string connectionString = Configuration.GetConnectionString("KustodyaDb");
                c.UseSqlServer(connectionString);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Key"]))
                    };
                });
            services.AddLogging();
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<EnumSchemaFilter>();
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using a Bearer Token",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");
                // c.TagActionsBy(api => { return new List<string> { api.HttpMethod, api.ActionDescriptor.DisplayName }; });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Kustodya API",
                    Description = "The Kustodya ASP.NET Core Web API Documentation",
                    Contact = new OpenApiContact
                    {
                        Name = "David Chaparro",
                        Email = string.Empty,
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Kustodya.ApplicationCore.xml"));
            });

            // Add SAML SSO services.
            services.AddSaml(Configuration.GetSection("SAML"));

            // Scoped Services
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GeneralRepository<>));
            services.AddScoped(typeof(IAsyncContabilidadRepository<>), typeof(ContabilidadRepository<>));
            services.AddTransient(typeof(IAsyncRepository<Medico>), typeof(MedicosRepository));
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddSingleton<SmtpClient>();
            services.AddScoped<ITranscripcionesService, TranscripcionesService>();
            services.AddScoped<IServicioRecuperacion, ServicioRecuperacion>();
            services.AddScoped<IValidateUser, ValidateUser>();
            services.AddScoped<IUsuarioService, Kustodya.Infrastructure.Services.UsuarioService>();
            // services.AddScoped<IDepuracionContableService, DepuracionContableService>();
            services.AddScoped<IUsuariosService, Kustodya.ApplicationCore.Services.UsuarioService>();
            services.AddScoped<IConverttoPdfService, ConverttoPdfService>();
            services.AddScoped<IExcelService, ExcelService>();
            services.AddScoped<IPUCService, PUCDomainService>(); 
            services.AddScoped<IPUCOutputModelService, PUCOutputModelService>();
            services.AddScoped<IPUCInputModelService, PUCInputModelService>();
            services.AddScoped<ITerceroOutputModelService, TerceroOutputModelService>();
            services.AddScoped<ITerceroInputModelService, TerceroInputModelService>();
            services.AddScoped<ITerceroService, TerceroDomainService>();
            services.AddScoped<ICentroOutputModelService, CentroOutputModelService>();
            services.AddScoped<ICentroInputModelService, CentroInputModelService>();
            services.AddScoped<ICentroService, CentroDomainService>();
            services.AddScoped<IPlantillaOutputModelService, PlantillaOutputModelService>();
            services.AddScoped<IPlantillaService, PlantillaDomainService>();
            services.AddScoped<IPlantillaInputModelService, PlantillaInputModelService>();
            services.AddScoped<IDepuracionOutputModelService, DepuracionOutputModelService>();
            services.AddScoped<IDepuracionContableDomainService, DepuracionContableDomainService>();
            services.AddScoped<IMovimientoOutputModelService, MovimientoOutputModelService>();
            services.AddScoped<IEntidadService, EntidadService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IDANEService, DaneService>();
            services.AddScoped<INotificacionService, NotificacionService>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddScoped<ICie10Service, Cie10Service>();
            services.AddScoped<IMultivaloresService, MultivaloresServices>();
            services.AddScoped<IIPSService, IPSService>();
            services.AddScoped<IEPSService, EPSService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IParametrosService, ParametrosService>();
            services.AddScoped<IEmpleadosService, EmpleadosService>();
            services.AddScoped<ICargosService, CargosService>();
            services.AddScoped<ICIUOService, CIUOService>();
            services.AddScoped<ICIIUService, CIIUService>();
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<ITextAnalytics, TextAnalyticsService>();
            services.AddScoped<IOCREngineService, OCREngineService>();
            services.AddScoped<IComputerVision, ComputerVisionService>();
            services.AddScoped<ICodigoQRService, CodigoQRService>();
            services.AddScoped<IDiagnosticoViewModelService, DiagnosticoViewModelService>();
            services.AddScoped<IEtimologiaViewModelService, EtimologiaViewModelService>();
            services.AddScoped<ITipoSecuelaViewModelService, TipoSecuelaViewModelService>();
            services.AddScoped<IPronosticoViewModelService, PronosticoViewModelService>();
            services.AddScoped<IFinalidadTratamientoViewModelService, FinalidadTratamientoViewModelService>();
            services.AddScoped<ICalificacionCortoPlazoViewModelService, CalificacionCortoPlazoViewModelService>();
            services.AddScoped<ICalificacionLargoPlazoViewModelService, CalificacionLargoPlazoViewModelService>();
            services.AddScoped<IConceptoPronosticoPacienteViewModelService, ConceptoPronosticoPacienteViewModelService>();
            services.AddScoped<IPerfilesOutputModelService, PerfilesOutputModelService>();
            services.AddScoped<IEnumExtensions, EnumExtensions>();
            services.AddScoped<IClasesDocumentoOutputModelService, ClasesDocumentoOutputModelService>();
            services.AddRethusService(o => Configuration.GetSection("RethusService").Bind(o));
            services.AddMedicoService<MedicoService>(o => Configuration.GetSection("RethusService").Bind(o));
            services.AddScoped<IContabilidadOutputModelService, ContabilidadOutputModelService>();
            services.AddScoped<IContabilidadService, ContabilidadDomainService>();
            services.AddScoped<IClaseDocumentoDomainService, ClaseDocumentoDomainService>();
            services.AddScoped<ITipoAjusteDomainService, TipoAjusteDomainService>();
            services.AddScoped<ITipoAjusteOutputModelService, TipoAjusteOutputModelService>();
            services.AddScoped<IDepuracionContableDomainService, DepuracionContableDomainService>();
            services.AddScoped<IAuditoriaService, AuditoriaService>();
            services.AddScoped<IConceptoRehabilitacionService, ConceptoRehabilitacionService>();
            services.AddScoped<ICalificacionOrigenService, CalificacionOrigenService>();
            services.AddScoped<IRethusModelService, RethusModelService>();
            services.AddScoped(typeof(
            IDomainService<Movimiento, MovimientoInputModel>), typeof(MovimientoDomainService));
            services.Configure<ConfiguracionPowerBiModel>(Configuration.GetSection("EmbedSettings"));


            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSingleton(typeof(EmailService));

            services.AddCors(options =>
            {
                options.AddPolicy("general",
                builder =>
                {
                    builder.WithOrigins(Configuration["AllowedOrigins"].Split(";"))
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                });
            });

            /*/JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());*/

            #region Incapacidades
            services.AddSingleton<IServiceBusPersisterConnection>(sp =>
                {
                    var logger = sp.GetRequiredService<ILogger<ServiceBusPersisterConnection>>();

                    var serviceBusConnectionString = Configuration["ServiceBusConnection"];
                    var serviceBusConnection = new ServiceBusConnectionStringBuilder(serviceBusConnectionString);

                    return new ServiceBusPersisterConnection(serviceBusConnection, logger);
                });

            services.AddScoped<IValidacionIncapacidadesService, ValidacionIncapacidadesService>();
            services.AddScoped<IDiagnosticoIncapacidadService, DiagnosticoIncapacidadService>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prozess API V1");
                c.RoutePrefix = string.Empty;
                c.DisplayRequestDuration();
                c.EnableFilter();
                c.DefaultModelsExpandDepth(0);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseCors("general"); 
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Audios")),
            //    RequestPath = "/Audios"
            //});
        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }

        #region Helper Methods
        private static void CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            {
                var existingUserManager = scope.ServiceProvider
                     .GetService<UserManager<ApplicationUser>>();
                if (existingUserManager == null)
                {
                    services.AddIdentity<ApplicationUser, IdentityRole>()
                         .AddEntityFrameworkStores<AppIdentityDbContext>()
                                              .AddDefaultTokenProviders();
                }
            }
        }
        #endregion Helper Methods
    }
}

