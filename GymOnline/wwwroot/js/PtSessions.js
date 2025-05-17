const urlParams = new URLSearchParams(window.location.search);
const trainerId = parseInt(urlParams.get('trainerId'));
let branchId = null; // Khởi tạo branchId, sẽ được cập nhật sau khi lấy từ API
let hourlyRate = 0;

async function loadBranchNameById(branchId) {
    try {
        if (!branchId || isNaN(branchId)) {
            throw new Error('branchId không hợp lệ.');
        }

        console.log('Đang tải tên chi nhánh cho branchId:', branchId);
        const response = await fetch(`https://localhost:44316/api/GymBranches/${branchId}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Không thể tải tên chi nhánh: ${response.statusText}`);
        }

        const branchName = await response.json();
        console.log('Tên chi nhánh từ API:', branchName);

        const branchNameDisplay = document.getElementById('branchNameDisplay');
        if (branchNameDisplay) {
            branchNameDisplay.value = branchName; // Sử dụng value thay vì textContent
        } else {
            console.error('Không tìm thấy phần tử branchNameDisplay');
        }
    } catch (error) {
        console.error('Lỗi khi tải tên chi nhánh:', error);
        const branchNameDisplay = document.getElementById('branchNameDisplay');
        if (branchNameDisplay) {
            branchNameDisplay.value = 'Lỗi: ' + error.message;
        }
    }
}

async function loadTrainerRate() {
    try {
        if (!trainerId) {
            throw new Error('trainerId không hợp lệ.');
        }

        console.log('Đang tải thông tin huấn luyện viên cho trainerId:', trainerId);
        const response = await fetch(`https://localhost:44316/api/Trainers/${trainerId}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Không thể tải thông tin huấn luyện viên: ${response.statusText}`);
        }

        const trainer = await response.json();
        console.log('Thông tin huấn luyện viên từ API:', trainer);

        // Lấy hourlyRate và branchId từ trainer
        hourlyRate = trainer.hourlyRate || 0;
        branchId = trainer.branchId || null; // Giả sử API trả về branchId

        if (hourlyRate <= 0) {
            document.getElementById('pricePreview').value = 'Giá không hợp lệ.';
            console.warn('hourlyRate không hợp lệ:', hourlyRate);
        } else {
            console.log('hourlyRate đã tải:', hourlyRate);
            calculatePrice();
        }

        // Gọi loadBranchNameById nếu branchId hợp lệ
        if (branchId && !isNaN(branchId)) {
            await loadBranchNameById(branchId);
        } else {
            console.warn('branchId không hợp lệ:', branchId);
            const branchNameDisplay = document.getElementById('branchNameDisplay');
            if (branchNameDisplay) {
                branchNameDisplay.value = 'Không có chi nhánh được chọn.';
            }
        }
    } catch (error) {
        console.error('Lỗi khi tải thông tin huấn luyện viên:', error);
        document.getElementById('pricePreview').value = 'Không thể tải giá: ' + error.message;
        const branchNameDisplay = document.getElementById('branchNameDisplay');
        if (branchNameDisplay) {
            branchNameDisplay.value = 'Lỗi: ' + error.message;
        }
    }
}

function calculatePrice() {
    const startTime = document.getElementById('startTime').value;
    const endTime = document.getElementById('endTime').value;
    const pricePreview = document.getElementById('pricePreview');

    if (!startTime || !endTime) {
        pricePreview.value = '';
        console.log('Chưa nhập đủ thời gian để tính giá.');
        return;
    }

    const start = new Date(0, 0, 0, ...startTime.split(':').map(Number));
    const end = new Date(0, 0, 0, ...endTime.split(':').map(Number));

    if (end <= start) {
        pricePreview.value = 'Giờ kết thúc phải sau giờ bắt đầu.';
        return;
    }

    const durationMs = end - start;
    const hours = durationMs / (1000 * 60 * 60);

    if (hours <= 0 || isNaN(hours)) {
        pricePreview.value = 'Thời gian không hợp lệ.';
        return;
    }

    if (hourlyRate <= 0) {
        pricePreview.value = 'Giá giờ không hợp lệ.';
        return;
    }

    const price = hourlyRate * hours;
    pricePreview.value = price.toLocaleString('vi-VN') + ' VND';
}

