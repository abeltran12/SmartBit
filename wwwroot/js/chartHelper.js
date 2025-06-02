window.charts = window.charts || {};

window.renderBankChart = (canvasId, labels, gastos, depositos) => {
    const ctx = document.getElementById(canvasId).getContext('2d');

    if (window.charts[canvasId] && typeof window.charts[canvasId].destroy === 'function') {
        window.charts[canvasId].destroy();
    }

    window.charts[canvasId] = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Expenses',
                    data: gastos,
                    backgroundColor: 'rgba(255, 99, 132, 0.7)'
                },
                {
                    label: 'Deposits',
                    data: depositos,
                    backgroundColor: 'rgba(54, 162, 235, 0.7)'
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Expenses vs Deposits per Monetary Fund'
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
};
