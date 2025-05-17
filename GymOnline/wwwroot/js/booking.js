const apiBaseUrl = "http://localhost:44316/api";
const urlParams = new URLSearchParams(window.location.search);
const packageId = urlParams.get("packageId");

// Hàm hiển thị thông báo
function showMessage(text, isSuccess) {
    const messageDiv = document.getElementById("message");
    messageDiv.textContent = text;
    messageDiv.className = isSuccess ? "success" : "error";
}

// Hiển thị form đặt booking nếu có packageId
async function loadBookingForm() {
    if (!packageId) {
        showMessage("Không tìm thấy gói tập để đặt.", false);
        return;
    }

    try {
        const response = await fetch(`${apiBaseUrl}/membershippackages/${packageId}`);
        if (!response.ok) throw new Error("Không thể tải thông tin gói tập.");
        const package = await response.json();

        document.getElementById("bookingFormContainer").style.display = "block";
        document.getElementById("packageName").textContent = package.packageName;
    } catch (error) {
        showMessage(error.message, false);
    }
}

// Xử lý form đặt booking
document.getElementById("bookingForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const startDate = document.getElementById("startDate").value;
    if (!startDate) {
        showMessage("Vui lòng chọn ngày bắt đầu.", false);
        return;
    }

    try {
        const response = await fetch(`${apiBaseUrl}/bookings`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                packageId: parseInt(packageId),
                startDate: startDate
            })
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.error || "Không thể đặt gói tập.");
        }

        const booking = await response.json();
        document.getElementById("bookingDetails").style.display = "block";
        document.getElementById("bookingFormContainer").style.display = "none";
        document.getElementById("bookingNumber").textContent = booking.bookingNumber;
        document.getElementById("packageName").textContent = booking.package.packageName;
        document.getElementById("startDate").textContent = booking.startDate;
        document.getElementById("endDate").textContent = booking.endDate;
        document.getElementById("totalAmount").textContent = `$${booking.totalAmount.toFixed(2)}`;
        document.getElementById("bookingStatus").textContent = booking.bookingStatus;
        showMessage("Đặt gói thành công!", true);
    } catch (error) {
        showMessage(error.message, false);
    }
});

// Tải form khi trang được tải
window.onload = loadBookingForm;