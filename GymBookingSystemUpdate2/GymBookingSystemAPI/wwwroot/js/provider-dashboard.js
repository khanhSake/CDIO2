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
                    <label class="toggle-switch">
                        <input type="checkbox" class="toggle-input" data-id="${branch.branchID}" ${branch.isActive ? 'checked' : ''}>
                        <span class="toggle-slider"></span>
                    </label>
                </td>
                <td>
                    <button class="btn btn-warning btn-sm edit-btn" data-id="${branch.branchID}" ${branch.isActive ? '' : 'disabled'}>Sửa</button>
                    <button class="btn btn-danger btn-sm delete-btn" data-id="${branch.branchID}">Xóa</button>
                    <button class="btn btn-info btn-sm reviews-btn" data-id="${branch.branchID}">Xem đánh giá</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.edit-btn').forEach(btn => {
            btn.addEventListener('click', () => {
                const modal = new bootstrap.Modal(document.getElementById('editBranchModal'));
                document.getElementById('editBranchIdInput').value = btn.dataset.id;
                loadCombinedBranchDetails(btn.dataset.id);
                modal.show();
            });
        });
        document.querySelectorAll('.delete-btn').forEach(btn => {
            btn.addEventListener('click', () => deleteBranch(btn.dataset.id));
        });
        document.querySelectorAll('.reviews-btn').forEach(btn => {
            btn.addEventListener('click', () => viewReviews(btn.dataset.id));
        });
        document.querySelectorAll('.toggle-input').forEach(toggle => {
            toggle.addEventListener('change', () => toggleBranchStatus(toggle.dataset.id, toggle.checked));
        });
    } catch (error) {
        console.error('Lỗi khi tải danh sách chi nhánh:', error);
        alert('Có lỗi xảy ra khi tải danh sách chi nhánh. Vui lòng thử lại.');
    }
}

async function searchBranches(keyword) {
    try {
        const response = await fetch('http://localhost:5197/api/GymBranches');
        if (!response.ok) throw new Error('Không thể tải danh sách chi nhánh');
        const branches = await response.json();

        const filteredBranches = branches.filter(branch =>
            branch.branchName.toLowerCase().includes(keyword.toLowerCase()) ||
            branch.city.toLowerCase().includes(keyword.toLowerCase()) ||
            branch.address.toLowerCase().includes(keyword.toLowerCase())
        );

        const tbody = document.getElementById('branchesBody');
        tbody.innerHTML = '';
        filteredBranches.forEach(branch => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${branch.branchName}</td>
                <td>${branch.address}</td>
                <td>${branch.city}</td>
                <td>
                    <label class="toggle-switch">
                        <input type="checkbox" class="toggle-input" data-id="${branch.branchID}" ${branch.isActive ? 'checked' : ''}>
                        <span class="toggle-slider"></span>
                    </label>
                </td>
                <td>
                    <button class="btn btn-warning btn-sm edit-btn" data-id="${branch.branchID}" ${branch.isActive ? '' : 'disabled'}>Sửa</button>
                    <button class="btn btn-danger btn-sm delete-btn" data-id="${branch.branchID}">Xóa</button>
                    <button class="btn btn-info btn-sm reviews-btn" data-id="${branch.branchID}">Xem đánh giá</button>
                </td>
            `;
            tbody.appendChild(tr);
        });

        document.querySelectorAll('.edit-btn').forEach(btn => {
            btn.addEventListener('click', () => {
                const modal = new bootstrap.Modal(document.getElementById('editBranchModal'));
                document.getElementById('editBranchIdInput').value = btn.dataset.id;
                loadCombinedBranchDetails(btn.dataset.id);
                modal.show();
            });
        });
        document.querySelectorAll('.delete-btn').forEach(btn => {
            btn.addEventListener('click', () => deleteBranch(btn.dataset.id));
        });
        document.querySelectorAll('.reviews-btn').forEach(btn => {
            btn.addEventListener('click', () => viewReviews(btn.dataset.id));
        });
        document.querySelectorAll('.toggle-input').forEach(toggle => {
            toggle.addEventListener('change', () => toggleBranchStatus(toggle.dataset.id, toggle.checked));
        });
    } catch (error) {
        console.error('Lỗi khi tìm kiếm chi nhánh:', error);
        alert('Có lỗi xảy ra khi tìm kiếm chi nhánh. Vui lòng thử lại.');
    }
}

document.getElementById('searchBranchBtn').addEventListener('click', () => {
    const keyword = document.getElementById('searchBranchInput').value.trim();
    if (keyword) {
        searchBranches(keyword);
    } else {
        loadBranches();
    }
});

document.getElementById('searchBranchInput').addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        const keyword = e.target.value.trim();
        if (keyword) {
            searchBranches(keyword);
        } else {
            loadBranches();
        }
    }
});

async function toggleBranchStatus(branchId, isActive) {
    try {
        const response = await fetch(`http://localhost:5197/api/GymBranches/${branchId}/ToggleStatus`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(isActive)
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Không thể cập nhật trạng thái chi nhánh');
        }

        const result = await response.json();
        alert('Cập nhật trạng thái thành công!');
        loadBranches();
    } catch (error) {
        console.error('Lỗi khi cập nhật trạng thái chi nhánh:', error);
        alert('Có lỗi xảy ra khi cập nhật trạng thái chi nhánh. Vui lòng thử lại.');
    }
}

