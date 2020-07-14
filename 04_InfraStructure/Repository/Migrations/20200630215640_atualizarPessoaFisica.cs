using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class atualizarPessoaFisica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "PessoasFisicas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "PessoasFisicas");
        }
    }
}
