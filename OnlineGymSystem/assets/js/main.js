// Đợi cho tài liệu HTML tải xong
document.addEventListener('DOMContentLoaded', function() {
    // Xử lý menu di động
    const mobileMenuBtn = document.querySelector('.mobile-menu-btn');
    const mobileMenu = document.querySelector('.main-nav');
    
    if (mobileMenuBtn && mobileMenu) {
        mobileMenuBtn.addEventListener('click', function() {
            this.classList.toggle('active');
            mobileMenu.classList.toggle('active');
            
            // Thêm hiệu ứng cho nút menu
            const spans = this.querySelectorAll('span');
            if (spans.length === 3) {
                spans[0].classList.toggle('rotate-down');
                spans[1].classList.toggle('fade-out');
                spans[2].classList.toggle('rotate-up');
            }
        });
    }
    
    // Xử lý dropdown ngôn ngữ
    const languageSelector = document.querySelector('.language-selector');
    if (languageSelector) {
        languageSelector.addEventListener('click', function() {
            // Ở đây sẽ thêm dropdown ngôn ngữ trong tương lai
            console.log('Language selector clicked');
        });
    }
    
    // Xử lý form tìm kiếm
    const searchForm = document.querySelector('.search-form');
    if (searchForm) {
        searchForm.addEventListener('submit', function(e) {
            // Không cần ngăn chặn hành vi mặc định vì chúng ta muốn form submit đến trang kết quả
            
            // Lấy giá trị từ form
            const location = document.getElementById('gym-location').value;
            const startDate = document.getElementById('start-date').value;
            const packageType = document.getElementById('package-type').value;
            const peopleCount = document.getElementById('people-count').value;
            
            // Kiểm tra dữ liệu
            if (!location) {
                e.preventDefault();
                showNotification('Vui lòng chọn cơ sở/phòng gym', 'error');
                return;
            }
            
            if (!startDate) {
                e.preventDefault();
                showNotification('Vui lòng chọn ngày bắt đầu', 'error');
                return;
            }
            
            // Nếu dữ liệu hợp lệ, hiển thị thông báo và form sẽ tự submit
            showNotification('Đang tìm kiếm...', 'success');
        });
    }
    
    // Xử lý hiệu ứng cuộn trang
    window.addEventListener('scroll', function() {
        const header = document.querySelector('.header');
        if (header) {
            if (window.scrollY > 50) {
                header.classList.add('scrolled');
            } else {
                header.classList.remove('scrolled');
            }
        }
    });
    
    // Xử lý hiệu ứng khi hover vào gói tập
    const packageCards = document.querySelectorAll('.package-card');
    packageCards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.classList.add('hover-effect');
        });
        
        card.addEventListener('mouseleave', function() {
            this.classList.remove('hover-effect');
        });
    });
    
    // Thiết lập ngày mặc định cho date picker
    const startDateInput = document.getElementById('start-date');
    if (startDateInput) {
        // Thiết lập ngày mặc định là ngày hiện tại
        const today = new Date();
        const formattedDate = today.toISOString().split('T')[0];
        startDateInput.value = formattedDate;
        
        // Đảm bảo người dùng không thể chọn ngày trong quá khứ
        startDateInput.min = formattedDate;
    }
    
    // Thêm animation cho các phần tử khi cuộn đến
    initScrollAnimation();
});

// Hàm hiển thị thông báo
function showNotification(message, type = 'info') {
    // Kiểm tra xem đã có notification-container chưa
    let container = document.querySelector('.notification-container');
    if (!container) {
        container = document.createElement('div');
        container.className = 'notification-container';
        document.body.appendChild(container);
    }
    
    // Tạo thông báo mới
    const notification = document.createElement('div');
    notification.className = `notification notification-${type}`;
    notification.innerHTML = `
        <span class="notification-message">${message}</span>
        <span class="notification-close">&times;</span>
    `;
    
    // Thêm thông báo vào container
    container.appendChild(notification);
    
    // Xử lý nút đóng thông báo
    const closeBtn = notification.querySelector('.notification-close');
    closeBtn.addEventListener('click', function() {
        notification.classList.add('notification-hide');
        setTimeout(() => {
            notification.remove();
        }, 300);
    });
    
    // Tự động đóng sau 5 giây
    setTimeout(() => {
        notification.classList.add('notification-hide');
        setTimeout(() => {
            notification.remove();
        }, 300);
    }, 5000);
}

// Hàm khởi tạo animation khi cuộn
function initScrollAnimation() {
    // Lấy tất cả các phần tử cần animation
    const elements = document.querySelectorAll('.section-header, .package-card, .suggestion-card, .promo-content');
    
    // Observer để theo dõi các phần tử
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animated');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.1 });
    
    // Đăng ký các phần tử vào observer
    elements.forEach(el => {
        observer.observe(el);
    });
} 