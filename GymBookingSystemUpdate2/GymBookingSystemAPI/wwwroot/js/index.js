// Language Selector
document.addEventListener('DOMContentLoaded', () => {
    const languageSelector = document.querySelector('.language-dropdown');
    if (languageSelector) {
        languageSelector.addEventListener('click', (e) => {
            e.stopPropagation();
            // Thêm code xử lý dropdown ngôn ngữ ở đây
            console.log('Đã click vào bộ chọn ngôn ngữ');
        });
    }

    // Back to Top Button
    const backToTopButton = document.getElementById('back-to-top');

    window.addEventListener('scroll', () => {
        if (window.scrollY > 300) {
            backToTopButton.style.display = 'block';
        } else {
            backToTopButton.style.display = 'none';
        }
    });

    backToTopButton.addEventListener('click', () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });
});