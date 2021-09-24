using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_1id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_2id",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "Vehiculos");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Parqueaderoid",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "actividad",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "autoriza",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cubiculo",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facultad",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "programa",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Parquaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidadPuestos = table.Column<int>(type: "int", nullable: false),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picoPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parquaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Puestos_Parquaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parquaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Puestos_Vehiculos_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tarifaHora = table.Column<float>(type: "real", nullable: false),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Parquaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parquaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Parqueaderoid",
                table: "Personas",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Parqueaderoid",
                table: "Puestos",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_vehiculoid",
                table: "Puestos",
                column: "vehiculoid");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_Parqueaderoid",
                table: "Transacciones",
                column: "Parqueaderoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Parquaderos_Parqueaderoid",
                table: "Personas",
                column: "Parqueaderoid",
                principalTable: "Parquaderos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_1id",
                table: "Personas",
                column: "vehiculo_1id",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_2id",
                table: "Personas",
                column: "vehiculo_2id",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Parquaderos_Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_1id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_2id",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Parquaderos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "actividad",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "autoriza",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "cubiculo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "facultad",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "programa",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Vehiculos",
                newName: "Vehiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_1id",
                table: "Personas",
                column: "vehiculo_1id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_2id",
                table: "Personas",
                column: "vehiculo_2id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
