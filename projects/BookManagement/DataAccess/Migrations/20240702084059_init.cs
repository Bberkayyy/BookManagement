using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelfCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Shelfs_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivacyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteShares_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("001f7e28-1004-4003-8d93-898acf9ac96c"), "bberkayoguz@gmail.com", "Berkay", "OĞUZ", "yv/4lNmwzZR9pppqpkdzG8CYCV+r4NgyvHTWA12Yx6fCYNL2nUidio5Lodn50zssjZsCD4i8eIeq5m4xr3M/PQ==", new byte[] { 183, 171, 143, 221, 101, 131, 69, 128, 78, 53, 203, 74, 154, 133, 155, 18, 33, 17, 87, 236, 166, 218, 227, 131, 53, 230, 216, 234, 114, 6, 167, 94, 64, 59, 154, 100, 47, 31, 42, 171, 135, 8, 229, 127, 114, 84, 2, 141, 98, 177, 110, 52, 121, 193, 208, 133, 169, 21, 173, 3, 83, 203, 148, 95, 153, 44, 143, 185, 73, 60, 10, 64, 249, 146, 1, 220, 202, 228, 214, 196, 229, 225, 81, 129, 194, 207, 176, 130, 125, 113, 227, 128, 4, 91, 85, 237, 85, 71, 153, 38, 236, 118, 93, 224, 141, 191, 108, 138, 114, 74, 252, 97, 40, 23, 254, 176, 161, 60, 41, 32, 197, 15, 136, 172, 217, 117, 176, 229 }, "berkay" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { new Guid("c6ed66b4-a21d-44ff-8617-319d2036b697"), "ABD", "John", "Verdon" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("66398cf9-eb3c-4b73-9234-ed4182c5b133"), "Roman" });

            migrationBuilder.InsertData(
                table: "Shelfs",
                columns: new[] { "Id", "BookId", "Floor", "Section", "ShelfCode" },
                values: new object[] { 1, new Guid("ac029f7a-5cf8-46d4-826b-47f79a4f42a4"), 1, "Detective Novel", "A130" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "ShelfId", "Stock" },
                values: new object[] { new Guid("ac029f7a-5cf8-46d4-826b-47f79a4f42a4"), new Guid("c6ed66b4-a21d-44ff-8617-319d2036b697"), new Guid("66398cf9-eb3c-4b73-9234-ed4182c5b133"), "Sizi sizden bile iyi tanıyan bir katilin peşinizde olduğunu bilseniz, kaçmak için ne yapabilirsiniz? Polisiye türündeki eserleriyle okuyucuyu her defasında soluksuz bırakmayı başaran John Verdon’dan etkileyici bir yapıt daha! Aklında Bir Sayı Tut, bir seri katil ile onun peşine düşen bir dedektifin heyecan dolu kovalamacasını konu ediniyor. Bu katilin kurban seçtiği kişilerin ortak bir noktası var. Peki ama ne? Bu romanı okurken merakınıza engel olamayacak ve olayların sonunu asla tahmin edemeyeceksiniz!", "Kitap Resmi", "Aklından Bir Sayı Tut", 122m, 1, 500 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "AppUserId", "BookId", "Content", "IsPrivate" },
                values: new object[] { new Guid("26c7995e-c456-4d1c-889a-2af16f7f3848"), new Guid("001f7e28-1004-4003-8d93-898acf9ac96c"), new Guid("ac029f7a-5cf8-46d4-826b-47f79a4f42a4"), "Aklından Bir Sayı Tut Notu", true });

            migrationBuilder.InsertData(
                table: "NoteShares",
                columns: new[] { "Id", "NoteId", "PrivacyLevel" },
                values: new object[] { new Guid("dff06b4f-dbdb-4a93-a4f7-f8981d416220"), new Guid("26c7995e-c456-4d1c-889a-2af16f7f3848"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShelfId",
                table: "Books",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AppUserId",
                table: "Notes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookId",
                table: "Notes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteShares_NoteId",
                table: "NoteShares",
                column: "NoteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "NoteShares");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shelfs");
        }
    }
}
