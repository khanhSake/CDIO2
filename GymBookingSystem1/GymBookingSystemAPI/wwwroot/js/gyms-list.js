// Gọi API để lấy danh sách phòng gym
async function fetchGymsList() {
    try {
        const response = await fetch('http://localhost:5197/api/GymBranches');
        if (!response.ok) {
            throw new Error(`Không thể lấy danh sách phòng gym: ${response.status} ${response.statusText}`);
        }
        const data = await response.json();

        const gymsContainer = document.getElementById('gyms-container');
        data.forEach(gym => {
            const gymElement = document.createElement('div');
            gymElement.className = 'col-md-4 mb-4';
            gymElement.innerHTML = `
                <div class="card gym-card h-100 shadow-sm">
                    <div class="gym-card-image">
                        <img src="${gym.branchImages.find(img => img.isMainImage)?.imageURL || 'images/placeholder.jpg'}" class="card-img-top" alt="${gym.branchName}">
                    </div>
                    <div class="card-body gym-card-content">
                        <h3 class="card-title fw-semibold">${gym.branchName}</h3>
                        <p class="card-text">${gym.address}, ${gym.district}, ${gym.city}</p>
                        <p class="card-text"><i class="fas fa-star text-warning me-1"></i> ${gym.ratingAverage.toFixed(1)} (${gym.reviewCount} đánh giá)</p>
                        <a href="gym-detail.html?id=${gym.branchID}" class="gym-card-link fw-medium">Xem chi tiết <i class="fas fa-chevron-right ms-1"></i></a>
                    </div>
                </div>
            `;
            gymsContainer.appendChild(gymElement);
        });
    } catch (error) {
        console.error('Lỗi:', error.message);
        alert(`Có lỗi xảy ra khi tải danh sách phòng gym: ${error.message}`);
    }
}

// Gọi hàm lấy danh sách khi trang được tải
document.addEventListener('DOMContentLoaded', fetchGymsList);

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