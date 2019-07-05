using Microsoft.EntityFrameworkCore.Migrations;

namespace SkinCol.Data.Migrations
{
    public partial class CreateRedLineFacturaInsumos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FacturaInsumos_MaterialID",
                table: "FacturaInsumos",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaInsumos_ProveedorID",
                table: "FacturaInsumos",
                column: "ProveedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaInsumos_Material_MaterialID",
                table: "FacturaInsumos",
                column: "MaterialID",
                principalTable: "Material",
                principalColumn: "MaterialID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaInsumos_Proveedor_ProveedorID",
                table: "FacturaInsumos",
                column: "ProveedorID",
                principalTable: "Proveedor",
                principalColumn: "ProveedorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaInsumos_Material_MaterialID",
                table: "FacturaInsumos");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaInsumos_Proveedor_ProveedorID",
                table: "FacturaInsumos");

            migrationBuilder.DropIndex(
                name: "IX_FacturaInsumos_MaterialID",
                table: "FacturaInsumos");

            migrationBuilder.DropIndex(
                name: "IX_FacturaInsumos_ProveedorID",
                table: "FacturaInsumos");
        }
    }
}
