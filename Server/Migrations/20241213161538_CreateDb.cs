using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ByteCuisine.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ByteCuisine");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "ByteCuisine",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PictureData = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "ByteCuisine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "ByteCuisine",
                columns: table => new
                {
                    Ingredient_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Callories = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Ingredient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "ByteCuisine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActivityName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "ByteCuisine",
                        principalTable: "Account",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                schema: "ByteCuisine",
                columns: table => new
                {
                    Dish_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DishImage = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Dish_Id);
                    table.ForeignKey(
                        name: "FK_Dish_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "ByteCuisine",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsInFridge",
                schema: "ByteCuisine",
                columns: table => new
                {
                    IngredientsInFridge_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ingredient_Id = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsInFridge", x => x.IngredientsInFridge_Id);
                    table.ForeignKey(
                        name: "FK_IngredientsInFridge_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "ByteCuisine",
                        principalTable: "Account",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsInFridge_Ingredient_Ingredient_Id",
                        column: x => x.Ingredient_Id,
                        principalSchema: "ByteCuisine",
                        principalTable: "Ingredient",
                        principalColumn: "Ingredient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredient",
                schema: "ByteCuisine",
                columns: table => new
                {
                    DishIngredient_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dish_Id = table.Column<int>(type: "integer", nullable: false),
                    Ingredient_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredient", x => x.DishIngredient_Id);
                    table.ForeignKey(
                        name: "FK_DishIngredient_Dish_Dish_Id",
                        column: x => x.Dish_Id,
                        principalSchema: "ByteCuisine",
                        principalTable: "Dish",
                        principalColumn: "Dish_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredient_Ingredient_Ingredient_Id",
                        column: x => x.Ingredient_Id,
                        principalSchema: "ByteCuisine",
                        principalTable: "Ingredient",
                        principalColumn: "Ingredient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                schema: "ByteCuisine",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                schema: "ByteCuisine",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CategoryId",
                schema: "ByteCuisine",
                table: "Dish",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_Dish_Id",
                schema: "ByteCuisine",
                table: "DishIngredient",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_Ingredient_Id",
                schema: "ByteCuisine",
                table: "DishIngredient",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInFridge_AccountId",
                schema: "ByteCuisine",
                table: "IngredientsInFridge",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInFridge_Ingredient_Id",
                schema: "ByteCuisine",
                table: "IngredientsInFridge",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Log_AccountId",
                schema: "ByteCuisine",
                table: "Log",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredient",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "IngredientsInFridge",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "Dish",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "ByteCuisine");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "ByteCuisine");
        }
    }
}
