using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GymSystemWeb.Models;

namespace GymSystemWeb.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GymSystemDB"].ConnectionString;
        }

        // Get all active gym branches
        public List<GymBranch> GetActiveBranches()
        {
            List<GymBranch> branches = new List<GymBranch>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetActiveBranches", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    branches.Add(new GymBranch
                    {
                        BranchID = Convert.ToInt32(reader["BranchID"]),
                        BranchName = reader["BranchName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        OpeningHours = reader["OpeningHours"].ToString(),
                        Description = reader["Description"].ToString(),
                        MapLocation = reader["MapLocation"].ToString(),
                        Rating = reader["Rating"] != DBNull.Value ? Convert.ToDecimal(reader["Rating"]) : 0,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    });
                }
            }

            return branches;
        }

        // Get detailed information for a specific gym branch
        public GymBranchDetailViewModel GetBranchDetails(int branchId)
        {
            GymBranchDetailViewModel branchDetail = new GymBranchDetailViewModel();
            branchDetail.Branch = new GymBranch();
            branchDetail.Facilities = new List<Facility>();
            branchDetail.Images = new List<BranchImage>();
            branchDetail.Trainers = new List<TrainerViewModel>();
            branchDetail.Reviews = new List<ReviewViewModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetBranchDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchID", branchId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Read branch info
                    if (reader.Read())
                    {
                        branchDetail.Branch = new GymBranch
                        {
                            BranchID = Convert.ToInt32(reader["BranchID"]),
                            BranchName = reader["BranchName"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            OpeningHours = reader["OpeningHours"].ToString(),
                            Description = reader["Description"].ToString(),
                            MapLocation = reader["MapLocation"].ToString(),
                            Rating = reader["Rating"] != DBNull.Value ? Convert.ToDecimal(reader["Rating"]) : 0,
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }

                    // Move to next result set (facilities)
                    reader.NextResult();
                    while (reader.Read())
                    {
                        branchDetail.Facilities.Add(new Facility
                        {
                            FacilityID = Convert.ToInt32(reader["FacilityID"]),
                            BranchID = Convert.ToInt32(reader["BranchID"]),
                            FacilityName = reader["FacilityName"].ToString(),
                            Description = reader["Description"].ToString(),
                            IconClass = reader["IconClass"].ToString()
                        });
                    }

                    // Move to next result set (images)
                    reader.NextResult();
                    while (reader.Read())
                    {
                        branchDetail.Images.Add(new BranchImage
                        {
                            ImageID = Convert.ToInt32(reader["ImageID"]),
                            BranchID = Convert.ToInt32(reader["BranchID"]),
                            ImageURL = reader["ImageURL"].ToString(),
                            Caption = reader["Caption"].ToString(),
                            IsMainImage = Convert.ToBoolean(reader["IsMainImage"])
                        });
                    }

                    // Move to next result set (trainers)
                    reader.NextResult();
                    while (reader.Read())
                    {
                        branchDetail.Trainers.Add(new TrainerViewModel
                        {
                            FullName = reader["FullName"].ToString(),
                            ProfileImage = reader["ProfileImage"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            Experience = Convert.ToInt32(reader["Experience"])
                        });
                    }

                    // Move to next result set (reviews)
                    reader.NextResult();
                    while (reader.Read())
                    {
                        branchDetail.Reviews.Add(new ReviewViewModel
                        {
                            Rating = Convert.ToInt32(reader["Rating"]),
                            Comment = reader["Comment"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            UserName = reader["FullName"].ToString()
                        });
                    }
                }
            }

            return branchDetail;
        }

        // Get all membership plans
        public List<MembershipPlan> GetMembershipPlans()
        {
            List<MembershipPlan> plans = new List<MembershipPlan>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM MembershipPlans WHERE IsActive = 1", connection);
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MembershipPlan plan = new MembershipPlan
                    {
                        PlanID = Convert.ToInt32(reader["PlanID"]),
                        PlanName = reader["PlanName"].ToString(),
                        Duration = Convert.ToInt32(reader["Duration"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        Benefits = new List<PlanBenefit>()
                    };

                    plans.Add(plan);
                }
            }

            // Get benefits for each plan
            foreach (var plan in plans)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM PlanBenefits WHERE PlanID = @PlanID", connection);
                    command.Parameters.AddWithValue("@PlanID", plan.PlanID);
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        plan.Benefits.Add(new PlanBenefit
                        {
                            BenefitID = Convert.ToInt32(reader["BenefitID"]),
                            PlanID = Convert.ToInt32(reader["PlanID"]),
                            BenefitDescription = reader["BenefitDescription"].ToString()
                        });
                    }
                }
            }

            return plans;
        }

        // Register a new user
        public int RegisterUser(User user)
        {
            int userId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_RegisterUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password); // Should be hashed before passing
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrEmpty(user.PhoneNumber) ? DBNull.Value : (object)user.PhoneNumber);
                command.Parameters.AddWithValue("@UserType", user.UserType);
                command.Parameters.AddWithValue("@Gender", string.IsNullOrEmpty(user.Gender) ? DBNull.Value : (object)user.Gender);

                connection.Open();
                userId = Convert.ToInt32(command.ExecuteScalar());
            }

            return userId;
        }
        
        // Other database methods for CRUD operations on different entities...
    }
} 