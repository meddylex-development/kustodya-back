namespace WebApi.ViewModels
{
    public class Entity
    {
        /// <summary>
        /// The Id of the entity
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// The title to be displayed in the ui
        /// </summary>
        /// <example>Banco Davivienda SA</example>
        public string Title { get; set; }
    }
}