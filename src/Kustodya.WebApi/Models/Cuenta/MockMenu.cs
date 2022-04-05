using System.Collections.Generic;

namespace WebApi.ViewModels
{
    public class MockMenu
    {
        public List<Menu> Mock { get; set; } = new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Icon = "/icon1.png",
                    Title = "Inicio",
                    Link = "https://prozessold.azurewebsites.net/Inicio.htm",
                    Position = 1,
                },
                new Menu {
                    Id = 2,
                    Icon = "/icon2.png",
                    Title = "Administracion",
                    Link = "https://prozessold.azurewebsites.net/Inicio.htm",
                    Position = 2,
                    Children = new List<Menu>
                    {
                        new Menu {
                            Id = 3,
                            Icon = "/icon3.png",
                            Title = "Usuarios",
                            Link = "https://www.facebook.com/",
                            Position = 1,
                            Children = new List<Menu>{
                                new Menu{
                                    Id = 4,
                                    Icon = "/icon4.png",
                                    Title = "Perfiles",
                                    Link = "https://www.google.com/",
                                    Position = 1,
                                }
                            }
                        },
                        new Menu
                        {
                            Id = 5,
                            Icon = "/icon5.png",
                            Title = "Usuarios",
                            Link = "htps://www.facebook.com/",
                            Position = 2,
                        }
                    }
                },
                new Menu {
                    Id = 6,
                    Icon = "/icon6.png",
                    Title = "Estructura de Caso",
                    Link = "https://prozessold.azurewebsites.net/Inicio.htm",
                    Position = 3,
                    Children = new List<Menu>
                        {
                            new Menu {
                            Id = 7,
                            Icon = "/icon7.png",
                            Title = "Perfiles",
                            Link = "https://www.youtube.com/",
                            Position = 1,
                        }
                    }
                },
                new Menu
                {
                    Id = 8,
                    Icon = "/icon8.png",
                    Title = "Seguimiento",
                    Link = "https://prozessold.azurewebsites.net/Inicio.htm",
                    Position = 4,
                }
            };
    }
}