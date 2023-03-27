using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(350)", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "varchar(1000)", nullable: false),
                    lastName = table.Column<string>(type: "varchar(1000)", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    gender = table.Column<bool>(type: "boolean", nullable: false),
                    bookingStatus = table.Column<bool>(type: "boolean", nullable: false),
                    banStatus = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryName = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    depositID = table.Column<Guid>(type: "uuid", nullable: false),
                    deposit = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.depositID);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseName = table.Column<string>(type: "text", nullable: false),
                    exerciseTimePerWeek = table.Column<int>(type: "integer", nullable: false),
                    flag = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.exerciseID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    medicalRecordID = table.Column<Guid>(type: "uuid", nullable: false),
                    presentIllness = table.Column<string>(type: "text", nullable: false),
                    pastMedical = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.medicalRecordID);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSlot",
                columns: table => new
                {
                    typeOfSlotID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotName = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSlot", x => x.typeOfSlotID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "PhysiotherapistDetail",
                columns: table => new
                {
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    specialize = table.Column<string>(type: "text", nullable: false),
                    skill = table.Column<string>(type: "text", nullable: false),
                    schedulingStatus = table.Column<int>(type: "integer", nullable: false),
                    scheduleStatus = table.Column<int>(type: "integer", nullable: false),
                    workingStatus = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiotherapistDetail", x => x.physiotherapistID);
                    table.ForeignKey(
                        name: "FK_PhysiotherapistDetail_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseFeedback",
                columns: table => new
                {
                    exerciseFeedbackID = table.Column<Guid>(type: "uuid", nullable: false),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    feedbackContent = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseFeedback", x => x.exerciseFeedbackID);
                    table.ForeignKey(
                        name: "FK_ExerciseFeedback_Exercise_exerciseID",
                        column: x => x.exerciseID,
                        principalTable: "Exercise",
                        principalColumn: "exerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    userExerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    duarationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => x.userExerciseID);
                    table.ForeignKey(
                        name: "FK_UserExercise_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercise_Exercise_exerciseID",
                        column: x => x.exerciseID,
                        principalTable: "Exercise",
                        principalColumn: "exerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProfile",
                columns: table => new
                {
                    profileID = table.Column<Guid>(type: "uuid", nullable: false),
                    medicalRecordID = table.Column<Guid>(type: "uuid", nullable: false),
                    medicalRecord = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    profileName = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProfile", x => x.profileID);
                    table.ForeignKey(
                        name: "FK_SubProfile_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProfile_MedicalRecord_medicalRecord",
                        column: x => x.medicalRecord,
                        principalTable: "MedicalRecord",
                        principalColumn: "medicalRecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSchedule",
                columns: table => new
                {
                    bookingScheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    profileID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    timeChooseStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    timeChooseEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSchedule", x => x.bookingScheduleID);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_SubProfile_profileID",
                        column: x => x.profileID,
                        principalTable: "SubProfile",
                        principalColumn: "profileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedbackID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    bookingScheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    ratingStar = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedbackID);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_BookingSchedule_bookingScheduleID",
                        column: x => x.bookingScheduleID,
                        principalTable: "BookingSchedule",
                        principalColumn: "bookingScheduleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDetail",
                columns: table => new
                {
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    resourceID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseTimePerSet = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDetail", x => x.exerciseDetailID);
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_Exercise_exerciseID",
                        column: x => x.exerciseID,
                        principalTable: "Exercise",
                        principalColumn: "exerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseResource",
                columns: table => new
                {
                    exerciseResourceID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    videoURL = table.Column<string>(type: "text", nullable: false),
                    imageURL = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseResource", x => x.exerciseResourceID);
                    table.ForeignKey(
                        name: "FK_ExerciseResource_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysiotherapistSlot",
                columns: table => new
                {
                    physiotherapistSlotID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiotherapistSlot", x => x.physiotherapistSlotID);
                    table.ForeignKey(
                        name: "FK_PhysiotherapistSlot_PhysiotherapistDetail_physiotherapistID",
                        column: x => x.physiotherapistID,
                        principalTable: "PhysiotherapistDetail",
                        principalColumn: "physiotherapistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    typeOfSlotID = table.Column<Guid>(type: "uuid", nullable: false),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    totalScheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    timeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    timeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duaration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    fee = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.slotID);
                    table.ForeignKey(
                        name: "FK_Slot_Exercise_exerciseID",
                        column: x => x.exerciseID,
                        principalTable: "Exercise",
                        principalColumn: "exerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_PhysiotherapistDetail_physiotherapistID",
                        column: x => x.physiotherapistID,
                        principalTable: "PhysiotherapistDetail",
                        principalColumn: "physiotherapistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_TypeOfSlot_typeOfSlotID",
                        column: x => x.typeOfSlotID,
                        principalTable: "TypeOfSlot",
                        principalColumn: "typeOfSlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalSchedule",
                columns: table => new
                {
                    totalScheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    day = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    timeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    timeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duaration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalSchedule", x => x.totalScheduleID);
                    table.ForeignKey(
                        name: "FK_TotalSchedule_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalSchedule_PhysiotherapistDetail_physiotherapistID",
                        column: x => x.physiotherapistID,
                        principalTable: "PhysiotherapistDetail",
                        principalColumn: "physiotherapistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalSchedule_Slot_slotID",
                        column: x => x.slotID,
                        principalTable: "Slot",
                        principalColumn: "slotID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

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
                name: "IX_BookingSchedule_profileID",
                table: "BookingSchedule",
                column: "profileID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_slotID",
                table: "BookingSchedule",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_userID",
                table: "BookingSchedule",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_categoryID",
                table: "ExerciseDetail",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_exerciseID",
                table: "ExerciseDetail",
                column: "exerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_resourceID",
                table: "ExerciseDetail",
                column: "resourceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFeedback_exerciseID",
                table: "ExerciseFeedback",
                column: "exerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseResource_exerciseDetailID",
                table: "ExerciseResource",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_bookingScheduleID",
                table: "Feedback",
                column: "bookingScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_userID",
                table: "Feedback",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysiotherapistDetail_userID",
                table: "PhysiotherapistDetail",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysiotherapistSlot_physiotherapistID",
                table: "PhysiotherapistSlot",
                column: "physiotherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysiotherapistSlot_slotID",
                table: "PhysiotherapistSlot",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_exerciseID",
                table: "Slot",
                column: "exerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_physiotherapistID",
                table: "Slot",
                column: "physiotherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_totalScheduleID",
                table: "Slot",
                column: "totalScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_typeOfSlotID",
                table: "Slot",
                column: "typeOfSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProfile_medicalRecord",
                table: "SubProfile",
                column: "medicalRecord");

            migrationBuilder.CreateIndex(
                name: "IX_SubProfile_userID",
                table: "SubProfile",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_TotalSchedule_physiotherapistID",
                table: "TotalSchedule",
                column: "physiotherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_TotalSchedule_slotID",
                table: "TotalSchedule",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_TotalSchedule_userID",
                table: "TotalSchedule",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_exerciseID",
                table: "UserExercise",
                column: "exerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_userID",
                table: "UserExercise",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Slot_slotID",
                table: "BookingSchedule",
                column: "slotID",
                principalTable: "Slot",
                principalColumn: "slotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDetail_ExerciseResource_resourceID",
                table: "ExerciseDetail",
                column: "resourceID",
                principalTable: "ExerciseResource",
                principalColumn: "exerciseResourceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysiotherapistSlot_Slot_slotID",
                table: "PhysiotherapistSlot",
                column: "slotID",
                principalTable: "Slot",
                principalColumn: "slotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_TotalSchedule_totalScheduleID",
                table: "Slot",
                column: "totalScheduleID",
                principalTable: "TotalSchedule",
                principalColumn: "totalScheduleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysiotherapistDetail_AspNetUsers_userID",
                table: "PhysiotherapistDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalSchedule_AspNetUsers_userID",
                table: "TotalSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalSchedule_Slot_slotID",
                table: "TotalSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDetail_Category_categoryID",
                table: "ExerciseDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDetail_ExerciseResource_resourceID",
                table: "ExerciseDetail");

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
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "ExerciseFeedback");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "PhysiotherapistSlot");

            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BookingSchedule");

            migrationBuilder.DropTable(
                name: "SubProfile");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "TotalSchedule");

            migrationBuilder.DropTable(
                name: "TypeOfSlot");

            migrationBuilder.DropTable(
                name: "PhysiotherapistDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ExerciseResource");

            migrationBuilder.DropTable(
                name: "ExerciseDetail");

            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}
