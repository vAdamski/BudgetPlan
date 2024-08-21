import ApexCharts from 'react-apexcharts';

function PieChart({ values, labels, percentage, valuesPosition, showLegend = true }) {
    const options = {
        chart: {
            type: 'pie',
            width: '100%',
        },
        labels: labels,
        tooltip: {
            y: {
                formatter: (value) => `${value}${percentage ? ' %' : ''}` // Tooltip formatting
            }
        },
        legend: {
            show: showLegend,
            position: valuesPosition || 'bottom',
        },
        dataLabels: {
            enabled: true,
            formatter: function (val, opts) {
                if (percentage) {
                    return `${val.toFixed(2)} %`; // Show percentage if true
                } else {
                    return `${opts.w.config.series[opts.seriesIndex]}`; // Show raw value if false
                }
            }
        }
    };

    // To 2 numbers after the decimal point
    const series = values.map(value => parseFloat(value.toFixed(2)));

    return (
        <div>
            <ApexCharts
                options={options}
                series={series}
                type="donut"
                width="400" // You can adjust the width as needed
            />
        </div>
    );
}

export default PieChart;