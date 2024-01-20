function destroyChart(chartId) {
    var chart = Chart.getChart(chartId);
    if (chart) {
        chart.destroy();
    }
}

window.destroyChart = destroyChart; // Eksportuj funkcję do globalnego zakresu