async function loadCombinedBranchDetails(branchId) {
    document.getElementById('branchDetailsSection').style.display = 'block';
    const branchResponse = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`);
    if (!branchResponse.ok) throw new Error('Không thể tải thông tin chi nhánh');
    const branch = await branchResponse.json();

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

    const packagesBody = document.getElementById('packagesBody');
    packagesBody.innerHTML = '';
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
                <button class="btn btn-warning btn-sm edit-package-btn" data-id="${pkg.packageID}">Sửa gói tập</button>
                <button class="btn btn-danger btn-sm delete-package-btn" data-id="${pkg.packageID}">Xóa</button>
            </td>
        `;
        packagesBody.appendChild(tr);
    });
    document.querySelectorAll('.edit-package-btn').forEach(btn => {
        btn.addEventListener('click', () => editPackage(btn.dataset.id));
    });
    document.querySelectorAll('.delete-package-btn').forEach(btn => {
        btn.addEventListener('click', () => deletePackage(btn.dataset.id, branchId));
    });

    const facilitiesBody = document.getElementById('facilitiesBody');
    facilitiesBody.innerHTML = '';
    branch.facilities.forEach(facility => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${facility.facilityName}</td>
            <td>${facility.description}</td>
            <td>${facility.iconClass}</td>
            <td>
                <button class="btn btn-warning btn-sm edit-facility-btn" data-id="${facility.facilityID}">Sửa tiện ích</button>
                <button class="btn btn-danger btn-sm delete-facility-btn" data-id="${facility.facilityID}">Xóa</button>
            </td>
        `;
        facilitiesBody.appendChild(tr);
    });
    document.querySelectorAll('.edit-facility-btn').forEach(btn => {
        btn.addEventListener('click', () => editFacility(btn.dataset.id));
    });
    document.querySelectorAll('.delete-facility-btn').forEach(btn => {
        btn.addEventListener('click', () => deleteFacility(btn.dataset.id, branchId));
    });

    const imagesBody = document.getElementById('imagesBody');
    imagesBody.innerHTML = '';
    branch.branchImages.forEach(image => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${image.imageURL}</td>
            <td>${image.caption}</td>
            <td>${image.isMainImage ? 'Có' : 'Không'}</td>
            <td>
                <button class="btn btn-danger btn-sm delete-image-btn" data-id="${image.imageID}">Xóa</button>
            </td>
        `;
        imagesBody.appendChild(tr);
    });
    document.querySelectorAll('.delete-image-btn').forEach(btn => {
        btn.addEventListener('click', async () => {
            if (confirm('Bạn có chắc muốn xóa hình ảnh này?')) {
                try {
                    const response = await fetch(`http://localhost:5197/api/BranchImages/${btn.dataset.id}`, {
                        method: 'DELETE'
                    });
                    if (!response.ok) throw new Error('Không thể xóa hình ảnh');
                    loadCombinedBranchDetails(branchId);
                } catch (error) {
                    console.error('Lỗi khi xóa hình ảnh:', error);
                    alert('Có lỗi xảy ra khi xóa hình ảnh. Vui lòng thử lại.');
                }
            }
        });
    });
}

