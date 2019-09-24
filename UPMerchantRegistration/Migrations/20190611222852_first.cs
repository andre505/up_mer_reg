using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UPMerchantRegistration.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "agent_lga_id_seq");

            migrationBuilder.CreateTable(
                name: "acctype",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    accounttype = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acctype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agentlga",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValueSql: "nextval('agent_lga_id_seq'::regclass)"),
                    agentid = table.Column<string>(maxLength: 255, nullable: false),
                    lga1id = table.Column<string>(maxLength: 255, nullable: false),
                    lga2id = table.Column<string>(maxLength: 255, nullable: true),
                    lga3id = table.Column<string>(maxLength: 255, nullable: true),
                    lga4id = table.Column<string>(maxLength: 255, nullable: true),
                    lga5id = table.Column<string>(maxLength: 255, nullable: true),
                    lga6id = table.Column<string>(maxLength: 255, nullable: true),
                    lga7id = table.Column<string>(maxLength: 255, nullable: true),
                    lga8id = table.Column<string>(maxLength: 255, nullable: true),
                    lga9id = table.Column<string>(maxLength: 255, nullable: true),
                    lga10id = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agentlga", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    statecode = table.Column<string>(maxLength: 255, nullable: false),
                    statename = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lga",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    lgacode = table.Column<string>(maxLength: 255, nullable: true),
                    lganame = table.Column<string>(maxLength: 255, nullable: true),
                    stateid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lga", x => x.id);
                    table.ForeignKey(
                        name: "lg_state_fk",
                        column: x => x.stateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companyshareholders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    firstname = table.Column<string>(maxLength: 255, nullable: true),
                    middlename = table.Column<string>(maxLength: 255, nullable: true),
                    lastname = table.Column<string>(maxLength: 255, nullable: true),
                    gender = table.Column<string>(maxLength: 255, nullable: true),
                    stateid = table.Column<int>(nullable: true),
                    lgaid = table.Column<int>(nullable: true),
                    agentid = table.Column<int>(nullable: true),
                    address = table.Column<string>(maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyshareholders", x => x.id);
                    table.ForeignKey(
                        name: "bus_props_lga_fk",
                        column: x => x.lgaid,
                        principalTable: "lga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "comp_shldrs_state_fk",
                        column: x => x.stateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "upagent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    phonenumber = table.Column<string>(maxLength: 11, nullable: true),
                    firstname = table.Column<string>(maxLength: 255, nullable: true),
                    middlename = table.Column<string>(maxLength: 255, nullable: true),
                    lastname = table.Column<string>(maxLength: 255, nullable: true),
                    homeaddress = table.Column<string>(maxLength: 255, nullable: true),
                    stateid = table.Column<int>(nullable: true),
                    lgaid = table.Column<int>(nullable: true),
                    gender = table.Column<string>(maxLength: 255, nullable: true),
                    officeaddress = table.Column<string>(maxLength: 255, nullable: true),
                    officestateid = table.Column<int>(nullable: true),
                    officelgaid = table.Column<int>(nullable: true),
                    desstateid = table.Column<int>(nullable: true),
                    deslgaid = table.Column<int>(nullable: true),
                    businessname = table.Column<string>(maxLength: 255, nullable: true),
                    rcnumber = table.Column<string>(maxLength: 255, nullable: true),
                    natureofbusiness = table.Column<string>(maxLength: 255, nullable: false),
                    turnover = table.Column<string>(maxLength: 255, nullable: true),
                    profitbeforetax = table.Column<string>(maxLength: 255, nullable: true),
                    businessemail = table.Column<string>(maxLength: 255, nullable: true),
                    businessphone = table.Column<string>(maxLength: 255, nullable: true),
                    noofbusinessyears = table.Column<string>(maxLength: 255, nullable: true),
                    noofproprietors = table.Column<string>(maxLength: 255, nullable: true),
                    noofshareholders = table.Column<string>(maxLength: 255, nullable: true),
                    acctypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upagent", x => x.id);
                    table.ForeignKey(
                        name: "acctype_accs_fk",
                        column: x => x.acctypeid,
                        principalTable: "acctype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "agent_lga_fk",
                        column: x => x.lgaid,
                        principalTable: "lga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "des_lga_fk",
                        column: x => x.officelgaid,
                        principalTable: "lga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "des_state_fk",
                        column: x => x.officestateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "agent_state_fk",
                        column: x => x.stateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "businessproprietors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    firstname = table.Column<string>(maxLength: 255, nullable: true),
                    middlename = table.Column<string>(maxLength: 255, nullable: true),
                    lastname = table.Column<string>(maxLength: 255, nullable: true),
                    gender = table.Column<string>(maxLength: 255, nullable: true),
                    stateid = table.Column<int>(nullable: true),
                    lgaid = table.Column<int>(nullable: true),
                    agentid = table.Column<int>(nullable: true),
                    address = table.Column<string>(maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessproprietors", x => x.id);
                    table.ForeignKey(
                        name: "bus_props_agent_fk",
                        column: x => x.agentid,
                        principalTable: "upagent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "bus_props_lga_fk",
                        column: x => x.lgaid,
                        principalTable: "lga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "bus_props_state_fk",
                        column: x => x.stateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_businessproprietors_agentid",
                table: "businessproprietors",
                column: "agentid");

            migrationBuilder.CreateIndex(
                name: "IX_businessproprietors_lgaid",
                table: "businessproprietors",
                column: "lgaid");

            migrationBuilder.CreateIndex(
                name: "IX_businessproprietors_stateid",
                table: "businessproprietors",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_companyshareholders_lgaid",
                table: "companyshareholders",
                column: "lgaid");

            migrationBuilder.CreateIndex(
                name: "IX_companyshareholders_stateid",
                table: "companyshareholders",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_lga_stateid",
                table: "lga",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_upagent_acctypeid",
                table: "upagent",
                column: "acctypeid");

            migrationBuilder.CreateIndex(
                name: "IX_upagent_lgaid",
                table: "upagent",
                column: "lgaid");

            migrationBuilder.CreateIndex(
                name: "IX_upagent_officelgaid",
                table: "upagent",
                column: "officelgaid");

            migrationBuilder.CreateIndex(
                name: "IX_upagent_officestateid",
                table: "upagent",
                column: "officestateid");

            migrationBuilder.CreateIndex(
                name: "IX_upagent_stateid",
                table: "upagent",
                column: "stateid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agentlga");

            migrationBuilder.DropTable(
                name: "businessproprietors");

            migrationBuilder.DropTable(
                name: "companyshareholders");

            migrationBuilder.DropTable(
                name: "upagent");

            migrationBuilder.DropTable(
                name: "acctype");

            migrationBuilder.DropTable(
                name: "lga");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropSequence(
                name: "agent_lga_id_seq");
        }
    }
}
