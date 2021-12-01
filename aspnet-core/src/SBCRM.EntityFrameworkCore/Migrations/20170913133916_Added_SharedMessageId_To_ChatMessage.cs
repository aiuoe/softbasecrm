using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_SharedMessageId_To_ChatMessage : Migration
    {
        private readonly IDbContextSchema _schema;
        
        public Added_SharedMessageId_To_ChatMessage()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "SharedMessageId",
                table: "AppChatMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SharedMessageId",
                table: "AppChatMessages");
        }
    }
}
