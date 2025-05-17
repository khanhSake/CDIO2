async function loadTrainers() {
    try {
        const res = await fetch("https://localhost:44316/api/Trainers");
        const trainers = await res.json();

        if (!trainers || trainers.length === 0) {
            document.getElementById("trainer-container").innerHTML = "<p>Không tìm thấy huấn luyện viên.</p>";
            return;
        }

        let html = "";

        trainers.forEach(t => {
            const imgSrc = t.profileImage || "default-avatar.png";

            html += `
                <div class="trainer-card">
                    <img src="${imgSrc}" alt="Trainer" class="trainer-img">
                    <div class="trainer-info">
                        <h2>${t.fullName}</h2>
                        <p><strong>Chuyên môn:</strong> ${t.specialization ?? "Chưa rõ"}</p>
                        <p><strong>Kinh nghiệm:</strong> ${t.experience ?? "?"} năm</p>
                        <p><strong>Giá/giờ:</strong> ${t.hourlyRate?.toLocaleString("vi-VN")} đ</p>
                        <p><strong>Đánh giá:</strong> ${t.ratingAverage ?? "-"} ⭐ (${t.reviewCount ?? 0} đánh giá)</p>
                        <p><strong>Mô tả:</strong> ${t.bio ?? "Không có mô tả."}</p>
                        <div class="buttons">
                            <button onclick="viewReview(${t.trainerId})">Xem Review</button>
                            <button onclick="bookSession(${t.trainerId})">Đặt Buổi Tập Cá Nhân</button>
                        </div>
                    </div>
                </div>
            `;
        });

        document.getElementById("trainer-container").innerHTML = html;
    } catch (error) {
        console.error("Lỗi khi gọi API Trainer:", error);
        document.getElementById("trainer-container").innerHTML = "<p>Lỗi tải dữ liệu.</p>";
    }
}

function viewReview(id) {
    window.location.href = `review.html?trainerId=${id}`;
}   

function bookSession(id) {
    window.location.href = `PtSessions.html?trainerId=${id}`;
}
loadTrainers();
