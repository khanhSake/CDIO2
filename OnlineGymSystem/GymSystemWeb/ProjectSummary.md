# Online Gym Management System - Tổng quan dự án

## 1. Cấu trúc dự án

Dự án Online Gym Management System được xây dựng với cấu trúc như sau:

```
GymSystemWeb/
│
├── Models/               # Các lớp Entity và ViewModel
│   ├── User.cs             # Người dùng hệ thống
│   ├── GymBranch.cs        # Chi nhánh phòng tập
│   ├── MembershipPlan.cs   # Gói tập
│   ├── Facility.cs         # Tiện ích của phòng tập
│   ├── BranchImage.cs      # Hình ảnh phòng tập
│   ├── PlanBenefit.cs      # Quyền lợi gói tập
│   ├── Trainer.cs          # Huấn luyện viên
│   └── ViewModels.cs       # Các lớp ViewModel
│
├── Views/                # Các file giao diện (.aspx)
│   ├── Default.aspx        # Trang chủ
│   ├── Default.aspx.cs     # Code-behind trang chủ
│   └── (các trang khác)
│
├── Controllers/          # Các lớp xử lý logic
│   └── HomeController.cs   # Xử lý trang chủ và chi nhánh
│
├── Services/             # Các dịch vụ truy cập dữ liệu
│   └── DatabaseService.cs  # Dịch vụ truy cập cơ sở dữ liệu
│
├── Utils/                # Các lớp tiện ích
│
├── Content/              # Tài nguyên tĩnh
│   ├── images/            # Hình ảnh
│   └── styles.css         # CSS styles
│
└── Web.config            # Cấu hình ứng dụng
```

## 2. Cơ sở dữ liệu

Cơ sở dữ liệu SQL Server bao gồm các bảng:

- **Users**: Thông tin người dùng (admin, member, trainer)
- **GymBranches**: Danh sách các chi nhánh phòng tập
- **Facilities**: Tiện ích của từng chi nhánh
- **BranchImages**: Hình ảnh của từng chi nhánh
- **MembershipPlans**: Các gói tập
- **PlanBenefits**: Quyền lợi của từng gói tập
- **Subscriptions**: Đăng ký gói tập của thành viên
- **Trainers**: Thông tin huấn luyện viên
- **Classes**: Các lớp tập tại phòng gym
- **ClassSchedule**: Lịch học các lớp
- **ClassBookings**: Đặt lịch lớp học
- **PersonalTrainingSessions**: Buổi tập cá nhân với HLV
- **Reviews**: Đánh giá của thành viên về phòng tập

Script tạo CSDL nằm trong file `Database/GymSystemDB.sql`.

## 3. Chức năng chính

### 3.1. Quản lý phòng tập
- Thêm, sửa, xóa thông tin chi nhánh
- Quản lý tiện ích, hình ảnh của chi nhánh
- Quản lý lớp học tại từng chi nhánh

### 3.2. Quản lý người dùng
- Đăng ký, đăng nhập thành viên
- Phân quyền: Admin, Member, Trainer
- Quản lý thông tin cá nhân

### 3.3. Quản lý gói tập
- Tạo, sửa, xóa gói tập
- Quản lý quyền lợi gói tập
- Đăng ký gói tập cho thành viên

### 3.4. Quản lý lớp tập
- Tạo lịch lớp tập
- Đặt lịch tham gia lớp tập
- Quản lý buổi tập cá nhân với HLV

### 3.5. Tìm kiếm và đánh giá
- Tìm kiếm phòng tập theo vị trí
- Xem chi tiết thông tin phòng tập
- Đánh giá và nhận xét về phòng tập

## 4. Giao diện

Giao diện người dùng được thiết kế với Bootstrap 5 và FontAwesome, tương thích với nhiều thiết bị:

- Trang chủ hiển thị phòng tập nổi bật, gói tập và tính năng
- Trang danh sách phòng tập cho phép tìm kiếm và lọc
- Trang chi tiết phòng tập hiển thị thông tin, hình ảnh, tiện ích
- Trang đăng ký/đăng nhập
- Trang quản lý tài khoản cá nhân
- Trang đặt lịch

## 5. Triển khai

### Yêu cầu hệ thống
- ASP.NET Framework 4.8
- SQL Server 2019 trở lên
- Visual Studio 2019 trở lên

### Hướng dẫn triển khai
1. Chạy script SQL trong thư mục Database để tạo CSDL
2. Mở solution trong Visual Studio
3. Cập nhật connection string trong Web.config
4. Build và chạy ứng dụng

## 6. Tương lai phát triển

Dự án có thể phát triển thêm các tính năng:
- Tích hợp thanh toán trực tuyến
- Ứng dụng di động đi kèm
- Tính năng đặt lịch trực tuyến nâng cao
- Báo cáo và thống kê chi tiết
- Tích hợp mạng xã hội 