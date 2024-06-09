using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("IngredientsInFridge", Schema = "ByteCuisine")]
    public class IngredientsInFridge
    {
        public int IngredientsInFridge_Id { get; set; }

        public int Ingredient_Id { get; set; }
        public Ingredient Ingredient { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
