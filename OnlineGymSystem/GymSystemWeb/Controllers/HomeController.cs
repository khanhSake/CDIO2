using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GymSystemWeb.Models;
using GymSystemWeb.Services;

namespace GymSystemWeb.Controllers
{
    public class HomeController : Page
    {
        private readonly DatabaseService _dbService;

        public HomeController()
        {
            _dbService = new DatabaseService();
        }

        // Method to bind gym branches to the repeater control
        protected void BindGymBranches(Repeater repeater)
        {
            List<GymBranch> branches = _dbService.GetActiveBranches();
            repeater.DataSource = branches;
            repeater.DataBind();
        }

        // Method to handle search functionality
        protected void SearchGymBranches(string searchText, Repeater repeater)
        {
            List<GymBranch> branches = _dbService.GetActiveBranches();
            List<GymBranch> filteredBranches = new List<GymBranch>();

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                foreach (var branch in branches)
                {
                    if (branch.BranchName.ToLower().Contains(searchText) ||
                        branch.Address.ToLower().Contains(searchText) ||
                        branch.City.ToLower().Contains(searchText))
                    {
                        filteredBranches.Add(branch);
                    }
                }
                repeater.DataSource = filteredBranches;
            }
            else
            {
                repeater.DataSource = branches;
            }
            
            repeater.DataBind();
        }

        // Method to get gym branch details for detailed view
        protected GymBranchDetailViewModel GetGymBranchDetails(int branchId)
        {
            return _dbService.GetBranchDetails(branchId);
        }

        // Method to get all membership plans
        protected List<MembershipPlan> GetMembershipPlans()
        {
            return _dbService.GetMembershipPlans();
        }

        // Method to handle user registration
        protected int RegisterUser(User user)
        {
            // Hash password before storing
            user.Password = HashPassword(user.Password);
            
            return _dbService.RegisterUser(user);
        }

        // Helper method to hash passwords
        private string HashPassword(string password)
        {
            // In a real application, use a proper password hashing library
            // For demonstration, we're using a simple hash
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }
    }
} 