// Line chart - Revenue
window.renderRevenueLineChart = (labels, revenues) => {

    const ctx = document.getElementById('revenueLineChart');
    if (!ctx) return;

    if (window.revenueChart) {
        window.revenueChart.destroy();
    }

    window.revenueChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Doanh thu',
                data: revenues,
                tension: 0.4,
                fill: false
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true }
            }
        }
    });
};

// Bar chart - Orders
window.renderOrdersBarChart = (labels, orders) => {

    const ctx = document.getElementById('ordersBarChart');
    if (!ctx) return;

    if (window.ordersChart) {
        window.ordersChart.destroy();
    }

    window.ordersChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Số đơn hàng',
                data: orders
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true }
            }
        }
    });
};
// Pie chart - Category Distribution

window.renderCategoryPieChart = (labels, values) => {

    const canvas = document.getElementById('categoryPieChart');
    if (!canvas) return;

    // Destroy chart cũ nếu tồn tại & hợp lệ
    if (window._categoryPieChart instanceof Chart) {
        window._categoryPieChart.destroy();
    }

    window._categoryPieChart = new Chart(canvas, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: values
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'right'
                }
            }
        }
    });
};
