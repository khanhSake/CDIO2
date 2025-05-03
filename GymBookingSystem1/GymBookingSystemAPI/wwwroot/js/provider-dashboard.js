// Hàm tải danh sách chi nhánh
async function loadBranches() {
    try {
        const response = await fetch('http://localhost:5197/api/GymBranches');
        if (!response.ok) throw new Error('Không thể tải danh sách chi nhánh');
        const branches = await response.json();
        const tbody = document.getElementById('branchesBody');
        tbody.innerHTML = '';
        branches.forEach(branch => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${branch.branchName}</td>
                <td>${branch.address}</td>
                <td>${branch.city}</td>
                <td>
                    <button class="btn btn-warning btn-sm edit-btn" data-id="${branch.branchID}">Sửa</button>
                    <button class="btn btn-danger btn-sm delete-btn" data-id="${branch.branchID}">Xóa</button>
                    <button class="btn btn-info btn-sm reviews-btn" data-id="${branch.branchID}">Xem đánh giá</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        // Thêm sự kiện cho các nút
        document.querySelectorAll('.edit-btn').forEach(btn => {
            btn.addEventListener('click', () => {
                const modal = new bootstrap.Modal(document.getElementById('editBranchModal'));
                document.getElementById('editBranchIdInput').value = btn.dataset.id;
                modal.show();
            });
        });
        document.querySelectorAll('.delete-btn').forEach(btn => {
            btn.addEventListener('click', () => deleteBranch(btn.dataset.id));
        });
        document.querySelectorAll('.reviews-btn').forEach(btn => {
            btn.addEventListener('click', () => viewReviews(btn.dataset.id));
        });
    } catch (error) {
        console.error('Lỗi khi tải danh sách chi nhánh:', error);
        alert('Có lỗi xảy ra khi tải danh sách chi nhánh. Vui lòng thử lại.');
    }
}

// Hàm tải thông tin chi nhánh khi nhấn nút "Tải thông tin"
document.getElementById('loadBranchDetailsBtn').addEventListener('click', async () => {
    const branchId = document.getElementById('editBranchIdInput').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }

    try {
        const response = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải thông tin chi nhánh');
        const branch = await response.json();

        // Hiển thị thông tin chi nhánh trong form
        document.getElementById('editBranchId').value = branch.branchID;
        document.getElementById('editBranchName').value = branch.branchName;
        document.getElementById('editAddress').value = branch.address;
        document.getElementById('editCity').value = branch.city;
        document.getElementById('editDistrict').value = branch.district;
        document.getElementById('editPhoneNumber').value = branch.phoneNumber;
        document.getElementById('editEmail').value = branch.email;
        document.getElementById('editOpeningHours').value = branch.openingHours;
        document.getElementById('editDescription').value = branch.description;
        document.getElementById('editMapLocation').value = branch.mapLocation;
        document.getElementById('editLatitude').value = branch.latitude;
        document.getElementById('editLongitude').value = branch.longitude;

        // Hiển thị section chứa thông tin chi nhánh
        document.getElementById('branchDetailsSection').style.display = 'block';
    } catch (error) {
        console.error('Lỗi khi tải thông tin chi nhánh:', error);
        alert('Có lỗi xảy ra khi tải thông tin chi nhánh. Vui lòng kiểm tra BranchID và thử lại.');
    }
});

// Hàm xử lý cập nhật thông tin chi nhánh
document.getElementById('editBranchForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const branchId = document.getElementById('editBranchId').value;
    if (!branchId) {
        alert('Vui lòng tải thông tin chi nhánh trước khi cập nhật.');
        return;
    }

    const updatedData = {
        BranchName: document.getElementById('editBranchName').value,
        Address: document.getElementById('editAddress').value,
        City: document.getElementById('editCity').value,
        District: document.getElementById('editDistrict').value,
        PhoneNumber: document.getElementById('editPhoneNumber').value,
        Email: document.getElementById('editEmail').value,
        OpeningHours: document.getElementById('editOpeningHours').value,
        Description: document.getElementById('editDescription').value,
        MapLocation: document.getElementById('editMapLocation').value,
        Latitude: parseFloat(document.getElementById('editLatitude').value),
        Longitude: parseFloat(document.getElementById('editLongitude').value)
    };

    try {
        const response = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updatedData)
        });

        if (!response.ok) throw new Error('Không thể cập nhật chi nhánh');
        loadBranches();
        bootstrap.Modal.getInstance(document.getElementById('editBranchModal')).hide();
        alert('Cập nhật chi nhánh thành công!');
    } catch (error) {
        console.error('Lỗi khi cập nhật chi nhánh:', error);
        alert('Có lỗi xảy ra khi cập nhật chi nhánh. Vui lòng thử lại.');
    }
});

