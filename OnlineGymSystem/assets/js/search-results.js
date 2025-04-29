// JavaScript cho trang kết quả tìm kiếm
document.addEventListener('DOMContentLoaded', () => {
    const resultsListContainer = document.getElementById('results-list-container');
    const totalResultsCountSpan = document.getElementById('total-results-count');
    const resultsSummaryParagraph = document.querySelector('#results-summary p');
    const filterCountSpan = document.querySelector('.filter-count span'); // Optional: Update filter count too

    // --- SAMPLE DATA --- 
    // In a real application, you would fetch this data from an API
    const sampleData = {
        "results": [
            {
                "branchId": 1,
                "name": "California Fitness & Yoga",
                "address": "Quận 1, TP.HCM", // Example address
                "rating": 9.2,
                "reviewCount": 128,
                "distance": 2.3,
                "image": "assets/images/gym-1.jpg", // Use relative path
                "packages": [
                    {"name": "1 Tháng", "price": 499000, "discount": null},
                    {"name": "3 Tháng", "price": 1500000, "discount": 1350000}
                ],
                "facilities": ["Phòng xông hơi", "Wi-Fi miễn phí", "Hồ bơi", "PT cá nhân"],
                "classes": ["Yoga", "Zumba", "Boxing", "Gym 24h"],
                "latitude": 10.7769, // Example coordinates
                "longitude": 106.7009
            },
            {
                "branchId": 2,
                "name": "FitHub Gym & Fitness",
                "address": "Quận 7, TP.HCM",
                "rating": 8.8,
                "reviewCount": 96,
                "distance": 5.7,
                "image": "assets/images/gym-2.jpg",
                "packages": [
                    {"name": "1 Tháng", "price": 399000, "discount": 279000}
                ],
                "facilities": ["Bãi đậu xe", "Wi-Fi miễn phí", "Tủ khóa"],
                "classes": ["CrossFit", "HIIT", "Gym thường"],
                "latitude": 10.7298,
                "longitude": 106.7037
            },
            {
                "branchId": 3,
                "name": "Elite Fitness",
                "address": "Quận 2, TP.HCM",
                "rating": 9.6,
                "reviewCount": 215,
                "distance": 7.1,
                "image": "assets/images/gym-3.jpg",
                "packages": [
                    {"name": "1 Tháng", "price": 799000, "discount": null}
                ],
                "facilities": ["Phòng xông hơi", "Hồ bơi", "Wi-Fi miễn phí", "Bãi đậu xe"],
                "classes": ["Phòng tập cao cấp", "Yoga", "Pilates", "PT cá nhân"],
                "latitude": 10.7872,
                "longitude": 106.7374
            }
            // Add more results here based on the JSON structure
        ],
        "totalResults": 15 // Total results matching filters
    };
    // --- END SAMPLE DATA ---

    function formatPrice(price) {
        return price ? price.toLocaleString('vi-VN') + 'đ' : '';
    }

    function renderRating(score, reviewCount) {
        let ratingLabel = '';
        if (score >= 9.0) ratingLabel = 'Xuất sắc';
        else if (score >= 8.0) ratingLabel = 'Rất tốt';
        else if (score >= 7.0) ratingLabel = 'Tốt';
        else ratingLabel = 'Trung bình';

        return `
            <div class="rating">
                <span class="rating-score">${score.toFixed(1)}</span>
                <div class="rating-text">
                    <span class="rating-label">${ratingLabel}</span>
                    <span class="rating-count">${reviewCount} đánh giá</span>
                </div>
            </div>
        `;
    }

    function renderFacilities(facilities) {
        return facilities.map(facility => 
            `<span class="amenity"><i class="fas fa-check"></i> ${facility}</span>`
        ).join('');
    }

    function renderClasses(classes) {
        return classes.map(cls => `<span class="class-tag">${cls}</span>`).join('');
    }

    function renderPrice(packages) {
        if (!packages || packages.length === 0) {
            return '<span class="price">Liên hệ</span>';
        }
        // Display the first package's price (or implement logic for best deal)
        const firstPackage = packages[0];
        let priceHtml = '';
        if (firstPackage.discount && firstPackage.discount < firstPackage.price) {
            priceHtml += `<span class="price-was">${formatPrice(firstPackage.price)}</span>`;
            priceHtml += `<span class="price">${formatPrice(firstPackage.discount)}</span>`;
        } else {
            priceHtml += `<span class="price">${formatPrice(firstPackage.price)}</span>`;
        }
        priceHtml += `<span class="period">/${firstPackage.name.includes('Tháng') ? 'tháng' : 'gói'}</span>`; // Simple period logic
        return priceHtml;
    }

    function displayResults(data) {
        if (!resultsListContainer) {
            console.error('Results list container not found!');
            return;
        }
        resultsListContainer.innerHTML = ''; // Clear previous results

        if (!data || !data.results || data.results.length === 0) {
            resultsListContainer.innerHTML = '<p class="no-results">Không tìm thấy phòng gym nào phù hợp.</p>';
            totalResultsCountSpan.textContent = '0';
            if (filterCountSpan) filterCountSpan.textContent = '0 phòng gym được tìm thấy';
            return;
        }

        // Update counts
        totalResultsCountSpan.textContent = data.totalResults;
        if (resultsSummaryParagraph) {
             // Optionally update the paragraph based on search criteria if available
             resultsSummaryParagraph.textContent = `Hiển thị ${data.results.length} trên tổng số ${data.totalResults} kết quả`;
        }
        if (filterCountSpan) filterCountSpan.textContent = `${data.totalResults} phòng gym được tìm thấy`;

        // Render results
        data.results.forEach(result => {
            const resultItem = document.createElement('div');
            resultItem.classList.add('result-item');
            resultItem.innerHTML = `
                <div class="result-image">
                    <img src="${result.image}" alt="${result.name}">
                    ${result.packages.some(p => p.discount) ? '<div class="result-badge result-badge-deal">Giảm giá</div>' : ''} 
                </div>
                <div class="result-details">
                    <div class="result-name-rating">
                        <h3>${result.name}</h3>
                        ${renderRating(result.rating, result.reviewCount)}
                    </div>
                    <div class="result-location">
                        <i class="fas fa-map-marker-alt"></i>
                        <span>${result.address}</span>
                        <a href="https://maps.google.com/?q=${result.latitude},${result.longitude}" target="_blank" class="map-link">Xem trên bản đồ</a>
                        ${result.distance ? `<span class="distance">${result.distance} km từ vị trí của bạn</span>` : ''}
                    </div>
                    <div class="result-amenities">
                        ${renderFacilities(result.facilities)}
                    </div>
                    <div class="result-classes">
                        ${renderClasses(result.classes)}
                    </div>
                </div>
                <div class="result-price-cta">
                    <div class="result-price">
                        ${renderPrice(result.packages)}
                    </div>
                    <a href="#" class="btn btn-outline btn-sm">Xem chi tiết</a> 
                    <a href="#" class="btn btn-primary">Đăng ký ngay</a>
                </div>
            `;
            resultsListContainer.appendChild(resultItem);
        });

        // TODO: Implement pagination if data.totalResults > data.results.length
    }

    // --- INITIAL LOAD --- 
    displayResults(sampleData);

    // TODO: Add event listeners for filters and sorting to fetch and re-render data
}); 