using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteCuisine.Server.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Dish_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Dish_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Ingredient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Callories = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Ingredient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Theme_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Theme_Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishIngredient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dish_Id = table.Column<int>(type: "int", nullable: false),
                    Ingredient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.DishIngredient_Id);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_Dish_Id",
                        column: x => x.Dish_Id,
                        principalTable: "Dishes",
                        principalColumn: "Dish_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_Ingredient_Id",
                        column: x => x.Ingredient_Id,
                        principalTable: "Ingredients",
                        principalColumn: "Ingredient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualFridges",
                columns: table => new
                {
                    VirtualFridge_Id = table.Column<int>(type: "int", nullable: false),
                    Theme_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualFridges", x => x.VirtualFridge_Id);
                    table.ForeignKey(
                        name: "FK_VirtualFridges_Accounts_VirtualFridge_Id",
                        column: x => x.VirtualFridge_Id,
                        principalTable: "Accounts",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualFridges_Themes_Theme_Id",
                        column: x => x.Theme_Id,
                        principalTable: "Themes",
                        principalColumn: "Theme_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsInFridges",
                columns: table => new
                {
                    IngredientsInFridge_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingredient_Id = table.Column<int>(type: "int", nullable: false),
                    VirtualFridge_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsInFridges", x => x.IngredientsInFridge_Id);
                    table.ForeignKey(
                        name: "FK_IngredientsInFridges_Ingredients_Ingredient_Id",
                        column: x => x.Ingredient_Id,
                        principalTable: "Ingredients",
                        principalColumn: "Ingredient_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsInFridges_VirtualFridges_VirtualFridge_Id",
                        column: x => x.VirtualFridge_Id,
                        principalTable: "VirtualFridges",
                        principalColumn: "VirtualFridge_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_Dish_Id",
                table: "DishIngredients",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_Ingredient_Id",
                table: "DishIngredients",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInFridges_Ingredient_Id",
                table: "IngredientsInFridges",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInFridges_VirtualFridge_Id",
                table: "IngredientsInFridges",
                column: "VirtualFridge_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualFridges_Theme_Id",
                table: "VirtualFridges",
                column: "Theme_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "IngredientsInFridges");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "VirtualFridges");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