// Hàm thêm chi nhánh với BranchID nhập thủ công
document.getElementById('addBranchForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const branchData = {
        ProviderID: parseInt(document.getElementById('providerID').value),
        BranchID: parseInt(document.getElementById('branchId').value),
        BranchName: document.getElementById('branchName').value,
        Address: document.getElementById('address').value,
        City: document.getElementById('city').value,
        District: document.getElementById('district').value,
        PhoneNumber: document.getElementById('phoneNumber').value,
        Email: document.getElementById('email').value,
        OpeningHours: document.getElementById('openingHours').value,
        Description: document.getElementById('description').value,
        MapLocation: document.getElementById('mapLocation').value,
        Latitude: parseFloat(document.getElementById('latitude').value),
        Longitude: parseFloat(document.getElementById('longitude').value)
    };

    try {
        const branchResponse = await fetch('http://localhost:5197/api/GymBranches', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(branchData)
        });

        if (!branchResponse.ok) {
            const errorData = await branchResponse.json();
            if (errorData && errorData.message) {
                throw new Error(errorData.message);
            }
            throw new Error('Không thể thêm chi nhánh');
        }

        const result = await branchResponse.json();
        loadBranches();
        bootstrap.Modal.getInstance(document.getElementById('addBranchModal')).hide();
        alert(result.message || 'Thêm chi nhánh thành công!');
    } catch (error) {
        console.error('Lỗi khi thêm chi nhánh:', error);
        alert(error.message || 'Có lỗi xảy ra khi thêm chi nhánh. Vui lòng thử lại.');
    }
});

