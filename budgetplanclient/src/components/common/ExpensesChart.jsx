import PieChart from "./PieChart.jsx";
import {useEffect, useState} from "react";
import useDataSummaryApi from "../../services/api/dataSummaryDataApi.jsx";
import SingleColumnChart from "./SingleColumnChart.jsx";

function ExpensesChart({budgetPlanId, budgetPlanBaseId}) {
    const {fetchExpenseSummary} = useDataSummaryApi();
    const [values, setValues] = useState([]);
    const [labels, setLabels] = useState([]);


    useEffect(() => {
        const fetchPieChartData = async () => {

            const data = await fetchExpenseSummary(budgetPlanId, budgetPlanBaseId, false);

            setValues(data.values || []);
            setLabels(data.labels || []);

            console.log(data);
        };

        fetchPieChartData().then();
    }, [budgetPlanId, budgetPlanBaseId]);

    return (
        <div className={'text-center'}>
            <h5>Wydatki</h5>
            <SingleColumnChart
                labels={labels}
                values={values}
            />
        </div>
    );
}

export default ExpensesChart;