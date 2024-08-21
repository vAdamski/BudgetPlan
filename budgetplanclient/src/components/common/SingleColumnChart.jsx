import ApexCharts from 'react-apexcharts';

function SingleColumnChart({ labels, values }) {
    const options = {
        chart: {
            type: 'bar',
            height: 350,
        },
        plotOptions: {
            bar: {
                horizontal: false, // Ustawienie na pionowy wykres słupkowy
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false, // Wyłączanie wartości na słupkach
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: labels, // Kategorie na osi X pochodzące z API
        },
        yaxis: {
            title: {
                text: 'Kwota',
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: (value) => `${value}`
            }
        },
        legend: {
            show: false, // Wyłączamy legendę, ponieważ mamy tylko jedną serię
        }
    };

    // Seria danych zawiera tylko jedną kategorię, z wartościami z API
    const series = [
        {
            name: 'Suma',
            data: values.map(value => parseFloat(value.toFixed(2)))
        }
    ];

    return (
        <div>
            <ApexCharts
                options={options}
                series={series}
                type="bar"
            />
        </div>
    );
}

export default SingleColumnChart;