document.getElementById('editBranchForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const branchId = document.getElementById('editBranchId').value;
    if (!branchId) {
        alert('Vui lòng tải thông tin chi nhánh trước khi cập nhật.');
        return;
    }

    const branchData = {
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
        const branchResponse = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(branchData)
        });
        if (!branchResponse.ok) throw new Error('Không thể cập nhật chi nhánh');

        const packageId = document.getElementById('editingPackageId').value;
        if (packageId) {
            const packageData = {
                PackageName: document.getElementById('newPackageName').value,
                Duration: parseInt(document.getElementById('newDuration').value),
                DurationType: document.getElementById('newDurationType').value,
                Price: parseFloat(document.getElementById('newPrice').value),
                DiscountedPrice: document.getElementById('newDiscountedPrice').value ? parseFloat(document.getElementById('newDiscountedPrice').value) : null,
                Description: document.getElementById('newDescription').value,
                Features: document.getElementById('newFeatures').value,
                IsPopular: document.getElementById('newIsPopular').checked
            };
            const packageResponse = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(packageData)
            });
            if (!packageResponse.ok) throw new Error('Không thể cập nhật gói tập');
            alert('Cập nhật thành công!');
        } else if (document.getElementById('newPackageName').value) {
            const newPackageData = {
                BranchID: parseInt(branchId),
                PackageName: document.getElementById('newPackageName').value,
                Duration: parseInt(document.getElementById('newDuration').value),
                DurationType: document.getElementById('newDurationType').value,
                Price: parseFloat(document.getElementById('newPrice').value),
                DiscountedPrice: document.getElementById('newDiscountedPrice').value ? parseFloat(document.getElementById('newDiscountedPrice').value) : null,
                Description: document.getElementById('newDescription').value,
                Features: document.getElementById('newFeatures').value,
                IsPopular: document.getElementById('newIsPopular').checked
            };
            const newPackageResponse = await fetch('http://localhost:5197/api/MembershipPackages', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newPackageData)
            });
            if (!newPackageResponse.ok) throw new Error('Không thể thêm gói tập');
            alert('Cập nhật thành công!');
        }

        const facilityId = document.getElementById('editingFacilityId').value;
        if (facilityId) {
            const facilityData = {
                FacilityName: document.getElementById('facilityName').value,
                Description: document.getElementById('facilityDescription').value,
                IconClass: document.getElementById('facilityIcon').value
            };
            const facilityResponse = await fetch(`http://localhost:5197/api/Facilities/${facilityId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(facilityData)
            });
            if (!facilityResponse.ok) throw new Error('Không thể cập nhật tiện ích');
            alert('Cập nhật thành công!');
        } else if (document.getElementById('facilityName').value) {
            const newFacilityData = {
                BranchID: parseInt(branchId),
                FacilityName: document.getElementById('facilityName').value,
                Description: document.getElementById('facilityDescription').value,
                IconClass: document.getElementById('facilityIcon').value
            };
            const newFacilityResponse = await fetch('http://localhost:5197/api/Facilities', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newFacilityData)
            });
            if (!newFacilityResponse.ok) throw new Error('Không thể thêm tiện ích');
            alert('Cập nhật thành công!');
        }

        if (document.getElementById('imageUrl').value) {
            const imageData = {
                BranchID: parseInt(branchId),
                ImageURL: document.getElementById('imageUrl').value,
                Caption: document.getElementById('imageCaption').value,
                IsMainImage: document.getElementById('isMainImage').checked,
                DisplayOrder: 0
            };
            const imageResponse = await fetch('http://localhost:5197/api/BranchImages', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(imageData)
            });
            if (!imageResponse.ok) throw new Error('Không thể thêm hình ảnh');
            alert('Cập nhật thành công!');
        }

        loadBranches();
    } catch (error) {
        console.error('Lỗi khi cập nhật:', error);
        alert('Có lỗi xảy ra khi cập nhật. Vui lòng thử lại.');
    }
});

async function editPackage(packageId) {
    try {
        const response = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`);
        if (!response.ok) throw new Error('Không thể tải thông tin gói tập');
        const pkg = await response.json();
        document.getElementById('editingPackageId').value = pkg.packageID;
        document.getElementById('newPackageName').value = pkg.packageName;
        document.getElementById('newDuration').value = pkg.duration;
        document.getElementById('newDurationType').value = pkg.durationType;
        document.getElementById('newPrice').value = pkg.price;
        document.getElementById('newDiscountedPrice').value = pkg.discountedPrice || '';
        document.getElementById('newDescription').value = pkg.description || '';
        document.getElementById('newFeatures').value = pkg.features || '';
        document.getElementById('newIsPopular').checked = pkg.isPopular;
    } catch (error) {
        console.error('Lỗi khi sửa gói tập:', error);
        alert('Có lỗi xảy ra khi sửa gói tập. Vui lòng thử lại.');
    }
}

