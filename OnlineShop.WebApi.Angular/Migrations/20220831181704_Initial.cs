using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.WebApi.Angular.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5ffdeb4a-2b28-4fc8-9d41-30bd16984923"), "254a1351-77da-4b1f-b347-76876280c0a4", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("08d68e62-6e3b-4cf4-bfb0-49d59f670a5b"), 0, "b9e6a71d-84c7-4b3b-97c4-f135752c6d07", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEA3akXgm/NdlnRfPdOOoPnnIkBI6/6VrsO3H9bd3J0nCKi7y+LDqdaP5WmILHFUKnA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Title" },
                values: new object[,]
                {
                    { new Guid("18913488-917c-4748-b19f-37bb1b03b889"), "Salomon Group is a French sports equipment manufacturing company based in Annecy, France. It was founded in 1947 by François Salomon in the heart of the French Alps and is a major brand in outdoor sports equipment.", "", "Salomon Group", "Salomon Group" },
                    { new Guid("2c46fc6a-2b53-4ff3-bc2d-6388e82f9bdc"), "Under Armour, Inc. is an American sports equipment company that manufactures footwear, sports and casual apparel.", "", "Under Armour", "Under Armour" },
                    { new Guid("47fc022b-672d-4869-835f-84eef087f735"), "Hoka One One is an athletic shoe company originating in France that designs and markets running shoes.", "", "HOKA ONE ONE", "HOKA ONE ONE" },
                    { new Guid("4b40b766-f054-455d-be9d-30f22a80b48c"), "New Balance Athletics, Inc., best known as simply New Balance, is one of the world's major sports footwear and apparel manufacturers. Based in Boston, Massachusetts, the multinational corporation was founded in 1906 as the New Balance Arch Support Company. ", "", "New Balance", "New Balance" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Title" },
                values: new object[,]
                {
                    { new Guid("0e19b211-dc2a-490e-905d-a0420032cc57"), "A shoe is an item of footwear intended to protect and comfort the human foot. Shoes are also used as an item of decoration and fashion. The design of shoes has varied enormously through time and from culture to culture, with form originally being tied to function.", "", "Shoes", "Shoes" },
                    { new Guid("9da89049-b1fd-4074-8fbd-c9d62e58c59b"), "A T-shirt, or tee, is a style of fabric shirt named after the T shape of its body and sleeves. Traditionally, it has short sleeves and a round neckline, known as a crew neck, which lacks a collar. T-shirts are generally made of a stretchy, light, and inexpensive fabric and are easy to", "", "T-Shirts", "T-Shirts" },
                    { new Guid("db1c223f-de21-48ff-a7d7-1470e5587d1f"), "A jacket is a garment for the upper body, usually extending below the hips. A jacket typically has sleeves, and fastens in the front or slightly on the side. A jacket is generally lighter, tighter-fitting, and less insulating than a coat, which is outerwear.", "", "Jacket", "Jacket" },
                    { new Guid("e35a55c3-63f6-40dc-becf-d980367b36a6"), "Shorts are a garment worn over the pelvic area, circling the waist and splitting to cover the upper part of the legs, sometimes extending down to the knees but not covering the entire length of the leg.", "", "Shorts", "Shorts" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "Description", "ImgUrl", "Name", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("0966f6c6-505a-46bc-b424-d75dd3c7f85b"), new Guid("47fc022b-672d-4869-835f-84eef087f735"), "Hoka Tecton X Trail Running Shoes Named after the earth's tectonic plates, which inspired its revoluntionary parallel carbon fiber plate technology, the new Hoka Tecton X is poised to unleash a seismic shift in trail running. Built for speed, with a Profly X midsole bolstered by a Vibram Megagrip Litebase outsole, the Tecton X is Hoka's first trail shoe to incorporate dynamically propulsive,dual parallel carbon fiber plates.", "", "HOKA TECTON X", 174.0, "HOKA TECTON X TRAIL RUNNING SHOES - AW22" },
                    { new Guid("435bc615-f43f-497d-a2c6-51b9ce7fd4af"), new Guid("47fc022b-672d-4869-835f-84eef087f735"), "Higher State Seamfree Running T-ShirtRun with confidence and no distractions with the Higher State Seamfree Running T - Shirt.The Higher State Seamfree Running T - Shirt is a lightweight running tee with a seamfree construction for comfort and freedom of movement without the risk of irritation or unnecessary heavy materials holding you back.The lightweight material offers superior breathability allowing airflow in and out of the t - shirt easily.This prevents warm air from building up within the t - shirt and is replaced with cooler, fresher air.As you begin to sweat, the material works hard to wick away moisture keeping you feeling dry and comfortable and the top light.The back features further ventilation panels which help to keep your temperature down as your run intensifies.Lastly, the short sleeves are specially designed to allow a wide range of movement in all directions and the fit of the tee gives a soft next to skin feel without feeling too restrictive.", "", "HIGHER STATE RUNNING T-SHIRT", 9.0, "HIGHER STATE SEAMFREE RUNNING T-SHIRT" },
                    { new Guid("441af150-fdea-4784-9c99-057fd4a73d60"), new Guid("4b40b766-f054-455d-be9d-30f22a80b48c"), "New Balance Fresh Foam X Hierro V7 Trail Running ShoesPeople love the idea of adventure in the great outdoors,but there's more to the natural landscape than fresh air and scenic views. For those who take going off the beaten path literally, there's the Fresh Foam X Hierro, a dedicated,off - road application of our best running technology.", "", "NEW BALANCE FRESH FOAM", 129.0, "NEW BALANCE FRESH FOAM X HIERRO V7 TRAIL RUNNING SHOES - SS22" },
                    { new Guid("5c05add7-4333-4f5d-8182-04203fde6941"), new Guid("4b40b766-f054-455d-be9d-30f22a80b48c"), "New Balance Accelerate T-ShirtRun with comfort and confidence in the Accelerate T - shirt from New Balance.Signature NB Dry technology eradicates sweat and moisture while reflective details keep you visible in low light.", "", "NEW BALANCE ACCELERATE RUNNING", 139.0, "NEW BALANCE ACCELERATE RUNNING T-SHIRT - SS22" },
                    { new Guid("6f43d008-a379-4dfe-b7e1-834c9974cefb"), new Guid("18913488-917c-4748-b19f-37bb1b03b889"), "Salomon S/LAB NSO Running T-ShirtA lightweight running tee with NSO Self Activated Energy technology.The S / LAB NSO TEE harnesses next generation oxide mineral technology.", "", "SALOMON S/LAB ", 29.0, "SALOMON S/LAB NSO RUNNING T-SHIRT" },
                    { new Guid("76024e75-ada1-448c-9dcf-5b620eb01e52"), new Guid("2c46fc6a-2b53-4ff3-bc2d-6388e82f9bdc"), "Under Armour Flow Velociti Wind 2 Running ShoesThere's fast, and then there's UA Flow fast.Lightweight,rubberless,and durable,our newest cushioning gives a close - to - the - ground,grippy feeling of speed.The kind of speed that feels like you've got the wind at your back.", "", "UNDER ARMOUR FLOW VELOCITI WIND", 139.0, "UNDER ARMOUR FLOW VELOCITI WIND 2 RUNNING SHOES - SS22" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0e19b211-dc2a-490e-905d-a0420032cc57"), new Guid("0966f6c6-505a-46bc-b424-d75dd3c7f85b") },
                    { new Guid("9da89049-b1fd-4074-8fbd-c9d62e58c59b"), new Guid("435bc615-f43f-497d-a2c6-51b9ce7fd4af") },
                    { new Guid("0e19b211-dc2a-490e-905d-a0420032cc57"), new Guid("441af150-fdea-4784-9c99-057fd4a73d60") },
                    { new Guid("9da89049-b1fd-4074-8fbd-c9d62e58c59b"), new Guid("5c05add7-4333-4f5d-8182-04203fde6941") },
                    { new Guid("9da89049-b1fd-4074-8fbd-c9d62e58c59b"), new Guid("6f43d008-a379-4dfe-b7e1-834c9974cefb") },
                    { new Guid("0e19b211-dc2a-490e-905d-a0420032cc57"), new Guid("76024e75-ada1-448c-9dcf-5b620eb01e52") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
