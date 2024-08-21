import ApexCharts from 'react-apexcharts';

function PieChart({ values, labels, percentage, valuesPosition, showLegend = true}) {
    const options = {
        chart: {
            type: 'pie',
            width: '100%',
        },
        labels: labels,
        tooltip: {
            y: {
                formatter: (value) => `${value} ${percentage ? '%' : ''}`
            }
        },
        legend: {
            show: showLegend,
            position: valuesPosition || 'bottom'
        }
    };

    // To 2 numbers after the decimal point
    const series = values.map(value => parseFloat(value.toFixed(2)));

    return (
        <div>
            <ApexCharts
                options={options}
                series={series}
                type="pie"
                width="400" // You can adjust the width as needed
            />
        </div>
    );
}

export default PieChart;