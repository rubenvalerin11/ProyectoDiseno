
document.addEventListener("DOMContentLoaded", function() {
    const navbar = document.querySelector(".apple-navbar");
    const links = document.querySelectorAll(".apple-link");

    function updateNavbarOnScroll() {
        if (window.scrollY > 20) {
            navbar.classList.add("navbar-scrolled");
        } else {
            navbar.classList.remove("navbar-scrolled");
        }
    }

    updateNavbarOnScroll();
    window.addEventListener("scroll", updateNavbarOnScroll);

    const currentPath = window.location.pathname.toLowerCase();

    links.forEach(link => {
        const href = link.getAttribute("href");
        if (!href) return;

        if (href.toLowerCase() === currentPath) {
            link.classList.add("active");
        }

        if (currentPath === "/" && href.toLowerCase().includes("/home")) {
            link.classList.add("active");
        }
    });
});