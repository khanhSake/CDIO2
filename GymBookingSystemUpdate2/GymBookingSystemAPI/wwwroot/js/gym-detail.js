// Biến toàn cục để lưu trữ bản đồ
let map;
let mapLat = 16.047079; // Tọa độ mặc định
let mapLng = 108.206230;

// Hàm khởi tạo bản đồ Google Maps
window.initMap = function () {
    const mapOptions = {
        center: { lat: mapLat, lng: mapLng },
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map'), mapOptions);

    // Thêm marker tại vị trí phòng gym
    new google.maps.Marker({
        position: { lat: mapLat, lng: mapLng },
        map: map,
        title: document.getElementById('branch-name').textContent || 'Phòng gym'
    });
}

// Lấy BranchID từ URL
const urlParams = new URLSearchParams(window.location.search);
const branchId = urlParams.get('id');

// Gọi API để lấy chi tiết phòng gym
async function fetchGymDetail() {
    try {
        const response = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`);
        if (!response.ok) {
            throw new Error(`Không thể lấy dữ liệu phòng gym: ${response.status} ${response.statusText}`);
        }
        const data = await response.json();

        // Check if the branch is active
        if (!data.isActive) {
            document.querySelector('.gym-detail .container').innerHTML = `
                <div class="alert alert-warning text-center" role="alert">
                    Phòng gym này hiện đang không hoạt động. Vui lòng quay lại sau hoặc chọn phòng gym khác.
                    <br>
                    <a href="gyms-list.html" class="btn btn-primary mt-3">Quay lại danh sách phòng gym</a>
                </div>
            `;
            return;
        }

        // Hiển thị thông tin phòng gym
        document.getElementById('branch-name').textContent = data.branchName;
        document.getElementById('address').textContent = `${data.address}, ${data.district}, ${data.city}`;
        document.getElementById('phone').textContent = data.phoneNumber;
        document.getElementById('email').textContent = data.email || 'Không có';
        document.getElementById('opening-hours').textContent = data.openingHours;
        document.getElementById('rating').textContent = data.ratingAverage.toFixed(1);
        document.getElementById('review-count').textContent = data.reviewCount;
        document.getElementById('description').textContent = data.description;

        // Hiển thị hình ảnh chính
        const mainImage = data.branchImages.find(img => img.isMainImage);
        document.getElementById('main-image').src = mainImage ? mainImage.imageURL : 'images/placeholder.jpg';

        // Hiển thị thư viện hình ảnh
        const gallery = document.querySelector('.image-gallery');
        gallery.innerHTML = ''; // Clear gallery first
        data.branchImages.forEach(img => {
            const imgElement = document.createElement('img');
            imgElement.src = img.imageURL;
            imgElement.alt = img.caption || 'Hình ảnh phòng tập';
            imgElement.className = 'img-fluid rounded shadow-sm';
            imgElement.style.cursor = 'pointer';
            imgElement.onclick = () => document.getElementById('main-image').src = img.imageURL;
            gallery.appendChild(imgElement);
        });

        // Hiển thị tiện ích
        const facilitiesContainer = document.getElementById('facilities');
        facilitiesContainer.innerHTML = ''; // Clear facilities first
        data.facilities.forEach(facility => {
            const facilityElement = document.createElement('div');
            facilityElement.className = 'card facility-card p-3 shadow-sm text-center';
            facilityElement.style.width = '180px';
            facilityElement.innerHTML = `
                <i class="${facility.iconClass} fa-2x mb-3 text-primary"></i>
                <h5 class="fw-semibold">${facility.facilityName}</h5>
                <p class="text-muted">${facility.description}</p>
            `;
            facilitiesContainer.appendChild(facilityElement);
        });

        // Hiển thị gói thành viên
        const packagesContainer = document.getElementById('membership-packages');
        packagesContainer.innerHTML = ''; // Clear packages first
        data.membershipPackages.forEach(pkg => {
            const pkgElement = document.createElement('div');
            pkgElement.className = 'col-md-4 mb-4';
            pkgElement.innerHTML = `
                <div class="card package-card h-100 shadow-sm text-center">
                    <div class="card-body">
                        <h3 class="card-title fw-semibold mb-3">${pkg.packageName}</h3>
                        <p class="card-text text-muted mb-3">${pkg.description}</p>
                        <p class="card-text mb-2"><strong>Giá:</strong> ${pkg.discountedPrice ? pkg.discountedPrice.toLocaleString('vi-VN') : pkg.price.toLocaleString('vi-VN')} VND</p>
                        <p class="card-text mb-4"><strong>Thời hạn:</strong> ${pkg.duration} ${pkg.durationType}</p>
                        <a href="#" class="btn btn-outline-primary">Chọn gói</a>
                    </div>
                </div>
            `;
            packagesContainer.appendChild(pkgElement);
        });

        // Hiển thị đánh giá
        const reviewsContainer = document.getElementById('reviews');
        reviewsContainer.innerHTML = ''; // Clear reviews first
        if (data.reviews.length === 0) {
            reviewsContainer.innerHTML = '<p class="text-muted">Chưa có đánh giá nào.</p>';
        } else {
            data.reviews.forEach(review => {
                const reviewElement = document.createElement('div');
                reviewElement.className = 'card review-card p-3 shadow-sm';
                reviewElement.innerHTML = `
                    <div class="d-flex align-items-center mb-2">
                        <i class="fas fa-user-circle fa-2x me-2 text-primary"></i>
                        <div>
                            <h5 class="mb-0 fw-semibold">${review.userFullName}</h5>
                            <p class="mb-0 text-muted small">${new Date(review.reviewDate).toLocaleDateString('vi-VN')}</p>
                        </div>
                    </div>
                    <div class="d-flex align-items-center mb-2">
                        ${Array(review.rating).fill('<i class="fas fa-star text-warning me-1"></i>').join('')}
                        ${Array(5 - review.rating).fill('<i class="fas fa-star text-muted me-1"></i>').join('')}
                    </div>
                    <p class="text-muted">${review.comment}</p>
                `;
                reviewsContainer.appendChild(reviewElement);
            });
        }

        // Cập nhật liên kết bản đồ
        const mapLink = `https://www.google.com/maps?q=${data.latitude},${data.longitude}`;
        document.getElementById('map-location').href = mapLink;

        // Cập nhật tọa độ và khởi tạo bản đồ
        mapLat = Number(data.latitude);
        mapLng = Number(data.longitude);

        // Kiểm tra xem google đã được định nghĩa chưa
        if (typeof google !== 'undefined') {
            window.initMap();
        } else {
            console.error('Google Maps API chưa được tải. Đợi callback initMap tự động gọi.');
        }

    } catch (error) {
        console.error('Lỗi:', error.message);
        alert(`Có lỗi xảy ra khi tải thông tin phòng gym: ${error.message}`);
        // Nếu có lỗi, hiển thị bản đồ mặc định
        if (typeof google !== 'undefined') {
            window.initMap();
        }
    }
}

// Gọi hàm lấy chi tiết khi trang được tải
document.addEventListener('DOMContentLoaded', fetchGymDetail);

// Back to Top Button
const backToTopButton = document.getElementById('back-to-top');
window.addEventListener('scroll', () => {
    if (window.scrollY > 300) {
        backToTopButton.style.display = 'block';
    } else {
        backToTopButton.style.display = 'none';
    }
});

backToTopButton.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
});