function showPaymentForm(bookingNumber, totalAmount) {
    const formContainer = document.querySelector('.max-w-md.mx-auto');
    formContainer.innerHTML = `
        <h1 class="text-2xl font-bold mb-4">Thanh Toán Buổi Tập</h1>
        <div class="mb-4">
            <label class="block text-sm font-medium">Mã đặt lịch:</label>
            <input type="text" id="bookingNumber" value="${bookingNumber}" class="w-full p-2 border rounded" readonly>
        </div>
        <div class="mb-4">
            <label class="block text-sm font-medium">Số tiền cần thanh toán (VND):</label>
            <input type="text" id="totalAmount" value="${totalAmount.toLocaleString('vi-VN')} VND" class="w-full p-2 border rounded" readonly>
        </div>
        <div class="mb-4">
            <label class="block text-sm font-medium">Phương thức thanh toán:</label>
            <select id="paymentMethod" class="w-full p-2 border rounded" required>
                <option value="">Chọn phương thức</option>
                <option value="Cash">Tiền mặt</option>
                <option value="BankTransfer">Chuyển khoản</option>
                <option value="CreditCard">Thẻ tín dụng</option>
            </select>
        </div>
        <button onclick="confirmPayment('${bookingNumber}')" class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 w-full">Xác Nhận Thanh Toán</button>
    `;
}

async function confirmPayment(bookingNumber) {
    const paymentMethod = document.getElementById('paymentMethod').value;

    if (!paymentMethod) {
        alert('Vui lòng chọn phương thức thanh toán.');
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
            window.location.href = 'trainer_list.html';
        } else {
            const error = await response.text();
            alert('Lỗi khi thanh toán: ' + error);
        }
    } catch (error) {
        console.error('Lỗi khi xác nhận thanh toán:', error);
        alert('Đã xảy ra lỗi khi thanh toán: ' + error.message);
    }
}

async function bookPTSession() {
    const userId = 3;
    const sessionDate = document.getElementById('sessionDate').value;
    const startTime = document.getElementById('startTime').value;
    const endTime = document.getElementById('endTime').value;
    const notes = document.getElementById('notes').value;

    if (!trainerId || !branchId || !sessionDate || !startTime || !endTime) {
        alert('Vui lòng điền đầy đủ thông tin.');
        return;
    }

    const startTimeString = `${startTime}:00`;
    const endTimeString = `${endTime}:00`;

    const ptSession = {
        userId: userId,
        trainerId: trainerId,
        branchId: branchId,
        sessionDate: sessionDate,
        startTime: startTimeString,
        endTime: endTimeString,
        notes: notes,
        discountAmount: 0,
        status: "Booked",
        paymentStatus: "Unpaid",
        isActive: true
    };

    try {
        const response = await fetch('https://localhost:44316/api/PTSessions', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(ptSession)
        });

        if (response.ok) {
            const result = await response.json();
            alert('Đặt buổi tập thành công! Mã đặt lịch: ' + result.bookingNumber);
            const url = `payment.html?bookingNumber=${encodeURIComponent(result.bookingNumber)}&totalAmount=${encodeURIComponent(result.totalAmount)}`;
            window.location.href = url;
        } else {
            const error = await response.text();
            alert('Lỗi: ' + error);
        }
    } catch (error) {
        console.error('Lỗi khi đặt buổi tập:', error);
        alert('Đã xảy ra lỗi khi đặt buổi tập: ' + error.message);
    }
}

// Gọi loadTrainerRate khi trang tải
window.onload = function () {
    console.log('trainerId:', trainerId);
    loadTrainerRate(); // loadTrainerRate sẽ gọi loadBranchNameById
};