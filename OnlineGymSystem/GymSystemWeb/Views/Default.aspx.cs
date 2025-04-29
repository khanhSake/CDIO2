using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemWeb.Models;
using GymSystemWeb.Services;

namespace GymSystemWeb.Views
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly DatabaseService _dbService;

        public Default()
        {
            _dbService = new DatabaseService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load gym branches
                LoadFeaturedBranches();
                
                // Load membership plans
                LoadMembershipPlans();
                
                // Check if user is logged in
                CheckLoginStatus();
            }
        }

        private void LoadFeaturedBranches()
        {
            try
            {
                // Get all active branches
                List<GymBranch> branches = _dbService.GetActiveBranches();
                
                // For the home page, we might want to show only a few featured branches
                // For simplicity, we'll just take the first 3 branches
                List<GymBranch> featuredBranches = branches.Count > 3 ? branches.GetRange(0, 3) : branches;
                
                rptFeaturedLocations.DataSource = featuredBranches;
                rptFeaturedLocations.DataBind();
            }
            catch (Exception ex)
            {
                // Log error and show user-friendly message
                // In a real application, you'd use proper logging here
                Response.Write("<script>alert('Error loading gym locations: " + ex.Message + "');</script>");
            }
        }

        private void LoadMembershipPlans()
        {
            try
            {
                List<MembershipPlan> plans = _dbService.GetMembershipPlans();
                rptMembershipPlans.DataSource = plans;
                rptMembershipPlans.DataBind();
            }
            catch (Exception ex)
            {
                // Log error and show user-friendly message
                Response.Write("<script>alert('Error loading membership plans: " + ex.Message + "');</script>");
            }
        }

        private void CheckLoginStatus()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                // User is logged in
                phLoggedIn.Visible = true;
                phLoggedOut.Visible = false;
                
                // Display username
                litUsername.Text = HttpContext.Current.Session["Username"].ToString();
            }
            else
            {
                // User is not logged in
                phLoggedIn.Visible = false;
                phLoggedOut.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Redirect to search results page with search parameter
                Response.Redirect("GymLocations.aspx?search=" + Server.UrlEncode(searchText));
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();
            
            // Redirect to home page
            Response.Redirect("Default.aspx");
        }
    }
} 