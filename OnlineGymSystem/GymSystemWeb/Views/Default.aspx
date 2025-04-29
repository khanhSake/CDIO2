<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GymSystemWeb.Views.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>GymSystem Online - Hệ thống phòng tập hàng đầu Việt Nam</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="Default.aspx">GymSystem Online</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav me-auto">
                        <li class="nav-item">
                            <a class="nav-link active" href="Default.aspx">Trang chủ</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="GymLocations.aspx">Phòng tập</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Trainers.aspx">Huấn luyện viên</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Classes.aspx">Lớp tập</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Membership.aspx">Thành viên</a>
                        </li>
                    </ul>
                    
                    <div class="d-flex align-items-center">
                        <asp:PlaceHolder ID="phLoggedOut" runat="server" Visible="true">
                            <a href="Login.aspx" class="btn btn-outline-light me-2">Đăng nhập</a>
                            <a href="Register.aspx" class="btn btn-primary">Đăng ký</a>
                        </asp:PlaceHolder>
                        
                        <asp:PlaceHolder ID="phLoggedIn" runat="server" Visible="false">
                            <div class="dropdown">
                                <button class="btn btn-outline-light dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                                    <asp:Literal ID="litUsername" runat="server"></asp:Literal>
                                </button>
                                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="dropdownMenuButton">
                                    <li><a class="dropdown-item" href="UserProfile.aspx">Hồ sơ cá nhân</a></li>
                                    <li><a class="dropdown-item" href="UserSubscriptions.aspx">Gói tập</a></li>
                                    <li><a class="dropdown-item" href="UserBookings.aspx">Lịch tập</a></li>
                                    <li><hr class="dropdown-divider" /></li>
                                    <li><asp:LinkButton ID="btnLogout" runat="server" CssClass="dropdown-item" OnClick="btnLogout_Click">Đăng xuất</asp:LinkButton></li>
                                </ul>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </nav>

        <!-- Hero Section -->
        <div class="hero-section">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6">
                        <h1 class="hero-title">Khám phá sức khỏe. Khám phá bản thân.</h1>
                        <p class="hero-subtitle">GymSystem Online - Hệ thống phòng tập thể hình hàng đầu với 20+ chi nhánh trên toàn quốc.</p>
                        
                        <!-- Search form -->
                        <div class="card search-card">
                            <div class="card-body">
                                <h5 class="card-title">Tìm phòng tập gần bạn</h5>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Nhập địa điểm, quận, thành phố..."></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <img src="../Content/images/hero-image.jpg" alt="GymSystem Online" class="img-fluid rounded hero-image" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Featured Locations -->
        <section class="container section-padding">
            <div class="d-flex justify-content-between align-items-center mb-4">
                <h2>Phòng tập nổi bật</h2>
                <a href="GymLocations.aspx" class="btn btn-outline-primary">Xem tất cả</a>
            </div>

            <div class="row">
                <asp:Repeater ID="rptFeaturedLocations" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card gym-card">
                                <div class="gym-card-img-container">
                                    <img src="../Content/images/gym-placeholder.jpg" alt='<%# Eval("BranchName") %>' class="card-img-top" />
                                    <span class="rating-badge"><i class="fas fa-star me-1"></i><%# Eval("Rating") %></span>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("BranchName") %></h5>
                                    <p class="card-text location"><i class="fas fa-map-marker-alt me-2"></i><%# Eval("Address") %>, <%# Eval("City") %></p>
                                    <p class="card-text hours"><i class="fas fa-clock me-2"></i><%# Eval("OpeningHours") %></p>
                                    <a href='GymDetails.aspx?id=<%# Eval("BranchID") %>' class="btn btn-outline-primary mt-2 w-100">Chi tiết</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <!-- Membership Plans -->
        <section class="bg-light section-padding">
            <div class="container">
                <h2 class="text-center mb-5">Gói tập của chúng tôi</h2>
                
                <div class="row">
                    <asp:Repeater ID="rptMembershipPlans" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card membership-card h-100">
                                    <div class="card-header text-center">
                                        <h3 class="membership-name"><%# Eval("PlanName") %></h3>
                                        <div class="price">
                                            <span class="amount"><%# String.Format("{0:N0}", Eval("Price")) %></span>
                                            <span class="period">VNĐ / <%# Eval("Duration") %> tháng</span>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-text"><%# Eval("Description") %></p>
                                        <ul class="benefits-list">
                                            <asp:Repeater ID="rptBenefits" runat="server" DataSource='<%# Eval("Benefits") %>'>
                                                <ItemTemplate>
                                                    <li><i class="fas fa-check-circle me-2 text-success"></i><%# Eval("BenefitDescription") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div class="card-footer text-center">
                                        <a href='Membership.aspx?plan=<%# Eval("PlanID") %>' class="btn btn-primary">Đăng ký ngay</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>

        <!-- Features -->
        <section class="container section-padding">
            <h2 class="text-center mb-5">Tại sao chọn GymSystem Online?</h2>
            
            <div class="row g-4">
                <div class="col-md-4">
                    <div class="feature-box text-center">
                        <div class="feature-icon">
                            <i class="fas fa-dumbbell"></i>
                        </div>
                        <h3>Thiết bị hiện đại</h3>
                        <p>Trang bị đầy đủ các thiết bị tập luyện hiện đại từ các thương hiệu hàng đầu thế giới.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="feature-box text-center">
                        <div class="feature-icon">
                            <i class="fas fa-users"></i>
                        </div>
                        <h3>Huấn luyện viên chuyên nghiệp</h3>
                        <p>Đội ngũ HLV giàu kinh nghiệm, được đào tạo bài bản sẽ giúp bạn đạt được mục tiêu nhanh chóng.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="feature-box text-center">
                        <div class="feature-icon">
                            <i class="fas fa-clock"></i>
                        </div>
                        <h3>Mở cửa 24/7</h3>
                        <p>Phòng tập mở cửa mọi lúc, phù hợp với mọi lịch trình bận rộn của bạn.</p>
                    </div>
                </div>
            </div>
        </section>

        <!-- Call to Action -->
        <section class="bg-primary text-white py-5">
            <div class="container text-center">
                <h2 class="mb-4">Sẵn sàng bắt đầu hành trình của bạn?</h2>
                <p class="lead mb-4">Trở thành thành viên ngay hôm nay và nhận ưu đãi đặc biệt dành cho hội viên mới.</p>
                <a href="Register.aspx" class="btn btn-light btn-lg me-3">Đăng ký ngay</a>
                <a href="GymLocations.aspx" class="btn btn-outline-light btn-lg">Tìm phòng tập</a>
            </div>
        </section>

        <!-- Footer -->
        <footer class="bg-dark text-white py-4">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <h5>GymSystem Online</h5>
                        <p>Mạng lưới phòng tập hiện đại hàng đầu Việt Nam với hơn 20 cơ sở trên toàn quốc.</p>
                    </div>
                    <div class="col-md-4 mb-4">
                        <h5>Liên kết nhanh</h5>
                        <ul class="list-unstyled">
                            <li><a href="About.aspx" class="text-white">Về chúng tôi</a></li>
                            <li><a href="GymLocations.aspx" class="text-white">Tìm phòng tập</a></li>
                            <li><a href="Trainers.aspx" class="text-white">Huấn luyện viên</a></li>
                            <li><a href="Classes.aspx" class="text-white">Lớp tập</a></li>
                            <li><a href="Contact.aspx" class="text-white">Liên hệ</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4 mb-4">
                        <h5>Kết nối với chúng tôi</h5>
                        <div class="d-flex gap-3 mb-3">
                            <a href="#" class="text-white fs-5"><i class="fab fa-facebook"></i></a>
                            <a href="#" class="text-white fs-5"><i class="fab fa-instagram"></i></a>
                            <a href="#" class="text-white fs-5"><i class="fab fa-youtube"></i></a>
                            <a href="#" class="text-white fs-5"><i class="fab fa-tiktok"></i></a>
                        </div>
                        <p class="mb-0">© 2025 GymSystem Online. All Rights Reserved.</p>
                    </div>
                </div>
            </div>
        </footer>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html> 