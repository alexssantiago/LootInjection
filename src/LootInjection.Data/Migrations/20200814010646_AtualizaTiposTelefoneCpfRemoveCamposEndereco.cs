using Microsoft.EntityFrameworkCore.Migrations;

namespace LootInjection.Data.Migrations
{
    public partial class AtualizaTiposTelefoneCpfRemoveCamposEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Enderecos");

            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Cpf",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
