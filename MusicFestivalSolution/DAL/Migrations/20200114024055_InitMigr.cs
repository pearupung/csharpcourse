using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FestivalName = table.Column<string>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    Venue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantTypes",
                columns: table => new
                {
                    ParticipantTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParticipantTypeName = table.Column<string>(nullable: false),
                    GetsHourly = table.Column<bool>(nullable: false),
                    HourlyWage = table.Column<int>(nullable: false),
                    GetsFixedSum = table.Column<bool>(nullable: false),
                    FixedSum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantTypes", x => x.ParticipantTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    IdCode = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    VatSubjectNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "TrackAuthorTypes",
                columns: table => new
                {
                    TrackAuthorTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrackAuthorTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackAuthorTypes", x => x.TrackAuthorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrackName = table.Column<string>(nullable: false),
                    LengthInSeconds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VenueName = table.Column<string>(nullable: false),
                    VenueAddress = table.Column<string>(nullable: false),
                    HourlyPrice = table.Column<int>(nullable: false),
                    SimplePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipmentName = table.Column<string>(nullable: false),
                    EquipmentHourlyPrice = table.Column<int>(nullable: false),
                    LenderPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Persons_LenderPersonId",
                        column: x => x.LenderPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackAuthors",
                columns: table => new
                {
                    TrackAuthorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    TrackAuthorTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackAuthors", x => x.TrackAuthorId);
                    table.ForeignKey(
                        name: "FK_TrackAuthors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackAuthors_TrackAuthorTypes_TrackAuthorTypeId",
                        column: x => x.TrackAuthorTypeId,
                        principalTable: "TrackAuthorTypes",
                        principalColumn: "TrackAuthorTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackAuthors_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    OrganisedEventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: false),
                    TicketCount = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<int>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    StartDate = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    EndDate = table.Column<string>(nullable: false),
                    PreparationTime = table.Column<string>(nullable: false),
                    CleanUpTime = table.Column<string>(nullable: false),
                    VenueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.OrganisedEventId);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalEvents",
                columns: table => new
                {
                    FestivalEventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganisedEventId = table.Column<int>(nullable: false),
                    FestivalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalEvents", x => x.FestivalEventId);
                    table.ForeignKey(
                        name: "FK_FestivalEvents_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalEvents_Events_OrganisedEventId",
                        column: x => x.OrganisedEventId,
                        principalTable: "Events",
                        principalColumn: "OrganisedEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParticipantTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    ParticipateBeginDate = table.Column<string>(nullable: false),
                    ParticipateBeginTime = table.Column<string>(nullable: false),
                    ParticipateEndDate = table.Column<string>(nullable: false),
                    ParticipateEndTime = table.Column<string>(nullable: false),
                    OrganisedEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_Events_OrganisedEventId",
                        column: x => x.OrganisedEventId,
                        principalTable: "Events",
                        principalColumn: "OrganisedEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_ParticipantTypes_ParticipantTypeId",
                        column: x => x.ParticipantTypeId,
                        principalTable: "ParticipantTypes",
                        principalColumn: "ParticipantTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    EventSetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SetName = table.Column<string>(nullable: false),
                    SetDuration = table.Column<string>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.EventSetId);
                    table.ForeignKey(
                        name: "FK_Sets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "OrganisedEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sets_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueEquipments",
                columns: table => new
                {
                    VenueEquipmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganisedEventId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<string>(nullable: false),
                    ArrivalAddress = table.Column<string>(nullable: false),
                    ReturnTime = table.Column<string>(nullable: false),
                    ReturnAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueEquipments", x => x.VenueEquipmentId);
                    table.ForeignKey(
                        name: "FK_VenueEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenueEquipments_Events_OrganisedEventId",
                        column: x => x.OrganisedEventId,
                        principalTable: "Events",
                        principalColumn: "OrganisedEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetTracks",
                columns: table => new
                {
                    SetTrackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QueueNumber = table.Column<int>(nullable: false),
                    PlannedPlayTimeInSeconds = table.Column<int>(nullable: false),
                    ActualPlayTimeInSeconds = table.Column<int>(nullable: false),
                    SetId = table.Column<int>(nullable: false),
                    EventSetId = table.Column<int>(nullable: true),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetTracks", x => x.SetTrackId);
                    table.ForeignKey(
                        name: "FK_SetTracks_Sets_EventSetId",
                        column: x => x.EventSetId,
                        principalTable: "Sets",
                        principalColumn: "EventSetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetTracks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_LenderPersonId",
                table: "Equipments",
                column: "LenderPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalEvents_FestivalId",
                table: "FestivalEvents",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalEvents_OrganisedEventId",
                table: "FestivalEvents",
                column: "OrganisedEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_OrganisedEventId",
                table: "Participants",
                column: "OrganisedEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantTypeId",
                table: "Participants",
                column: "ParticipantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PersonId",
                table: "Participants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_EventId",
                table: "Sets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_PersonId",
                table: "Sets",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SetTracks_EventSetId",
                table: "SetTracks",
                column: "EventSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SetTracks_TrackId",
                table: "SetTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackAuthors_PersonId",
                table: "TrackAuthors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackAuthors_TrackAuthorTypeId",
                table: "TrackAuthors",
                column: "TrackAuthorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackAuthors_TrackId",
                table: "TrackAuthors",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueEquipments_EquipmentId",
                table: "VenueEquipments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueEquipments_OrganisedEventId",
                table: "VenueEquipments",
                column: "OrganisedEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalEvents");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "SetTracks");

            migrationBuilder.DropTable(
                name: "TrackAuthors");

            migrationBuilder.DropTable(
                name: "VenueEquipments");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "ParticipantTypes");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "TrackAuthorTypes");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
