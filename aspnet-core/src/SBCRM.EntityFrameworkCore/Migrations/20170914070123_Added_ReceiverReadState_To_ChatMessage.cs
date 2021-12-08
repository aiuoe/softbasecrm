using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_ReceiverReadState_To_ChatMessage : Migration
    {
        private readonly IDbContextSchema _schema;
        public Added_ReceiverReadState_To_ChatMessage()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "ReceiverReadState",
                table: "AppChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ReceiverReadState",
                table: "AppChatMessages");
        }
    }
}