// Hàm xóa chi nhánh
async function deleteBranch(id) {
    if (confirm('Bạn có chắc muốn xóa chi nhánh này?')) {
        try {
            const response = await fetch(`http://localhost:5197/api/GymBranches/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) throw new Error('Xóa không thành công');
            loadBranches();
        } catch (error) {
            console.error('Lỗi khi xóa:', error);
            alert('Có lỗi xảy ra khi xóa chi nhánh. Vui lòng thử lại.');
        }
    }
}

// Hàm xem và quản lý đánh giá
async function viewReviews(branchId) {
    try {
        const response = await fetch(`http://localhost:5197/api/Reviews/Branch/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải đánh giá');
        const reviews = await response.json();
        const tbody = document.getElementById('reviewsBody');
        tbody.innerHTML = '';
        reviews.forEach(review => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${review.userFullName}</td>
                <td>${review.rating}</td>
                <td>${review.comment}</td>
                <td>${new Date(review.reviewDate).toLocaleDateString('vi-VN')}</td>
                <td>
                    <button class="btn btn-success btn-sm approve-btn" data-id="${review.reviewID}" ${review.isApproved ? 'disabled' : ''}>Duyệt</button>
                    <button class="btn btn-danger btn-sm delete-btn" data-id="${review.reviewID}">Xóa</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.approve-btn').forEach(btn => {
            btn.addEventListener('click', async () => {
                try {
                    const response = await fetch(`http://localhost:5197/api/Reviews/${btn.dataset.id}/Approve`, {
                        method: 'PUT',
                        headers: { 'Content-Type': 'application/json' }
                    });
                    if (!response.ok) throw new Error('Không thể duyệt đánh giá');
                    viewReviews(branchId);
                    loadBranches();
                } catch (error) {
                    console.error('Lỗi khi duyệt đánh giá:', error);
                    alert('Có lỗi xảy ra khi duyệt đánh giá. Vui lòng thử lại.');
                }
            });
        });

        document.querySelectorAll('.delete-btn').forEach(btn => {
            btn.addEventListener('click', async () => {
                if (confirm('Bạn có chắc muốn xóa đánh giá này?')) {
                    try {
                        const response = await fetch(`http://localhost:5197/api/Reviews/${btn.dataset.id}`, {
                            method: 'DELETE'
                        });
                        if (!response.ok) throw new Error('Không thể xóa đánh giá');
                        viewReviews(branchId);
                        loadBranches();
                    } catch (error) {
                        console.error('Lỗi khi xóa đánh giá:', error);
                        alert('Có lỗi xảy ra khi xóa đánh giá. Vui lòng thử lại.');
                    }
                }
            });
        });

        const modal = new bootstrap.Modal(document.getElementById('manageReviewsModal'));
        document.getElementById('reviewBranchIdInput').value = branchId;
        modal.show();
    } catch (error) {
        console.error('Lỗi khi xem đánh giá:', error);
        alert('Có lỗi xảy ra khi xem đánh giá. Vui lòng thử lại.');
    }
}

// Xử lý sự kiện khi nhấn nút "Tải đánh giá"
document.getElementById('loadReviewsBtn').addEventListener('click', () => {
    const branchId = document.getElementById('reviewBranchIdInput').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    viewReviews(branchId);
});

// Hàm tải danh sách hình ảnh theo BranchID
async function loadImages(branchId) {
    try {
        const response = await fetch(`http://localhost:5197/api/BranchImages/Branch/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải danh sách hình ảnh');
        const images = await response.json();
        const tbody = document.getElementById('imagesBody');
        tbody.innerHTML = '';
        images.forEach(image => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${image.imageURL}</td>
                <td>${image.caption}</td>
                <td>${image.isMainImage ? 'Có' : 'Không'}</td>
                <td>
                    <button class="btn btn-danger btn-sm delete-image-btn" data-id="${image.imageID}">Xóa</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.delete-image-btn').forEach(btn => {
            btn.addEventListener('click', async () => {
                if (confirm('Bạn có chắc muốn xóa hình ảnh này?')) {
                    try {
                        const response = await fetch(`http://localhost:5197/api/BranchImages/${btn.dataset.id}`, {
                            method: 'DELETE'
                        });
                        if (!response.ok) throw new Error('Không thể xóa hình ảnh');
                        loadImages(branchId);
                    } catch (error) {
                        console.error('Lỗi khi xóa hình ảnh:', error);
                        alert('Có lỗi xảy ra khi xóa hình ảnh. Vui lòng thử lại.');
                    }
                }
            });
        });
    } catch (error) {
        console.error('Lỗi khi tải danh sách hình ảnh:', error);
        alert('Có lỗi xảy ra khi tải danh sách hình ảnh. Vui lòng thử lại.');
    }
}

// Xử lý sự kiện khi nhấn nút "Tải hình ảnh"
document.getElementById('loadImagesBtn').addEventListener('click', () => {
    const branchId = document.getElementById('imageBranchIdInput').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    document.getElementById('imageBranchId').value = branchId;
    loadImages(branchId);
});

// Modal Cập nhật hình ảnh
document.getElementById('updateImageForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const branchId = document.getElementById('imageBranchId').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID và tải hình ảnh trước.');
        return;
    }
    const imageData = {
        BranchID: parseInt(branchId),
        ImageURL: document.getElementById('imageUrl').value,
        Caption: document.getElementById('imageCaption').value,
        IsMainImage: document.getElementById('isMainImage').checked,
        DisplayOrder: 0
    };
    try {
        const response = await fetch('http://localhost:5197/api/BranchImages', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(imageData)
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Không thể thêm hình ảnh');
        }

        const result = await response.json();
        document.getElementById('imageUrl').value = '';
        document.getElementById('imageCaption').value = '';
        document.getElementById('isMainImage').checked = false;
        loadImages(branchId);
        alert(result.message || 'Thêm hình ảnh thành công!');
    } catch (error) {
        console.error('Lỗi khi thêm hình ảnh:', error);
        alert(error.message || 'Có lỗi xảy ra khi thêm hình ảnh. Vui lòng thử lại.');
    }
});

