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


-- Chèn dữ liệu vào USERS
INSERT INTO USERS (Username, Password, Email, FullName, PhoneNumber, Address, UserType, DateOfBirth, Gender, IsActive)
VALUES ('provider1', 'hashed_password', 'provider1@example.com', N'Công ty Gym ABC', '0936212369', N'Nguyễn Văn Linh, Đà Nẵng', 'Provider', NULL, NULL, 1);

-- Chèn dữ liệu vào GYM_PROVIDERS
INSERT INTO GYM_PROVIDERS (UserID, CompanyName, ContactName, ContactPhone, ContactEmail, Description, Logo, VerificationStatus, IsActive)
VALUES (1, 'Gym ABC', N'Nguyễn Văn A', '0936212369', 'contact@gymabc.com', N'Phòng gym chất lượng cao', 'images/power_fitness_logo.jpg', 1, 1);

-- Chèn dữ liệu vào GYM_BRANCHES
INSERT INTO GYM_BRANCHES (ProviderID, BranchName, Address, City, District, PhoneNumber, Email, OpeningHours, Description, MapLocation, Latitude, Longitude, RatingAverage, ReviewCount, Featured, IsActive)
VALUES (1, N'Gym ABC Đà Nẵng', N'123 Nguyễn Văn Linh, Đà Nẵng', N'Đà Nẵng', N'Hải Châu', '0936212369', 'danang@gymabc.com', '6:00 - 22:00', N'Phòng gym hiện đại tại Đà Nẵng', 'https://maps.google.com', 16.047079, 108.206230, 4.5, 10, 1, 1);

-- Chèn dữ liệu vào FACILITIES
INSERT INTO FACILITIES (BranchID, FacilityName, Description, IconClass, IsActive)
VALUES (1, N'Máy chạy bộ', N'Máy chạy bộ hiện đại', 'fas fa-running', 1),
       (1, N'Phòng yoga', N'Phòng yoga rộng rãi', 'fas fa-spa', 1);

-- Chèn dữ liệu vào BRANCH_IMAGES
INSERT INTO BRANCH_IMAGES (BranchID, ImageURL, Caption, IsMainImage, DisplayOrder, IsActive)
VALUES (1, 'images/images_gym1.jpg', N'Phòng tập chính', 1, 1, 1),
       (1, 'images/images_gym2.jpg', N'Khu vực máy tập', 0, 2, 1);

-- Chèn dữ liệu vào MEMBERSHIP_PACKAGES
INSERT INTO MEMBERSHIP_PACKAGES (BranchID, PackageName, Duration, DurationType, Price, DiscountedPrice, Description, Features, IsPopular, IsActive)
VALUES (1, N'Gói cơ bản', 1, 'Month', 500000, 450000, N'Gói tập cơ bản 1 tháng', N'Tập luyện không giới hạn, Hỗ trợ cơ bản', 1, 1);

-- Chèn dữ liệu vào REVIEWS
INSERT INTO REVIEWS (UserID, BranchID, Rating, Comment, ReviewDate, IsApproved, IsActive)
VALUES (1, 1, 5, N'Phòng gym rất sạch sẽ và hiện đại!', GETDATE(), 1, 1);

-- Xóa dữ liệu cũ (nếu cần)
DELETE FROM REVIEWS;
DELETE FROM MEMBERSHIP_PACKAGES;
DELETE FROM BRANCH_IMAGES;
DELETE FROM FACILITIES;
DELETE FROM GYM_BRANCHES;
DELETE FROM GYM_PROVIDERS;
DELETE FROM USERS;
GO



USE master;
GO

ALTER DATABASE GymBookingSystem
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE GymBookingSystem;
GO