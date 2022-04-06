using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class Menu
    {
        //public Menu()
        //{
        //	Random rnd = new Random();
        //	int icon = rnd.Next(1, 3);
        //	switch (icon)
        //	{
        //		case 1:
        //			Icon = "fas fa-shopping-basket";
        //			break;
        //		case 2:
        //			Icon = "fas fa-boxes";
        //			break;
        //		case 3:
        //			Icon = "fas fa-chart-bar";
        //			break;
        //		default:
        //			break;
        //	}
        //}

        /// <summary>
        /// The list of submenus owned by this menu item
        /// </summary>
        public List<Menu> Children { get; set; }

        /// <summary>
        /// Whether the menu is the home menu or not
        /// </summary>
        public bool Home { get; set; }

        /// <summary>
        /// The Font Awesome icon to be render
        /// </summary>
        /// <example>fas fa-boxes</example>
        [Required]
        public string Icon { get; set; }

        /// <summary>
        /// The Id of the Menu
        /// </summary>
        /// <example>1</example>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The Path of the content to be showed by the menu
        /// </summary>
        /// <example>https://www.prozesslaw.com.co/</example>
        public string Link { get; set; }

        /// <summary>
        /// The Hierarchy level of the menu
        /// </summary>
        /// <example>1</example>
        public int MenuLevel { get; set; }

        /// <summary>
        /// The relative position of the menu item
        /// </summary>
        /// <example>1</example>
        [Required]
        public int Position { get; set; }

        /// <summary>
        /// Whether the current menu is selected or not
        /// </summary>
        /// <example>false</example>
        public bool Selected { get; set; }

        /// <summary>
        /// The title to be displayed
        /// </summary>
        /// <example>Administracion</example>
        [Required, MinLength(2), MaxLength(40)]
        public string Title { get; set; }

        public bool EsReporte { get; set; }
        public Guid ReporteId { get; set; }
        public Guid ReporteGroupId { get; set; }
    }
}