async function deletePackage(packageId, branchId) {
    if (confirm('Bạn có chắc muốn xóa gói tập này?')) {
        try {
            const response = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`, {
                method: 'DELETE'
            });
            if (!response.ok) throw new Error('Xóa không thành công');
            loadCombinedBranchDetails(branchId);
        } catch (error) {
            console.error('Lỗi khi xóa gói tập:', error);
            alert('Có lỗi xảy ra khi xóa gói tập. Vui lòng thử lại.');
        }
    }
}

async function editFacility(facilityId) {
    try {
        const response = await fetch(`http://localhost:5197/api/Facilities/${facilityId}`);
        if (!response.ok) throw new Error('Không thể tải thông tin tiện ích');
        const facility = await response.json();
        document.getElementById('editingFacilityId').value = facility.facilityID;
        document.getElementById('facilityName').value = facility.facilityName;
        document.getElementById('facilityDescription').value = facility.description;
        document.getElementById('facilityIcon').value = facility.iconClass;
    } catch (error) {
        console.error('Lỗi khi sửa tiện ích:', error);
        alert('Có lỗi xảy ra khi sửa tiện ích. Vui lòng thử lại.');
    }
}

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
            loadCombinedBranchDetails(branchId);
        } catch (error) {
            console.error('Lỗi khi xóa tiện ích:', error);
            alert(error.message || 'Có lỗi xảy ra khi xóa tiện ích. Vui lòng thử lại.');
        }
    }
}

document.addEventListener('DOMContentLoaded', () => {
    loadBranches();
});

