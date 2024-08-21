import PieChart from "./PieChart.jsx";

function LeftMoneySummaryChart() {
    const values = [50,50];
    const labels = ['A', 'B'];

    return (
        <div>
            <h5>Pozostało do wydania</h5>
            <PieChart values={values} labels={labels} valuesPosition={'bottom'}/>
        </div>
    );
}

export default LeftMoneySummaryChart;