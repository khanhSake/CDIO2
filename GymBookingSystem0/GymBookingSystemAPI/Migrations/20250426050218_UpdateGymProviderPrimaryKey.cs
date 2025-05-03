using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGymProviderPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchImages_GymBranches_BranchID",
                table: "BranchImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_GymBranches_BranchID",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_GymBranches_GymProviders_ProviderID",
                table: "GymBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_GymProviders_Users_UserID",
                table: "GymProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_MembershipPackages_GymBranches_BranchID",
                table: "MembershipPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_GymBranches_BranchID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipPackages",
                table: "MembershipPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymProviders",
                table: "GymProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymBranches",
                table: "GymBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchImages",
                table: "BranchImages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RatingAverage",
                table: "GymProviders");

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "GymProviders");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "USERS");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "REVIEWS");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "FACILITIES");

            migrationBuilder.RenameTable(
                name: "MembershipPackages",
                newName: "MEMBERSHIP_PACKAGES");

            migrationBuilder.RenameTable(
                name: "GymProviders",
                newName: "GYM_PROVIDERS");

            migrationBuilder.RenameTable(
                name: "GymBranches",
                newName: "GYM_BRANCHES");

            migrationBuilder.RenameTable(
                name: "BranchImages",
                newName: "BRANCH_IMAGES");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserID",
                table: "REVIEWS",
                newName: "IX_REVIEWS_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BranchID",
                table: "REVIEWS",
                newName: "IX_REVIEWS_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_BranchID",
                table: "FACILITIES",
                newName: "IX_FACILITIES_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_MembershipPackages_BranchID",
                table: "MEMBERSHIP_PACKAGES",
                newName: "IX_MEMBERSHIP_PACKAGES_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_GymProviders_UserID",
                table: "GYM_PROVIDERS",
                newName: "IX_GYM_PROVIDERS_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GymBranches_ProviderID",
                table: "GYM_BRANCHES",
                newName: "IX_GYM_BRANCHES_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_BranchImages_BranchID",
                table: "BRANCH_IMAGES",
                newName: "IX_BRANCH_IMAGES_BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERS",
                table: "USERS",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_REVIEWS",
                table: "REVIEWS",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FACILITIES",
                table: "FACILITIES",
                column: "FacilityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MEMBERSHIP_PACKAGES",
                table: "MEMBERSHIP_PACKAGES",
                column: "PackageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GYM_PROVIDERS",
                table: "GYM_PROVIDERS",
                column: "ProviderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GYM_BRANCHES",
                table: "GYM_BRANCHES",
                column: "BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BRANCH_IMAGES",
                table: "BRANCH_IMAGES",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_BRANCH_IMAGES_GYM_BRANCHES_BranchID",
                table: "BRANCH_IMAGES",
                column: "BranchID",
                principalTable: "GYM_BRANCHES",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FACILITIES_GYM_BRANCHES_BranchID",
                table: "FACILITIES",
                column: "BranchID",
                principalTable: "GYM_BRANCHES",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GYM_BRANCHES_GYM_PROVIDERS_ProviderID",
                table: "GYM_BRANCHES",
                column: "ProviderID",
                principalTable: "GYM_PROVIDERS",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GYM_PROVIDERS_USERS_UserID",
                table: "GYM_PROVIDERS",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MEMBERSHIP_PACKAGES_GYM_BRANCHES_BranchID",
                table: "MEMBERSHIP_PACKAGES",
                column: "BranchID",
                principalTable: "GYM_BRANCHES",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_GYM_BRANCHES_BranchID",
                table: "REVIEWS",
                column: "BranchID",
                principalTable: "GYM_BRANCHES",
                principalColumn: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_USERS_UserID",
                table: "REVIEWS",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BRANCH_IMAGES_GYM_BRANCHES_BranchID",
                table: "BRANCH_IMAGES");

            migrationBuilder.DropForeignKey(
                name: "FK_FACILITIES_GYM_BRANCHES_BranchID",
                table: "FACILITIES");

            migrationBuilder.DropForeignKey(
                name: "FK_GYM_BRANCHES_GYM_PROVIDERS_ProviderID",
                table: "GYM_BRANCHES");

            migrationBuilder.DropForeignKey(
                name: "FK_GYM_PROVIDERS_USERS_UserID",
                table: "GYM_PROVIDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_MEMBERSHIP_PACKAGES_GYM_BRANCHES_BranchID",
                table: "MEMBERSHIP_PACKAGES");

            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_GYM_BRANCHES_BranchID",
                table: "REVIEWS");

            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_USERS_UserID",
                table: "REVIEWS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERS",
                table: "USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_REVIEWS",
                table: "REVIEWS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FACILITIES",
                table: "FACILITIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MEMBERSHIP_PACKAGES",
                table: "MEMBERSHIP_PACKAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GYM_PROVIDERS",
                table: "GYM_PROVIDERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GYM_BRANCHES",
                table: "GYM_BRANCHES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BRANCH_IMAGES",
                table: "BRANCH_IMAGES");

            migrationBuilder.RenameTable(
                name: "USERS",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "REVIEWS",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "FACILITIES",
                newName: "Facilities");

            migrationBuilder.RenameTable(
                name: "MEMBERSHIP_PACKAGES",
                newName: "MembershipPackages");

            migrationBuilder.RenameTable(
                name: "GYM_PROVIDERS",
                newName: "GymProviders");

            migrationBuilder.RenameTable(
                name: "GYM_BRANCHES",
                newName: "GymBranches");

            migrationBuilder.RenameTable(
                name: "BRANCH_IMAGES",
                newName: "BranchImages");

            migrationBuilder.RenameIndex(
                name: "IX_REVIEWS_UserID",
                table: "Reviews",
                newName: "IX_Reviews_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_REVIEWS_BranchID",
                table: "Reviews",
                newName: "IX_Reviews_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_FACILITIES_BranchID",
                table: "Facilities",
                newName: "IX_Facilities_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_MEMBERSHIP_PACKAGES_BranchID",
                table: "MembershipPackages",
                newName: "IX_MembershipPackages_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_GYM_PROVIDERS_UserID",
                table: "GymProviders",
                newName: "IX_GymProviders_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GYM_BRANCHES_ProviderID",
                table: "GymBranches",
                newName: "IX_GymBranches_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_BRANCH_IMAGES_BranchID",
                table: "BranchImages",
                newName: "IX_BranchImages_BranchID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RatingAverage",
                table: "GymProviders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "GymProviders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "FacilityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipPackages",
                table: "MembershipPackages",
                column: "PackageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymProviders",
                table: "GymProviders",
                column: "ProviderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymBranches",
                table: "GymBranches",
                column: "BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchImages",
                table: "BranchImages",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchImages_GymBranches_BranchID",
                table: "BranchImages",
                column: "BranchID",
                principalTable: "GymBranches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_GymBranches_BranchID",
                table: "Facilities",
                column: "BranchID",
                principalTable: "GymBranches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymBranches_GymProviders_ProviderID",
                table: "GymBranches",
                column: "ProviderID",
                principalTable: "GymProviders",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymProviders_Users_UserID",
                table: "GymProviders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipPackages_GymBranches_BranchID",
                table: "MembershipPackages",
                column: "BranchID",
                principalTable: "GymBranches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_GymBranches_BranchID",
                table: "Reviews",
                column: "BranchID",
                principalTable: "GymBranches",
                principalColumn: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
