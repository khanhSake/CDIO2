// Lấy bookingNumber và totalAmount từ URL
const urlParams = new URLSearchParams(window.location.search);
const bookingNumber = urlParams.get('bookingNumber');
const totalAmountFromUrl = urlParams.get('totalAmount');

// Hàm hiển thị giá từ URL
function updateTotalAmount() {
    const totalAmountElement = document.getElementById('totalAmount');
    if (!totalAmountElement) {
        console.error('Không tìm thấy phần tử totalAmount');
        return;
    }

    if (!totalAmountFromUrl) {
        totalAmountElement.textContent = 'Không tìm thấy số tiền';
        return;
    }

    const amount = parseFloat(totalAmountFromUrl);
    if (isNaN(amount)) {
        totalAmountElement.textContent = 'Số tiền không hợp lệ';
    } else {
        totalAmountElement.textContent = amount.toLocaleString('vi-VN') + ' VNĐ';
    }
}

// Hàm quay lại trang trước
function goBack() {
    window.history.back();
}

// Hàm xác nhận thanh toán
async function confirmPayment() {
    if (!bookingNumber) {
        alert('Không tìm thấy mã đặt lịch.');
        return;
    }

    try {
        const response = await fetch(`https://localhost:44316/api/PTSessions/update-payment/${bookingNumber}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ paymentStatus: 'Paid' })
        });

        if (response.ok) {
            alert('Thanh toán thành công!');
            window.location.href = 'index.html'; // Chuyển hướng về index.html
        } else {
            const error = await response.text();
            alert('Lỗi khi thanh toán: ' + error);
        }
    } catch (error) {
        console.error('Lỗi khi xác nhận thanh toán:', error);
        alert('Đã xảy ra lỗi khi thanh toán: ' + error.message);
    }
}

// Gọi hàm cập nhật giá khi trang tải
window.onload = function () {
    updateTotalAmount();
};