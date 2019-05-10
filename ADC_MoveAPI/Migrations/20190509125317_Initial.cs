using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADC_MoveAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_AddressId",
                table: "Movie",
                column: "AddressId");

            migrationBuilder.Sql(
               @"
                     Insert into Address(id, Rua)values('68D0FE76-A8F6-4C63-8035-F7CA72FD1534','Teste');
                     
                 ");

            migrationBuilder.Sql(
                @"
                     Insert into Movie(id, title, Genre, ReleaseDate, Cpf, AddressId, Senha)values(NEWID(), 'The Shawshank Redemption','Drama','1994-10-14 00:00:00','02013010087','68D0FE76-A8F6-4C63-8035-F7CA72FD1534','123');
                     Insert into Movie(id, title, Genre, ReleaseDate, Cpf, AddressId, Senha)values(NEWID(), 'The Sixth Sense','Mystery','1999-08-06 00:00:00','71168755069','68D0FE76-A8F6-4C63-8035-F7CA72FD1534', '123');
                     Insert into Movie(id, title, Genre, ReleaseDate, Cpf, AddressId, Senha)values(NEWID(), 'A Separation','Drama','2011-07-01 00:00:00','71168755069','68D0FE76-A8F6-4C63-8035-F7CA72FD1534','123');
                 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
