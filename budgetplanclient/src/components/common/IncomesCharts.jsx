import useDataSummaryApi from "../../services/api/dataSummaryDataApi.jsx";
import {useEffect, useState} from "react";
import SingleColumnChart from "./SingleColumnChart.jsx";

function IncomesChart({budgetPlanId, budgetPlanBaseId}){
    const {fetchIncomeSummary} = useDataSummaryApi();
    const [values, setValues] = useState([]);
    const [labels, setLabels] = useState([]);


    useEffect(() => {
        const fetchPieChartData = async () => {

            const data = await fetchIncomeSummary(budgetPlanId, budgetPlanBaseId, false);

            setValues(data.values || []);
            setLabels(data.labels || []);

            console.log(data);
        };

        fetchPieChartData().then();
    }, [budgetPlanId, budgetPlanBaseId]);

    return (
        <div className={'text-center'}>
            <h5>Przychody</h5>
            <SingleColumnChart
                labels={labels}
                values={values}
            />
        </div>
    );
}

export default IncomesChart;