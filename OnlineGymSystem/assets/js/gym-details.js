// JavaScript cho trang chi tiết phòng tập
document.addEventListener('DOMContentLoaded', function() {
    // Schedule tabs functionality
    const scheduleTabs = document.querySelectorAll('.schedule-tab');
    const scheduleContents = document.querySelectorAll('.schedule-content');

    scheduleTabs.forEach(tab => {
        tab.addEventListener('click', () => {
            // Remove active class from all tabs
            scheduleTabs.forEach(t => t.classList.remove('active'));
            // Hide all schedule contents
            scheduleContents.forEach(content => content.style.display = 'none');
            
            // Add active class to clicked tab
            tab.classList.add('active');
            
            // Show the corresponding schedule content
            const dayTarget = tab.getAttribute('data-day');
            document.getElementById(`schedule-${dayTarget}`).style.display = 'block';
        });
    });

    // Gallery modal functionality
    const galleryItems = document.querySelectorAll('.gallery-item img, .gallery-main img');
    const galleryModal = document.getElementById('galleryModal');
    const modalImage = document.getElementById('modalImage');
    const closeGallery = document.getElementById('closeGallery');
    const prevButton = document.getElementById('prevImage');
    const nextButton = document.getElementById('nextImage');
    
    let currentImageIndex = 0;
    const galleryImages = Array.from(document.querySelectorAll('.gallery-item img, .gallery-main img')).map(img => img.src);
    
    function openGalleryModal(index) {
        currentImageIndex = index;
        modalImage.src = galleryImages[currentImageIndex];
        galleryModal.style.display = 'flex';
        document.body.style.overflow = 'hidden';
    }
    
    function closeGalleryModal() {
        galleryModal.style.display = 'none';
        document.body.style.overflow = 'auto';
    }
    
    function showNextImage() {
        currentImageIndex = (currentImageIndex + 1) % galleryImages.length;
        modalImage.src = galleryImages[currentImageIndex];
    }
    
    function showPrevImage() {
        currentImageIndex = (currentImageIndex - 1 + galleryImages.length) % galleryImages.length;
        modalImage.src = galleryImages[currentImageIndex];
    }
    
    galleryItems.forEach((item, index) => {
        item.addEventListener('click', () => openGalleryModal(index));
    });
    
    closeGallery.addEventListener('click', closeGalleryModal);
    nextButton.addEventListener('click', showNextImage);
    prevButton.addEventListener('click', showPrevImage);
    
    document.addEventListener('keydown', function(e) {
        if (galleryModal.style.display === 'flex') {
            if (e.key === 'Escape') closeGalleryModal();
            if (e.key === 'ArrowRight') showNextImage();
            if (e.key === 'ArrowLeft') showPrevImage();
        }
    });

    galleryModal.addEventListener('click', function(e) {
        if (e.target === galleryModal) {
            closeGalleryModal();
        }
    });

    // Show all photos button
    const btnAllPhotos = document.querySelector('.btn-all-photos');
    btnAllPhotos.addEventListener('click', () => openGalleryModal(0));
    
    // Share button functionality
    const btnShare = document.querySelector('.btn-share');
    const shareModal = document.getElementById('shareModal');
    const closeShare = document.getElementById('closeShare');
    const copyLinkBtn = document.getElementById('copyLink');
    const shareUrl = document.getElementById('shareUrl');
    
    btnShare.addEventListener('click', function() {
        shareModal.style.display = 'flex';
        shareUrl.value = window.location.href;
        document.body.style.overflow = 'hidden';
    });
    
    closeShare.addEventListener('click', function() {
        shareModal.style.display = 'none';
        document.body.style.overflow = 'auto';
    });
    
    shareModal.addEventListener('click', function(e) {
        if (e.target === shareModal) {
            shareModal.style.display = 'none';
            document.body.style.overflow = 'auto';
        }
    });
    
    copyLinkBtn.addEventListener('click', function() {
        shareUrl.select();
        document.execCommand('copy');
        
        // Change button text temporarily
        const originalText = copyLinkBtn.textContent;
        copyLinkBtn.textContent = 'Đã sao chép!';
        
        setTimeout(function() {
            copyLinkBtn.textContent = originalText;
        }, 2000);
    });
    
    // Save/Bookmark button functionality
    const btnSave = document.querySelector('.btn-save');
    
    btnSave.addEventListener('click', function() {
        btnSave.classList.toggle('saved');
        
        if (btnSave.classList.contains('saved')) {
            btnSave.querySelector('i').className = 'fas fa-bookmark';
            btnSave.querySelector('span').textContent = 'Đã lưu';
        } else {
            btnSave.querySelector('i').className = 'far fa-bookmark';
            btnSave.querySelector('span').textContent = 'Lưu';
        }
    });
    
    // Map initialization
    function initMap() {
        // Check if Google Maps is loaded and the map container exists
        if (window.google && document.getElementById('gymMap')) {
            const gymLocation = { lat: 10.7769, lng: 106.7009 }; // Coordinates for Ho Chi Minh City
            const map = new google.maps.Map(document.getElementById('gymMap'), {
                zoom: 15,
                center: gymLocation
            });
            
            const marker = new google.maps.Marker({
                position: gymLocation,
                map: map,
                title: 'California Fitness & Yoga'
            });
        }
    }
    
    // Initialize map if Google Maps API is already loaded
    if (window.google && window.google.maps) {
        initMap();
    }
    
    // Initialize date picker for tour booking
    if (typeof flatpickr !== 'undefined') {
        flatpickr('#tourDate', {
            minDate: 'today',
            dateFormat: 'd/m/Y'
        });
    }
    
    // Tour booking form functionality
    const tourForm = document.getElementById('tourForm');
    
    if (tourForm) {
        tourForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Here you would typically send this data to your server
            const formData = new FormData(tourForm);
            
            // Show success message (for demo purposes)
            const formGroups = tourForm.querySelectorAll('.form-group');
            const originalContent = tourForm.innerHTML;
            
            tourForm.innerHTML = `
                <div class="success-message">
                    <i class="fas fa-check-circle"></i>
                    <h4>Đặt lịch thành công!</h4>
                    <p>Chúng tôi sẽ liên hệ với bạn sớm nhất có thể.</p>
                </div>
            `;
            
            // Reset form after 3 seconds
            setTimeout(() => {
                tourForm.innerHTML = originalContent;
                
                // Re-initialize date picker
                if (typeof flatpickr !== 'undefined') {
                    flatpickr('#tourDate', {
                        minDate: 'today',
                        dateFormat: 'd/m/Y'
                    });
                }
            }, 3000);
        });
    }
}); 