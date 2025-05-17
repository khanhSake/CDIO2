// Lấy trainerId từ URL
const urlParams = new URLSearchParams(window.location.search);
const trainerId = urlParams.get('trainerId'); // Không cần encodeURIComponent ở đây vì fetch sẽ xử lý

// Hàm gọi API để lấy review của huấn luyện viên
async function loadReviews() {
    if (!trainerId || isNaN(trainerId)) {
        console.error('TrainerId không hợp lệ:', trainerId);
        document.getElementById("reviews-container").innerHTML = "<p>Trainer ID không hợp lệ.</p>";
        return;
    }

    try {
        console.log('Gửi request tới:', `https://localhost:44316/api/Reviews/trainer/${trainerId}`);
        const res = await fetch(`https://localhost:44316/api/Reviews/trainer/${trainerId}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });

        console.log('Phản hồi API:', res.status, res.statusText);

        if (!res.ok) {
            throw new Error(`API request failed with status ${res.status}: ${res.statusText}`);
        }

        const reviews = await res.json();
        console.log('Dữ liệu trả về:', reviews);

        if (!Array.isArray(reviews) || reviews.length === 0) {
            document.getElementById("reviews-container").innerHTML = "<p>Không có đánh giá nào cho huấn luyện viên này.</p>";
            return;
        }

        let reviewHtml = "";
        reviews.forEach(review => {
            // Kiểm tra và xử lý dữ liệu
            const reviewDate = review.reviewDate ? new Date(review.reviewDate).toLocaleDateString('vi-VN') : "Ngày không hợp lệ";
            const comment = review.comment || "Không có nhận xét.";
            const rating = review.rating || 0;

            reviewHtml += `
                <div class="review-card">
                    <p><strong>Đánh giá:</strong> ${rating} ⭐</p>
                    <p><strong>Ngày đánh giá:</strong> ${reviewDate}</p>
                    <p><strong>Nhận xét:</strong> ${comment}</p>
                </div>
            `;
        });

        document.getElementById("reviews-container").innerHTML = reviewHtml;

    } catch (error) {
        console.error("Lỗi khi tải các review:", error);
        document.getElementById("reviews-container").innerHTML = "<p>Lỗi tải review: " + error.message + "</p>";
    }
}

loadReviews();