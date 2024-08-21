import PieChart from "./PieChart.jsx";

function ExpensesChart(){
    const values = [50,50];
    const labels = ['A', 'B'];

    return (
        <div>
            <h5>Wydatki</h5>
            <PieChart values={values} labels={labels} valuesPosition={'bottom'}/>
        </div>
    );
}

export default ExpensesChart;