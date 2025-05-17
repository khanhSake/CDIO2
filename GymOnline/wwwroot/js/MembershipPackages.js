const apiBaseUrl = "http://localhost:44316/api";

// Hàm hiển thị thông báo
function showMessage(text, isSuccess) {
    const messageDiv = document.getElementById("message");
    messageDiv.textContent = text;
    messageDiv.className = isSuccess ? "success" : "error";
}

// Lấy danh sách gói tập và hiển thị
async function loadPackages() {
    try {
        const response = await fetch(`${apiBaseUrl}/membershippackages`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
            }
        });
        if (!response.ok) {
            throw new Error(`Không thể tải danh sách gói tập. Status: ${response.status} - ${response.statusText}`);
        }
        const packages = await response.json();

        const container = document.getElementById("packagesContainer");

        packages.forEach(pkg => {
            const card = document.createElement("div");
            card.className = "package-card";
            card.innerHTML = `
                <h3>${pkg.packageName}</h3>
                ${pkg.discountedPrice ? `<p class="discounted-price">$${pkg.price.toFixed(2)}</p>` : ""}
                <p class="price">$${pkg.discountedPrice ? pkg.discountedPrice.toFixed(2) : pkg.price.toFixed(2)}</p>
                <p>${pkg.description || "No description available."}</p>
                <p><strong>Duration:</strong> ${pkg.duration} ${pkg.durationType}</p>
                <p><strong>Features:</strong> ${pkg.features || "No features listed."}</p>
                <button onclick="bookPackage(${pkg.packageId})">Book</button>
            `;
            container.appendChild(card);
        });
    } catch (error) {
        showMessage(error.message, false);
        console.error("Error details:", error);
    }
}

// Chuyển đến trang booking với packageId
function bookPackage(packageId) {
    window.location.href = `booking.html?packageId=${packageId}`;
}

// Tải danh sách gói tập khi trang được tải
window.onload = loadPackages;