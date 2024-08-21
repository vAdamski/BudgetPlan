import PieChart from "./PieChart.jsx";
import {useEffect, useState} from "react";
import useDataSummaryApi from "../../services/api/dataSummaryDataApi.jsx";

function CategoriesSummaryChart({budgetPlanId, budgetPlanBaseId}) {
    const {fetchCategoryPercentSummary} = useDataSummaryApi();


    const [values, setValues] = useState([]);
    const [labels, setLabels] = useState([]);


    useEffect(() => {
        const fetchPieChartData = async () => {

            const data = await fetchCategoryPercentSummary(budgetPlanId, budgetPlanBaseId);

            setValues(data.values || []);
            setLabels(data.labels || []);

            console.log(data);
        };

        fetchPieChartData().then();
    }, [budgetPlanId, budgetPlanBaseId]);


    return (
        <div className={'text-center'}>
            <h5>Wydatki w kategoriach</h5>
            <PieChart values={values} labels={labels} percentage={true} valuesPosition={'bottom'}/>
        </div>
    );
}

export default CategoriesSummaryChart;