document.querySelector('[data-bs-target="#addBranchModal"]').addEventListener('click', async () => {
    const modal = new bootstrap.Modal(document.getElementById('addBranchModal'));
    modal.show();
    try {
        const response = await fetch('http://localhost:5197/api/GymBranches');
        if (!response.ok) throw new Error('Không thể tải danh sách chi nhánh');
        const branches = await response.json();
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

        if (branches.length > 0) {
            const sampleBranch = branches[0];
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

document.getElementById('updateButton').addEventListener('click', async () => {
    const branchId = document.getElementById('editBranchId').value;
    if (!branchId) {
        alert('Vui lòng tải thông tin chi nhánh trước khi cập nhật.');
        return;
    }

    const branchData = {
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
        const branchResponse = await fetch(`http://localhost:5197/api/GymBranches/${branchId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(branchData)
        });
        if (!branchResponse.ok) throw new Error('Không thể cập nhật chi nhánh');

        const packageId = document.getElementById('editingPackageId').value;
        if (packageId) {
            const packageData = {
                PackageName: document.getElementById('newPackageName').value,
                Duration: parseInt(document.getElementById('newDuration').value),
                DurationType: document.getElementById('newDurationType').value,
                Price: parseFloat(document.getElementById('newPrice').value),
                DiscountedPrice: document.getElementById('newDiscountedPrice').value ? parseFloat(document.getElementById('newDiscountedPrice').value) : null,
                Description: document.getElementById('newDescription').value,
                Features: document.getElementById('newFeatures').value,
                IsPopular: document.getElementById('newIsPopular').checked
            };
            const packageResponse = await fetch(`http://localhost:5197/api/MembershipPackages/${packageId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(packageData)
            });
            if (!packageResponse.ok) throw new Error('Không thể cập nhật gói tập');
        } else if (document.getElementById('newPackageName').value) {
            const newPackageData = {
                BranchID: parseInt(branchId),
                PackageName: document.getElementById('newPackageName').value,
                Duration: parseInt(document.getElementById('newDuration').value),
                DurationType: document.getElementById('newDurationType').value,
                Price: parseFloat(document.getElementById('newPrice').value),
                DiscountedPrice: document.getElementById('newDiscountedPrice').value ? parseFloat(document.getElementById('newDiscountedPrice').value) : null,
                Description: document.getElementById('newDescription').value,
                Features: document.getElementById('newFeatures').value,
                IsPopular: document.getElementById('newIsPopular').checked
            };
            const newPackageResponse = await fetch('http://localhost:5197/api/MembershipPackages', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newPackageData)
            });
            if (!newPackageResponse.ok) throw new Error('Không thể thêm gói tập');
        }

        const facilityId = document.getElementById('editingFacilityId').value;
        if (facilityId) {
            const facilityData = {
                FacilityName: document.getElementById('facilityName').value,
                Description: document.getElementById('facilityDescription').value,
                IconClass: document.getElementById('facilityIcon').value
            };
            const facilityResponse = await fetch(`http://localhost:5197/api/Facilities/${facilityId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(facilityData)
            });
            if (!facilityResponse.ok) throw new Error('Không thể cập nhật tiện ích');
        } else if (document.getElementById('facilityName').value) {
            const newFacilityData = {
                BranchID: parseInt(branchId),
                FacilityName: document.getElementById('facilityName').value,
                Description: document.getElementById('facilityDescription').value,
                IconClass: document.getElementById('facilityIcon').value
            };
            const newFacilityResponse = await fetch('http://localhost:5197/api/Facilities', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newFacilityData)
            });
            if (!newFacilityResponse.ok) throw new Error('Không thể thêm tiện ích');
        }

        if (document.getElementById('imageUrl').value) {
            const imageData = {
                BranchID: parseInt(branchId),
                ImageURL: document.getElementById('imageUrl').value,
                Caption: document.getElementById('imageCaption').value,
                IsMainImage: document.getElementById('isMainImage').checked,
                DisplayOrder: 0
            };
            const imageResponse = await fetch('http://localhost:5197/api/BranchImages', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(imageData)
            });
            if (!imageResponse.ok) throw new Error('Không thể thêm hình ảnh');
        }

        alert('Cập nhật thành công!');
        loadCombinedBranchDetails(branchId);
    } catch (error) {
        console.error('Lỗi khi cập nhật:', error);
        alert('Có lỗi xảy ra khi cập nhật. Vui lòng thử lại.');
    }
});

document.getElementById('addBranchForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const branchData = {
        ProviderID: parseInt(document.getElementById('providerID').value),
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

document.getElementById('loadReviewsBtn').addEventListener('click', () => {
    const branchId = document.getElementById('reviewBranchIdInput').value;
    if (!branchId) {
        alert('Vui lòng nhập BranchID.');
        return;
    }
    viewReviews(branchId);
});