// Hàm tải danh sách tiện ích theo BranchID
async function loadFacilities(branchId) {
    try {
        const response = await fetch(`http://localhost:5197/api/Facilities/Branch/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải danh sách tiện ích');
        const facilities = await response.json();
        const tbody = document.getElementById('facilitiesBody');
        tbody.innerHTML = '';
        facilities.forEach(facility => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${facility.facilityName}</td>
                <td>${facility.description}</td>
                <td>${facility.iconClass}</td>
                <td>
                    <button class="btn btn-warning btn-sm edit-facility-btn" data-id="${facility.facilityID}">Sửa</button>
                    <button class="btn btn-danger btn-sm delete-facility-btn" data-id="${facility.facilityID}">Xóa</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.edit-facility-btn').forEach(btn => {
            btn.addEventListener('click', () => editFacility(btn.dataset.id));
        });
        document.querySelectorAll('.delete-facility-btn').forEach(btn => {
            btn.addEventListener('click', () => deleteFacility(btn.dataset.id, branchId));
        });
    } catch (error) {
        console.error('Lỗi khi tải danh sách tiện ích:', error);
        alert('Có lỗi xảy ra khi tải danh sách tiện ích. Vui lòng thử lại.');
    }
}

// Xử lý sự kiện khi nhấn nút "Tải tiện ích"
document.getElementById('loadFacilitiesBtn').addEventListener('click', () => {
    const branchId = document.getElementById('facilityBranchId').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    loadFacilities(branchId);
});

// Hàm sửa tiện ích
async function editFacility(facilityId) {
    try {
        const response = await fetch(`http://localhost:5197/api/Facilities/${facilityId}`);
        if (!response.ok) throw new Error('Không thể tải thông tin tiện ích');
        const facility = await response.json();
        document.getElementById('editingFacilityId').value = facility.facilityID;
        document.getElementById('facilityBranchId').value = facility.branchID;
        document.getElementById('facilityName').value = facility.facilityName;
        document.getElementById('facilityDescription').value = facility.description;
        document.getElementById('facilityIcon').value = facility.iconClass;
        const modal = new bootstrap.Modal(document.getElementById('updateFacilityModal'));
        modal.show();
    } catch (error) {
        console.error('Lỗi khi sửa tiện ích:', error);
        alert('Có lỗi xảy ra khi sửa tiện ích. Vui lòng thử lại.');
    }
}

// Hàm xóa tiện ích
async function deleteFacility(facilityId, branchId) {
    if (confirm('Bạn có chắc muốn xóa tiện ích này?')) {
        try {
            const response = await fetch(`http://localhost:5197/api/Facilities/${facilityId}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(errorData.message || 'Không thể xóa tiện ích');
            }
            const result = await response.json();
            loadFacilities(branchId);
            alert(result.message || 'Xóa tiện ích thành công!');
        } catch (error) {
            console.error('Lỗi khi xóa tiện ích:', error);
            alert(error.message || 'Có lỗi xảy ra khi xóa tiện ích. Vui lòng thử lại.');
        }
    }
}

// Modal Cập nhật tiện ích
document.getElementById('updateFacilityForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const branchId = document.getElementById('facilityBranchId').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    const facilityData = {
        BranchID: parseInt(branchId),
        FacilityName: document.getElementById('facilityName').value,
        Description: document.getElementById('facilityDescription').value,
        IconClass: document.getElementById('facilityIcon').value
    };
    const facilityId = document.getElementById('editingFacilityId').value;
    let url = 'http://localhost:5197/api/Facilities';
    let method = 'POST';
    let successMessage = 'Thêm tiện ích thành công!';

    if (facilityId) {
        url = `http://localhost:5197/api/Facilities/${facilityId}`;
        method = 'PUT';
        successMessage = 'Cập nhật tiện ích thành công!';
    }

    try {
        const response = await fetch(url, {
            method: method,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(facilityData)
        });
        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Không thể thêm/cập nhật tiện ích');
        }
        const result = await response.json();
        document.getElementById('facilityName').value = '';
        document.getElementById('facilityDescription').value = '';
        document.getElementById('facilityIcon').value = '';
        document.getElementById('editingFacilityId').value = '';
        loadFacilities(branchId);
        alert(result.message || successMessage);
    } catch (error) {
        console.error('Lỗi khi thêm/cập nhật tiện ích:', error);
        alert(error.message || 'Có lỗi xảy ra khi thêm/cập nhật tiện ích. Vui lòng thử lại.');
    }
});

// Hàm tải chi tiết tiện ích theo BranchID (được gọi khi mở modal)
async function loadFacilityDetails(branchId) {
    try {
        const response = await fetch(`http://localhost:5197/api/Facilities/Branch/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải chi tiết tiện ích');
        const facilities = await response.json();
        const detailsDiv = document.getElementById('facilityDetails');
        detailsDiv.innerHTML = '<h6>Thông tin tiện ích:</h6>';
        if (facilities && facilities.length > 0) {
            const ul = document.createElement('ul');
            facilities.forEach(facility => {
                const li = document.createElement('li');
                li.textContent = `${facility.facilityName} - ${facility.description} (Icon: ${facility.iconClass})`;
                ul.appendChild(li);
            });
            detailsDiv.appendChild(ul);
        } else {
            detailsDiv.innerHTML += '<p>Chưa có tiện ích nào.</p>';
        }
    } catch (error) {
        console.error('Lỗi khi tải chi tiết tiện ích:', error);
        document.getElementById('facilityDetails').innerHTML = '<p>Có lỗi xảy ra khi tải tiện ích. Vui lòng thử lại.</p>';
    }
}

// Hàm tải danh sách gói tập theo BranchID
async function loadPackages(branchId) {
    try {
        const response = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`);
        if (!response.ok) throw new Error('Không thể tải danh sách gói tập');
        const branch = await response.json();
        const tbody = document.getElementById('packagesBody');
        tbody.innerHTML = '';
        branch.membershipPackages.forEach(pkg => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${pkg.packageName}</td>
                <td>${pkg.duration}</td>
                <td>${pkg.durationType}</td>
                <td>${pkg.price.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</td>
                <td>${pkg.discountedPrice ? pkg.discountedPrice.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' }) : 'N/A'}</td>
                <td>${pkg.description}</td>
                <td>${pkg.isPopular ? 'Có' : 'Không'}</td>
                <td>
                    <button class="btn btn-warning btn-sm edit-package-btn" data-id="${pkg.packageID}">Sửa</button>
                    <button class="btn btn-danger btn-sm delete-package-btn" data-id="${pkg.packageID}">Xóa</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.edit-package-btn').forEach(btn => {
            btn.addEventListener('click', () => editPackage(btn.dataset.id));
        });
        document.querySelectorAll('.delete-package-btn').forEach(btn => {
            btn.addEventListener('click', () => deletePackage(btn.dataset.id, branchId));
        });
    } catch (error) {
        console.error('Lỗi khi tải danh sách gói tập:', error);
        alert('Có lỗi xảy ra khi tải danh sách gói tập. Vui lòng thử lại.');
    }
}

// Xử lý sự kiện khi nhấn nút "Tải gói tập"
document.getElementById('loadPackagesBtn').addEventListener('click', () => {
    const branchId = document.getElementById('packageBranchId').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    loadPackages(branchId);
});

// Hàm sửa gói tập
async function editPackage(packageId) {
    try {
        const response = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`);
        if (!response.ok) throw new Error('Không thể tải thông tin gói tập');
        const pkg = await response.json();
        document.getElementById('editingPackageId').value = pkg.packageID;
        document.getElementById('packageBranchId').value = pkg.branchID; // Ensure BranchID is set
        document.getElementById('newPackageName').value = pkg.packageName;
        document.getElementById('newDuration').value = pkg.duration;
        document.getElementById('newDurationType').value = pkg.durationType;
        document.getElementById('newPrice').value = pkg.price;
        document.getElementById('newDiscountedPrice').value = pkg.discountedPrice || '';
        document.getElementById('newDescription').value = pkg.description || '';
        document.getElementById('newFeatures').value = pkg.features || '';
        document.getElementById('newIsPopular').checked = pkg.isPopular;
        const modal = new bootstrap.Modal(document.getElementById('updatePackageModal'));
        modal.show();
    } catch (error) {
        console.error('Lỗi khi sửa gói tập:', error);
        alert('Có lỗi xảy ra khi sửa gói tập. Vui lòng thử lại.');
    }
}

// Hàm xóa gói tập
async function deletePackage(packageId, branchId) {
    if (confirm('Bạn có chắc muốn xóa gói tập này?')) {
        try {
            const response = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`, {
                method: 'DELETE'
            });
            if (!response.ok) throw new Error('Xóa không thành công');
            loadPackages(branchId);
        } catch (error) {
            console.error('Lỗi khi xóa gói tập:', error);
            alert('Có lỗi xảy ra khi xóa gói tập. Vui lòng thử lại.');
        }
    }
}

