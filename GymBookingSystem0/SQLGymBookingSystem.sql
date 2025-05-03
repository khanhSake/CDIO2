-- Create database
CREATE DATABASE GymBookingSystem;
GO

USE GymBookingSystem;
GO

-- Create USERS table
CREATE TABLE USERS (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(128) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    UserType NVARCHAR(20) NOT NULL,
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    ProfileImage NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Create GYM_PROVIDERS table
CREATE TABLE GYM_PROVIDERS (
    ProviderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    CompanyName NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100) NOT NULL,
    ContactPhone NVARCHAR(20) NOT NULL,
    ContactEmail NVARCHAR(100) NOT NULL,
    Description NTEXT,
    Logo NVARCHAR(255),
    VerificationStatus BIT DEFAULT 0,
    RatingAverage DECIMAL(3,2) DEFAULT 0,
    ReviewCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create GYM_BRANCHES table
CREATE TABLE GYM_BRANCHES (
    BranchID INT PRIMARY KEY IDENTITY(1,1),
    ProviderID INT FOREIGN KEY REFERENCES GYM_PROVIDERS(ProviderID),
    BranchName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    District NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100),
    OpeningHours NVARCHAR(100),
    Description NTEXT,
    MapLocation NVARCHAR(255),
    Latitude DECIMAL(10,8),
    Longitude DECIMAL(11,8),
    RatingAverage DECIMAL(3,2) DEFAULT 0,
    ReviewCount INT DEFAULT 0,
    Featured BIT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create FACILITIES table
CREATE TABLE FACILITIES (
    FacilityID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    FacilityName NVARCHAR(100) NOT NULL,
    Description NTEXT,
    IconClass NVARCHAR(50),
    IsActive BIT DEFAULT 1
);
GO

-- Create BRANCH_IMAGES table
CREATE TABLE BRANCH_IMAGES (
    ImageID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    ImageURL NVARCHAR(255) NOT NULL,
    Caption NVARCHAR(255),
    IsMainImage BIT DEFAULT 0,
    DisplayOrder INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create MEMBERSHIP_PACKAGES table
CREATE TABLE MEMBERSHIP_PACKAGES (
    PackageID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    PackageName NVARCHAR(100) NOT NULL,
    Duration INT NOT NULL,
    DurationType NVARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    DiscountedPrice DECIMAL(10,2),
    Description NTEXT,
    Features NTEXT,
    IsPopular BIT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create TRAINERS table
CREATE TABLE TRAINERS (
    TrainerID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    FullName NVARCHAR(100) NOT NULL,
    ProfileImage NVARCHAR(255),
    Specialization NVARCHAR(100),
    Experience INT,
    Bio NTEXT,
    Certifications NTEXT,
    HourlyRate DECIMAL(10,2),
    RatingAverage DECIMAL(3,2) DEFAULT 0,
    ReviewCount INT DEFAULT 0,
    IsAvailable BIT DEFAULT 1,
    IsActive BIT DEFAULT 1
);
GO

-- Create TRAINER_IMAGES table
CREATE TABLE TRAINER_IMAGES (
    ImageID INT PRIMARY KEY IDENTITY(1,1),
    TrainerID INT FOREIGN KEY REFERENCES TRAINERS(TrainerID),
    ImageURL NVARCHAR(255) NOT NULL,
    Caption NVARCHAR(255),
    DisplayOrder INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create CLASSES table
CREATE TABLE CLASSES (
    ClassID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    ClassName NVARCHAR(100) NOT NULL,
    Description NTEXT,
    ClassType NVARCHAR(50),
    TrainerID INT FOREIGN KEY REFERENCES TRAINERS(TrainerID),
    MaxCapacity INT NOT NULL,
    DurationMinutes INT NOT NULL,
    DifficultyLevel NVARCHAR(20),
    ClassImage NVARCHAR(255),
    IsActive BIT DEFAULT 1
);
GO

-- Create CLASS_SCHEDULE table
CREATE TABLE CLASS_SCHEDULE (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    ClassID INT FOREIGN KEY REFERENCES CLASSES(ClassID),
    DayOfWeek INT NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    AvailableSpots INT NOT NULL,
    IsActive BIT DEFAULT 1
);
GO

-- Create BOOKINGS table
CREATE TABLE BOOKINGS (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    BookingNumber NVARCHAR(20) UNIQUE,
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    PackageID INT FOREIGN KEY REFERENCES MEMBERSHIP_PACKAGES(PackageID),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    BookingDate DATETIME NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    OriginalPrice DECIMAL(10,2) NOT NULL,
    DiscountAmount DECIMAL(10,2) DEFAULT 0,
    TotalAmount DECIMAL(10,2) NOT NULL,
    BookingStatus NVARCHAR(20) NOT NULL,
    PaymentStatus NVARCHAR(20) NOT NULL,
    CancellationReason NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Create CLASS_BOOKINGS table
CREATE TABLE CLASS_BOOKINGS (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    ScheduleID INT FOREIGN KEY REFERENCES CLASS_SCHEDULE(ScheduleID),
    BookingDate DATETIME NOT NULL,
    ClassDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Create PT_SESSIONS table
CREATE TABLE PT_SESSIONS (
    SessionID INT PRIMARY KEY IDENTITY(1,1),
    BookingNumber NVARCHAR(20) UNIQUE,
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    TrainerID INT FOREIGN KEY REFERENCES TRAINERS(TrainerID),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID),
    SessionDate DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    DiscountAmount DECIMAL(10,2) DEFAULT 0,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    PaymentStatus NVARCHAR(20) NOT NULL,
    Notes NTEXT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Create REVIEWS table
CREATE TABLE REVIEWS (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT FOREIGN KEY REFERENCES BOOKINGS(BookingID) NULL,
    PTSessionID INT FOREIGN KEY REFERENCES PT_SESSIONS(SessionID) NULL,
    ClassBookingID INT FOREIGN KEY REFERENCES CLASS_BOOKINGS(BookingID) NULL,
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID) NULL,
    TrainerID INT FOREIGN KEY REFERENCES TRAINERS(TrainerID) NULL,
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment NTEXT,
    ReviewDate DATETIME DEFAULT GETDATE(),
    IsApproved BIT DEFAULT 0,
    IsActive BIT DEFAULT 1
);
GO

-- Create PAYMENTS table
CREATE TABLE PAYMENTS (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    BookingID INT FOREIGN KEY REFERENCES BOOKINGS(BookingID) NULL,
    PTSessionID INT FOREIGN KEY REFERENCES PT_SESSIONS(SessionID) NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    TransactionID NVARCHAR(100),
    Notes NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Create PROMOTIONS table
CREATE TABLE PROMOTIONS (
    PromotionID INT PRIMARY KEY IDENTITY(1,1),
    ProviderID INT FOREIGN KEY REFERENCES GYM_PROVIDERS(ProviderID) NULL,
    BranchID INT FOREIGN KEY REFERENCES GYM_BRANCHES(BranchID) NULL,
    Code NVARCHAR(20) UNIQUE,
    Title NVARCHAR(100) NOT NULL,
    Description NTEXT,
    DiscountType NVARCHAR(20) NOT NULL,
    DiscountValue DECIMAL(10,2) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TermsAndConditions NTEXT,
    IsActive BIT DEFAULT 1
);
GO

-- Optional: Create indexes for better performance
CREATE INDEX IX_USERS_UserType ON USERS(UserType);
CREATE INDEX IX_GYM_BRANCHES_City ON GYM_BRANCHES(City);
CREATE INDEX IX_GYM_BRANCHES_Featured ON GYM_BRANCHES(Featured);
CREATE INDEX IX_MEMBERSHIP_PACKAGES_IsPopular ON MEMBERSHIP_PACKAGES(IsPopular);
CREATE INDEX IX_BOOKINGS_BookingStatus ON BOOKINGS(BookingStatus);
CREATE INDEX IX_BOOKINGS_PaymentStatus ON BOOKINGS(PaymentStatus);
CREATE INDEX IX_PROMOTIONS_Code ON PROMOTIONS(Code);
GO


-- Chèn dữ liệu vào USERS (18 nhà cung cấp)
INSERT INTO USERS (Username, Password, Email, FullName, PhoneNumber, Address, UserType, DateOfBirth, Gender, IsActive)
VALUES 
('provider1', 'hashed_password', 'provider1@example.com', N'Công ty Gym ABC', '0936212369', N'Nguyễn Văn Linh, Đà Nẵng', 'Provider', NULL, NULL, 1),
('provider2', 'hashed_password', 'provider2@example.com', N'Công ty Gym DEF', '0936212370', N'123 Lê Lợi, Hà Nội', 'Provider', NULL, NULL, 1),
('provider3', 'hashed_password', 'provider3@example.com', N'Công ty Gym GHI', '0936212371', N'456 Nguyễn Huệ, TP.HCM', 'Provider', NULL, NULL, 1),
('provider4', 'hashed_password', 'provider4@example.com', N'Công ty Gym JKL', '0936212372', N'789 Trần Phú, Huế', 'Provider', NULL, NULL, 1),
('provider5', 'hashed_password', 'provider5@example.com', N'Công ty Gym MNO', '0936212373', N'101 Nguyễn Trãi, Cần Thơ', 'Provider', NULL, NULL, 1),
('provider6', 'hashed_password', 'provider6@example.com', N'Công ty Gym PQR', '0936212374', N'202 Phạm Văn Đồng, Nha Trang', 'Provider', NULL, NULL, 1),
('provider7', 'hashed_password', 'provider7@example.com', N'Công ty Gym STU', '0936212375', N'303 Lê Đại Hành, Đà Lạt', 'Provider', NULL, NULL, 1),
('provider8', 'hashed_password', 'provider8@example.com', N'Công ty Gym VWX', '0936212376', N'404 Nguyễn Thị Minh Khai, Vũng Tàu', 'Provider', NULL, NULL, 1),
('provider9', 'hashed_password', 'provider9@example.com', N'Công ty Gym YZA', '0936212377', N'505 Lý Thường Kiệt, Hải Phòng', 'Provider', NULL, NULL, 1),
('provider10', 'hashed_password', 'provider10@example.com', N'Công ty Gym BCD', '0936212378', N'606 Điện Biên Phủ, Vinh', 'Provider', NULL, NULL, 1),
('provider11', 'hashed_password', 'provider11@example.com', N'Công ty Gym EFG', '0936212379', N'707 Nguyễn Văn Cừ, Quy Nhơn', 'Provider', NULL, NULL, 1),
('provider12', 'hashed_password', 'provider12@example.com', N'Công ty Gym HIJ', '0936212380', N'808 Trần Hưng Đạo, Buôn Ma Thuột', 'Provider', NULL, NULL, 1),
('provider13', 'hashed_password', 'provider13@example.com', N'Công ty Gym KLM', '0936212381', N'909 Lê Hồng Phong, Pleiku', 'Provider', NULL, NULL, 1),
('provider14', 'hashed_password', 'provider14@example.com', N'Công ty Gym NOP', '0936212382', N'1010 Phạm Ngũ Lão, Rạch Giá', 'Provider', NULL, NULL, 1),
('provider15', 'hashed_password', 'provider15@example.com', N'Công ty Gym QRS', '0936212383', N'1111 Nguyễn Trung Trực, Long Xuyên', 'Provider', NULL, NULL, 1),
('provider16', 'hashed_password', 'provider16@example.com', N'Công ty Gym TUV', '0936212384', N'1212 Hùng Vương, Mỹ Tho', 'Provider', NULL, NULL, 1),
('provider17', 'hashed_password', 'provider17@example.com', N'Công ty Gym WXY', '0936212385', N'1313 Ba Tháng Hai, Bạc Liêu', 'Provider', NULL, NULL, 1),
('provider18', 'hashed_password', 'provider18@example.com', N'Công ty Gym ZAB', '0936212386', N'1414 Lý Tự Trọng, Cà Mau', 'Provider', NULL, NULL, 1);

-- Chèn dữ liệu vào GYM_PROVIDERS (18 nhà cung cấp)
INSERT INTO GYM_PROVIDERS (UserID, CompanyName, ContactName, ContactPhone, ContactEmail, Description, Logo, VerificationStatus, IsActive)
VALUES 
(1, 'Gym ABC', N'Nguyễn Văn A', '0936212369', 'contact@gymabc.com', N'Phòng gym chất lượng cao', 'images/power_fitness_logo.jpg', 1, 1),
(2, 'Gym DEF', N'Trần Thị B', '0936212370', 'contact@gymdef.com', N'Phòng gym hiện đại', 'images/gym_def_logo.jpg', 1, 1),
(3, 'Gym GHI', N'Lê Văn C', '0936212371', 'contact@gymghi.com', N'Phòng gym chuyên nghiệp', 'images/gym_ghi_logo.jpg', 1, 1),
(4, 'Gym JKL', N'Phạm Thị D', '0936212372', 'contact@gymjkl.com', N'Phòng gym đẳng cấp', 'images/gym_jkl_logo.jpg', 1, 1),
(5, 'Gym MNO', N'Hoàng Văn E', '0936212373', 'contact@gymmno.com', N'Phòng gym tiện nghi', 'images/gym_mno_logo.jpg', 1, 1),
(6, 'Gym PQR', N'Nguyễn Thị F', '0936212374', 'contact@gympqr.com', N'Phòng gym thân thiện', 'images/gym_pqr_logo.jpg', 1, 1),
(7, 'Gym STU', N'Trần Văn G', '0936212375', 'contact@gymstu.com', N'Phòng gym cao cấp', 'images/gym_stu_logo.jpg', 1, 1),
(8, 'Gym VWX', N'Lê Thị H', '0936212376', 'contact@gymvwx.com', N'Phòng gym hiện đại', 'images/gym_vwx_logo.jpg', 1, 1),
(9, 'Gym YZA', N'Phạm Văn I', '0936212377', 'contact@gymyza.com', N'Phòng gym chuyên nghiệp', 'images/gym_yza_logo.jpg', 1, 1),
(10, 'Gym BCD', N'Hoàng Thị J', '0936212378', 'contact@gymbcd.com', N'Phòng gym chất lượng', 'images/gym_bcd_logo.jpg', 1, 1),
(11, 'Gym EFG', N'Nguyễn Văn K', '0936212379', 'contact@gymefg.com', N'Phòng gym tiện nghi', 'images/gym_efg_logo.jpg', 1, 1),
(12, 'Gym HIJ', N'Trần Thị L', '0936212380', 'contact@gymhij.com', N'Phòng gym thân thiện', 'images/gym_hij_logo.jpg', 1, 1),
(13, 'Gym KLM', N'Lê Văn M', '0936212381', 'contact@gymklm.com', N'Phòng gym cao cấp', 'images/gym_klm_logo.jpg', 1, 1),
(14, 'Gym NOP', N'Phạm Thị N', '0936212382', 'contact@gymnop.com', N'Phòng gym hiện đại', 'images/gym_nop_logo.jpg', 1, 1),
(15, 'Gym QRS', N'Hoàng Văn O', '0936212383', 'contact@gymqrs.com', N'Phòng gym chuyên nghiệp', 'images/gym_qrs_logo.jpg', 1, 1),
(16, 'Gym TUV', N'Nguyễn Thị P', '0936212384', 'contact@gymtuv.com', N'Phòng gym chất lượng', 'images/gym_tuv_logo.jpg', 1, 1),
(17, 'Gym WXY', N'Trần Văn Q', '0936212385', 'contact@gymwxy.com', N'Phòng gym tiện nghi', 'images/gym_wxy_logo.jpg', 1, 1),
(18, 'Gym ZAB', N'Lê Thị R', '0936212386', 'contact@gymzab.com', N'Phòng gym thân thiện', 'images/gym_zab_logo.jpg', 1, 1);

-- Chèn dữ liệu vào GYM_BRANCHES (18 chi nhánh)
INSERT INTO GYM_BRANCHES (ProviderID, BranchName, Address, City, District, PhoneNumber, Email, OpeningHours, Description, MapLocation, Latitude, Longitude, RatingAverage, ReviewCount, Featured, IsActive)
VALUES 
(1, N'Gym ABC Đà Nẵng', N'123 Nguyễn Văn Linh', N'Đà Nẵng', N'Hải Châu', '0936212369', 'danang@gymabc.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Đà Nẵng', 'https://maps.google.com', 16.047079, 108.206230, 4.5, 10, 1, 1),
(2, N'Gym DEF Hà Nội', N'123 Lê Lợi', N'Hà Nội', N'Hoàn Kiếm', '0936212370', 'hanoi@gymdef.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Hà Nội', 'https://maps.google.com', 21.028511, 105.834160, 4.7, 15, 1, 1),
(3, N'Gym GHI TP.HCM', N'456 Nguyễn Huệ', N'TP.HCM', N'Quận 1', '0936212371', 'hcm@gymghi.com', '6:00 - 22:00', N'Phòng gym hiện đại tại TP.HCM', 'https://maps.google.com', 10.776390, 106.695140, 4.8, 20, 1, 1),
(4, N'Gym JKL Huế', N'789 Trần Phú', N'Huế', N'Phú Nhuận', '0936212372', 'hue@gymjkl.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Huế', 'https://maps.google.com', 16.466430, 107.590870, 4.4, 8, 1, 1),
(5, N'Gym MNO Cần Thơ', N'101 Nguyễn Trãi', N'Cần Thơ', N'Ninh Kiều', '0936212373', 'cantho@gymmno.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Cần Thơ', 'https://maps.google.com', 10.031160, 105.771820, 4.6, 12, 1, 1),
(6, N'Gym PQR Nha Trang', N'202 Phạm Văn Đồng', N'Nha Trang', N'Vĩnh Nghi', '0936212374', 'nhatrang@gympqr.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Nha Trang', 'https://maps.google.com', 12.238791, 109.196748, 4.5, 10, 1, 1),
(7, N'Gym STU Đà Lạt', N'303 Lê Đại Hành', N'Đà Lạt', N'Phường 1', '0936212375', 'dalat@gymstu.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Đà Lạt', 'https://maps.google.com', 11.940419, 108.458313, 4.3, 7, 1, 1),
(8, N'Gym VWX Vũng Tàu', N'404 Nguyễn Thị Minh Khai', N'Vũng Tàu', N'Phường 5', '0936212376', 'vungtau@gymvwx.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Vũng Tàu', 'https://maps.google.com', 10.355672, 107.084206, 4.6, 11, 1, 1),
(9, N'Gym YZA Hải Phòng', N'505 Lý Thường Kiệt', N'Hải Phòng', N'Hồng Bàng', '0936212377', 'haiphong@gymyza.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Hải Phòng', 'https://maps.google.com', 20.856143, 106.682217, 4.5, 9, 1, 1),
(10, N'Gym BCD Vinh', N'606 Điện Biên Phủ', N'Vinh', N'Trường Thi', '0936212378', 'vinh@gymbcd.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Vinh', 'https://maps.google.com', 18.676250, 105.691940, 4.4, 8, 1, 1),
(11, N'Gym EFG Quy Nhơn', N'707 Nguyễn Văn Cừ', N'Quy Nhơn', N'Ngô Mây', '0936212379', 'quynhon@gymefg.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Quy Nhơn', 'https://maps.google.com', 13.782967, 109.219663, 4.5, 10, 1, 1),
(12, N'Gym HIJ Buôn Ma Thuột', N'808 Trần Hưng Đạo', N'Buôn Ma Thuột', N'Tân Lợi', '0936212380', 'bmt@gymhij.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Buôn Ma Thuột', 'https://maps.google.com', 12.681516, 108.038248, 4.3, 7, 1, 1),
(13, N'Gym KLM Pleiku', N'909 Lê Hồng Phong', N'Pleiku', N'Thống Nhất', '0936212381', 'pleiku@gymklm.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Pleiku', 'https://maps.google.com', 13.983540, 108.002140, 4.4, 8, 1, 1),
(14, N'Gym NOP Rạch Giá', N'1010 Phạm Ngũ Lão', N'Rạch Giá', N'Vĩnh Thanh', '0936212382', 'rachgia@gymnop.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Rạch Giá', 'https://maps.google.com', 10.010480, 105.080910, 4.5, 9, 1, 1),
(15, N'Gym QRS Long Xuyên', N'1111 Nguyễn Trung Trực', N'Long Xuyên', N'Mỹ Long', '0936212383', 'longxuyen@gymqrs.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Long Xuyên', 'https://maps.google.com', 10.386350, 105.435180, 4.6, 11, 1, 1),
(16, N'Gym TUV Mỹ Tho', N'1212 Hùng Vương', N'Mỹ Tho', N'Phường 7', '0936212384', 'mytho@gymtuv.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Mỹ Tho', 'https://maps.google.com', 10.360050, 106.363570, 4.4, 8, 1, 1),
(17, N'Gym WXY Bạc Liêu', N'1313 Ba Tháng Hai', N'Bạc Liêu', N'Phường 3', '0936212385', 'baclieu@gymwxy.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Bạc Liêu', 'https://maps.google.com', 9.294010, 105.721960, 4.5, 10, 1, 1),
(18, N'Gym ZAB Cà Mau', N'1414 Lý Tự Trọng', N'Cà Mau', N'Phường 5', '0936212386', 'camau@gymzab.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Cà Mau', 'https://maps.google.com', 9.176820, 105.150270, 4.3, 7, 1, 1);

-- Chèn dữ liệu vào FACILITIES (2 tiện ích cho mỗi chi nhánh)
INSERT INTO FACILITIES (BranchID, FacilityName, Description, IconClass, IsActive)
VALUES 
(1, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1), (1, N'Phòng yoga', N'Phòng yoga rộng rãi', 'fas fa-spa', 1),
(2, N'Tạ tay', N'Tạ tay đa dạng trọng lượng', 'fas fa-dumbbell', 1), (2, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(3, N'Máy chạy bộ', N'Máy chạy bộ cao cấp', 'fas fa-running', 1), (3, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1),
(4, N'Tạ tay', N'Tạ tay chất lượng', 'fas fa-dumbbell', 1), (4, N'Phòng yoga', N'Phòng yoga thoáng đãng', 'fas fa-spa', 1),
(5, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1), (5, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(6, N'Tạ tay', N'Tạ tay đa dạng', 'fas fa-dumbbell', 1), (6, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1),
(7, N'Máy chạy bộ', N'Máy chạy bộ cao cấp', 'fas fa-running', 1), (7, N'Phòng yoga', N'Phòng yoga yên tĩnh', 'fas fa-spa', 1),
(8, N'Tạ tay', N'Tạ tay chất lượng', 'fas fa-dumbbell', 1), (8, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(9, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1), (9, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1),
(10, N'Tạ tay', N'Tạ tay đa dạng', 'fas fa-dumbbell', 1), (10, N'Phòng yoga', N'Phòng yoga thoáng đãng', 'fas fa-spa', 1),
(11, N'Máy chạy bộ', N'Máy chạy bộ cao cấp', 'fas fa-running', 1), (11, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(12, N'Tạ tay', N'Tạ tay chất lượng', 'fas fa-dumbbell', 1), (12, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1),
(13, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1), (13, N'Phòng yoga', N'Phòng yoga yên tĩnh', 'fas fa-spa', 1),
(14, N'Tạ tay', N'Tạ tay đa dạng', 'fas fa-dumbbell', 1), (14, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(15, N'Máy chạy bộ', N'Máy chạy bộ cao cấp', 'fas fa-running', 1), (15, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1),
(16, N'Tạ tay', N'Tạ tay chất lượng', 'fas fa-dumbbell', 1), (16, N'Phòng yoga', N'Phòng yoga thoáng đãng', 'fas fa-spa', 1),
(17, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1), (17, N'Phòng boxing', N'Phòng boxing chuyên nghiệp', 'fas fa-fist-raised', 1),
(18, N'Tạ tay', N'Tạ tay đa dạng', 'fas fa-dumbbell', 1), (18, N'Phòng xông hơi', N'Phòng xông hơi thư giãn', 'fas fa-hot-tub', 1);

-- Chèn dữ liệu vào BRANCH_IMAGES (2 hình ảnh cho mỗi chi nhánh)
INSERT INTO BRANCH_IMAGES (BranchID, ImageURL, Caption, IsMainImage, DisplayOrder, IsActive)
VALUES 
(1, 'images/images_gym1.jpg', N'Phòng tập chính', 1, 1, 1), (1, 'images/images_gym1.jpg', N'Khu vực máy tập', 0, 2, 1),
(2, 'images/images_gym2.jpg', N'Phòng tập chính', 1, 1, 1), (2, 'images/images_gym2.jpg', N'Khu vực máy tập', 0, 2, 1),
(3, 'images/images_gym3.jpg', N'Phòng tập chính', 1, 1, 1), (3, 'images/images_gym3.jpg', N'Khu vực máy tập', 0, 2, 1),
(4, 'images/images_gym4.jpg', N'Phòng tập chính', 1, 1, 1), (4, 'images/images_gym4.jpg', N'Khu vực máy tập', 0, 2, 1),
(5, 'images/images_gym5.jpg', N'Phòng tập chính', 1, 1, 1), (5, 'images/images_gym5.jpg', N'Khu vực máy tập', 0, 2, 1),
(6, 'images/images_gym6.jpg', N'Phòng tập chính', 1, 1, 1), (6, 'images/images_gym6.jpg', N'Khu vực máy tập', 0, 2, 1),
(7, 'images/images_gym7.jpg', N'Phòng tập chính', 1, 1, 1), (7, 'images/images_gym7.jpg', N'Khu vực máy tập', 0, 2, 1),
(8, 'images/images_gym8.jpg', N'Phòng tập chính', 1, 1, 1), (8, 'images/images_gym8.jpg', N'Khu vực máy tập', 0, 2, 1),
(9, 'images/images_gym9.jpg', N'Phòng tập chính', 1, 1, 1), (9, 'images/images_gym9.jpg', N'Khu vực máy tập', 0, 2, 1),
(10, 'images/images_gym10.jpg', N'Phòng tập chính', 1, 1, 1), (10, 'images/images_gym10.jpg', N'Khu vực máy tập', 0, 2, 1),
(11, 'images/images_gym11.jpg', N'Phòng tập chính', 1, 1, 1), (11, 'images/images_gym11.jpg', N'Khu vực máy tập', 0, 2, 1),
(12, 'images/images_gym12.jpg', N'Phòng tập chính', 1, 1, 1), (12, 'images/images_gym12.jpg', N'Khu vực máy tập', 0, 2, 1),
(13, 'images/images_gym13.jpg', N'Phòng tập chính', 1, 1, 1), (13, 'images/images_gym13.jpg', N'Khu vực máy tập', 0, 2, 1),
(14, 'images/images_gym14.jpg', N'Phòng tập chính', 1, 1, 1), (14, 'images/images_gym14.jpg', N'Khu vực máy tập', 0, 2, 1),
(15, 'images/images_gym15.jpg', N'Phòng tập chính', 1, 1, 1), (15, 'images/images_gym15.jpg', N'Khu vực máy tập', 0, 2, 1),
(16, 'images/images_gym16.jpg', N'Phòng tập chính', 1, 1, 1), (16, 'images/images_gym16.jpg', N'Khu vực máy tập', 0, 2, 1),
(17, 'images/images_gym17.jpg', N'Phòng tập chính', 1, 1, 1), (17, 'images/images_gym17.jpg', N'Khu vực máy tập', 0, 2, 1),
(18, 'images/images_gym18.jpg', N'Phòng tập chính', 1, 1, 1), (18, 'images/images_gym18.jpg', N'Khu vực máy tập', 0, 2, 1);

-- Chèn dữ liệu vào MEMBERSHIP_PACKAGES (1 gói cho mỗi chi nhánh)
INSERT INTO MEMBERSHIP_PACKAGES (BranchID, PackageName, Duration, DurationType, Price, DiscountedPrice, Description, Features, IsPopular, IsActive)
VALUES 
(1, N'Gói cơ bản', 1, 'Month', 500000, 450000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(2, N'Gói cơ bản', 1, 'Month', 600000, 550000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(3, N'Gói cơ bản', 1, 'Month', 700000, 650000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(4, N'Gói cơ bản', 1, 'Month', 550000, 500000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(5, N'Gói cơ bản', 1, 'Month', 520000, 480000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(6, N'Gói cơ bản', 1, 'Month', 580000, 530000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(7, N'Gói cơ bản', 1, 'Month', 560000, 510000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(8, N'Gói cơ bản', 1, 'Month', 590000, 540000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(9, N'Gói cơ bản', 1, 'Month', 570000, 520000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(10, N'Gói cơ bản', 1, 'Month', 540000, 490000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(11, N'Gói cơ bản', 1, 'Month', 600000, 550000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(12, N'Gói cơ bản', 1, 'Month', 560000, 510000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(13, N'Gói cơ bản', 1, 'Month', 570000, 520000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(14, N'Gói cơ bản', 1, 'Month', 550000, 500000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(15, N'Gói cơ bản', 1, 'Month', 580000, 530000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(16, N'Gói cơ bản', 1, 'Month', 540000, 490000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(17, N'Gói cơ bản', 1, 'Month', 560000, 510000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1),
(18, N'Gói cơ bản', 1, 'Month', 570000, 520000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1);



USE master;
GO

ALTER DATABASE GymBookingSystem
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE GymBookingSystem;
GO
