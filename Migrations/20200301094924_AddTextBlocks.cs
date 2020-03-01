using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AscendedGuild.Migrations
{
    public partial class AddTextBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerClasses",
                columns: table => new
                {
                    PlayerClassId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClasses", x => x.PlayerClassId);
                });

            migrationBuilder.CreateTable(
                name: "TextBlocks",
                columns: table => new
                {
                    TextBlockId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SimpleId = table.Column<string>(maxLength: 100, nullable: false),
                    MarkdownContent = table.Column<string>(maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBlocks", x => x.TextBlockId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    SpecId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Demand = table.Column<int>(nullable: false),
                    PlayerClassId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.SpecId);
                    table.ForeignKey(
                        name: "FK_Specs_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "PlayerClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TwitchStreamers",
                columns: table => new
                {
                    TwitchStreamerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Channel = table.Column<string>(maxLength: 100, nullable: false),
                    GuildRank = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(maxLength: 100, nullable: false),
                    PlayerClassId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitchStreamers", x => x.TwitchStreamerId);
                    table.ForeignKey(
                        name: "FK_TwitchStreamers_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "PlayerClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TwitchStreamers_Specs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specs",
                        principalColumn: "SpecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlayerClasses",
                columns: new[] { "PlayerClassId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 4, "/images/class-icons/dh.png", "Demon Hunter" },
                    { 10, "/images/class-icons/hunter.png", "Hunter" },
                    { 9, "/images/class-icons/warlock.png", "Warlock" },
                    { 8, "/images/class-icons/paladin.png", "Paladin" },
                    { 7, "/images/class-icons/druid.png", "Druid" },
                    { 6, "/images/class-icons/shaman.png", "Shaman" },
                    { 5, "/images/class-icons/monk.png", "Monk" },
                    { 11, "/images/class-icons/priest.png", "Priest" },
                    { 12, "/images/class-icons/warrior.png", "Warrior" },
                    { 2, "/images/class-icons/mage.png", "Mage" },
                    { 1, "/images/class-icons/dk.png", "Death Knight" },
                    { 3, "/images/class-icons/rogue.png", "Rogue" }
                });

            migrationBuilder.InsertData(
                table: "TextBlocks",
                columns: new[] { "TextBlockId", "MarkdownContent", "Name", "SimpleId" },
                values: new object[,]
                {
                    { 5, "# Please enter the officers information and hit save #", "Officer Info", "about__officers" },
                    { 4, "# Please enter the contact information and hit save #", "Contact Us", "about__contact" },
                    { 3, "# Please enter the raid schedule and hit save #", "Raid Schedule", "about__raid-schedule" },
                    { 2, "# Please enter the raid history and hit save #", "Raid History", "about__raid-history" },
                    { 1, "# Please write an about-us blurb and hit save #", "Main Section", "about__main" }
                });

            migrationBuilder.InsertData(
                table: "Specs",
                columns: new[] { "SpecId", "Demand", "ImageUrl", "Name", "PlayerClassId" },
                values: new object[,]
                {
                    { 1, 0, "/images/class-icons/dk-blood.jpg", "Blood", 1 },
                    { 21, 0, "/images/class-icons/druid-restoration.jpg", "Restoration", 7 },
                    { 22, 0, "/images/class-icons/paladin-holy.jpg", "Holy", 8 },
                    { 23, 0, "/images/class-icons/paladin-protection.jpg", "Protection", 8 },
                    { 24, 0, "/images/class-icons/paladin-retribution.jpg", "Retribution", 8 },
                    { 25, 0, "/images/class-icons/warlock-affliction.jpg", "Affliction", 9 },
                    { 26, 0, "/images/class-icons/warlock-demonology.jpg", "Demonology", 9 },
                    { 20, 0, "/images/class-icons/druid-guardian.jpg", "Guardian", 7 },
                    { 27, 0, "/images/class-icons/warlock-destruction.jpg", "Destruction", 9 },
                    { 29, 0, "/images/class-icons/hunter-marksmanship.jpg", "Marksmanship", 10 },
                    { 30, 0, "/images/class-icons/hunter-survival.jpg", "Survival", 10 },
                    { 31, 0, "/images/class-icons/priest-discipline.jpg", "Discipline", 11 },
                    { 32, 0, "/images/class-icons/priest-holy.jpg", "Holy", 11 },
                    { 33, 0, "/images/class-icons/priest-shadow.jpg", "Shadow", 11 },
                    { 34, 0, "/images/class-icons/warrior-arms.jpg", "Arms", 12 },
                    { 28, 0, "/images/class-icons/hunter-bm.jpg", "Beast Mastery", 10 },
                    { 19, 0, "/images/class-icons/druid-feral.jpg", "Feral", 7 },
                    { 18, 0, "/images/class-icons/druid-balance.jpg", "Balance", 7 },
                    { 17, 0, "/images/class-icons/shaman-restoration.jpg", "Restoration", 6 },
                    { 2, 0, "/images/class-icons/dk-frost.jpg", "Frost", 1 },
                    { 3, 0, "/images/class-icons/dk-unholy.jpg", "Unholy", 1 },
                    { 4, 0, "/images/class-icons/mage-arcane.jpg", "Arcane", 2 },
                    { 5, 0, "/images/class-icons/mage-fire.jpg", "Fire", 2 },
                    { 6, 0, "/images/class-icons/mage-frost.jpg", "Frost", 2 },
                    { 7, 0, "/images/class-icons/rogue-assassination.jpg", "Assassination", 3 },
                    { 8, 0, "/images/class-icons/rogue-outlaw.jpg", "Outlaw", 3 },
                    { 9, 0, "/images/class-icons/rogue-subtlety.jpg", "Subtlety", 3 },
                    { 10, 0, "/images/class-icons/dh-havoc.jpg", "Havoc", 4 },
                    { 11, 0, "/images/class-icons/dh-vengeance.jpg", "Vengeance", 4 },
                    { 12, 0, "/images/class-icons/monk-brewmaster.jpg", "Brewmaster", 5 },
                    { 13, 0, "/images/class-icons/monk-mistweaver.jpg", "Mistweaver", 5 },
                    { 14, 0, "/images/class-icons/monk-windwalker.jpg", "Windwalker", 5 },
                    { 15, 0, "/images/class-icons/shaman-elemental.jpg", "Elemental", 6 },
                    { 16, 0, "/images/class-icons/shaman-enhancement.jpg", "Enhancement", 6 },
                    { 35, 0, "/images/class-icons/warrior-fury.jpg", "Fury", 12 },
                    { 36, 0, "/images/class-icons/warrior-protection.jpg", "Protection", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specs_PlayerClassId",
                table: "Specs",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitchStreamers_PlayerClassId",
                table: "TwitchStreamers",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitchStreamers_SpecId",
                table: "TwitchStreamers",
                column: "SpecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TextBlocks");

            migrationBuilder.DropTable(
                name: "TwitchStreamers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "PlayerClasses");
        }
    }
}