// Modal Cập nhật gói tập
document.getElementById('updatePackageForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const branchId = document.getElementById('packageBranchId').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID và tải gói tập trước.');
        return;
    }
    const packageData = {
        BranchID: parseInt(branchId), // Add BranchID to the request body
        PackageName: document.getElementById('newPackageName').value,
        Duration: parseInt(document.getElementById('newDuration').value),
        DurationType: document.getElementById('newDurationType').value,
        Price: parseFloat(document.getElementById('newPrice').value),
        DiscountedPrice: document.getElementById('newDiscountedPrice').value ? parseFloat(document.getElementById('newDiscountedPrice').value) : null,
        Description: document.getElementById('newDescription').value,
        Features: document.getElementById('newFeatures').value,
        IsPopular: document.getElementById('newIsPopular').checked
    };
    const packageId = document.getElementById('editingPackageId').value;
    let url = 'http://localhost:5197/api/MembershipPackages';
    let method = 'POST';
    let successMessage = 'Thêm gói tập thành công!';

    if (packageId) {
        url = `http://localhost:5197/api/MembershipPackages/${packageId}`;
        method = 'PUT';
        successMessage = 'Cập nhật gói tập thành công!';
    }

    try {
        const response = await fetch(url, {
            method: method,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(packageData)
        });
        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Không thể thêm/cập nhật gói tập');
        }
        document.getElementById('newPackageName').value = '';
        document.getElementById('newDuration').value = '';
        document.getElementById('newDurationType').value = 'Month';
        document.getElementById('newPrice').value = '';
        document.getElementById('newDiscountedPrice').value = '';
        document.getElementById('newDescription').value = '';
        document.getElementById('newFeatures').value = '';
        document.getElementById('newIsPopular').checked = false;
        document.getElementById('editingPackageId').value = '';
        loadPackages(branchId);
        alert(successMessage);
    } catch (error) {
        console.error('Lỗi khi thêm/cập nhật gói tập:', error);
        alert(error.message || 'Có lỗi xảy ra khi thêm/cập nhật gói tập. Vui lòng thử lại.');
    }
});

// Tải danh sách khi trang được tải
document.addEventListener('DOMContentLoaded', () => {
    loadBranches();
});

// Hiển thị chi tiết khi nhấn nút "Thêm chi nhánh"
document.querySelector('[data-bs-target="#addBranchModal"]').addEventListener('click', async () => {
    const modal = new bootstrap.Modal(document.getElementById('addBranchModal'));
    modal.show();
    try {
        const response = await fetch('http://localhost:5197/api/GymBranches');
        if (!response.ok) throw new Error('Không thể tải danh sách chi nhánh');
        const branches = await response.json();
        const branchIdInput = document.getElementById('branchId');
        const branchNameInput = document.getElementById('branchName');
        const addressInput = document.getElementById('address');
        const cityInput = document.getElementById('city');
        const districtInput = document.getElementById('district');
        const phoneNumberInput = document.getElementById('phoneNumber');
        const emailInput = document.getElementById('email');
        const openingHoursInput = document.getElementById('openingHours');
        const descriptionInput = document.getElementById('description');
        const mapLocationInput = document.getElementById('mapLocation');
        const latitudeInput = document.getElementById('latitude');
        const longitudeInput = document.getElementById('longitude');

        // Lấy thông tin chi nhánh đầu tiên làm ví dụ (có thể thay bằng logic chọn chi nhánh cụ thể)
        if (branches.length > 0) {
            const sampleBranch = branches[0];
            branchIdInput.value = '';
            branchNameInput.value = sampleBranch.branchName;
            addressInput.value = sampleBranch.address;
            cityInput.value = sampleBranch.city;
            districtInput.value = sampleBranch.district;
            phoneNumberInput.value = sampleBranch.phoneNumber;
            emailInput.value = sampleBranch.email;
            openingHoursInput.value = sampleBranch.openingHours;
            descriptionInput.value = sampleBranch.description;
            mapLocationInput.value = sampleBranch.mapLocation;
            latitudeInput.value = sampleBranch.latitude;
            longitudeInput.value = sampleBranch.longitude;
        }
    } catch (error) {
        console.error('Lỗi khi tải chi tiết chi nhánh:', error);
        alert('Có lỗi xảy ra khi tải chi tiết chi nhánh. Vui lòng thử lại.');
    }
});